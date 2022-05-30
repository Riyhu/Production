using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Production.Contracts;
using Production.Entities.DTO;
using Production.Entities.Models;
using Production.Entities.RequestFeatures;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionWebApi.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        //private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ProductController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper/*, IServiceManager serviceManager*/)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            //_serviceManager = serviceManager;   
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetProduct(string name)
        {
            var getProduct = await _repository.Product.GetProductByName(name, trackChanges: false);
            if (getProduct == null)
            {
                _logger.LogInfo($"Product with {name} NOT FOUND !!");
                return NotFound();
            }
            else
            {
                var getProductMap = _mapper.Map<AddProductDTO>(getProduct);
                return Ok(getProductMap);
            }
        }

        [HttpGet("Search")]
        public async Task<IActionResult> SearchProduct([FromQuery] ProductParameters productParameters)
        {
            var productSearch = await _repository.vProductRepository.SearchProduct(productParameters, trackChanges: false);
            var productDTO = _mapper.Map<IEnumerable<ProductDTO>>(productSearch);
            return Ok(productDTO);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> PostProduct([FromBody] AddProductDTO addProductDTO)
        {
            if (addProductDTO == null)
            {
                _logger.LogInfo("Product is null");
                return BadRequest("Product is Null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid Modelstate");
                return UnprocessableEntity(addProductDTO);
            }
            var productEntity = _mapper.Map<Product>(addProductDTO);
            _repository.Product.CreateProduct(productEntity);
            await _repository.SaveAsync();
            return Ok(productEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDTO updateProductDTO)
        {
            if (updateProductDTO == null)
            {
                _logger.LogError("PRODUCT must not be null");
                return BadRequest("Product must not be null");
            }
            //objek modelstate digunakan utk memvalidasi daata yg di tangkap oleh customerDTO
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid Modelstate");
                return UnprocessableEntity(ModelState);
            }
            var productEntity = await _repository.Product.GetProductByID(id, trackChanges: true); //bikin kondisi utk mendapatkan id yg ingin di ubah
            if (productEntity == null)
            {
                _logger.LogError($"Product with ID : {id} not found");
                return NotFound();
            }
            _mapper.Map(updateProductDTO, productEntity);
            // _repository.ProdukBaru.Update(productEntity);
            await _repository.SaveAsync();
            return Ok(productEntity);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _repository.Product.GetProductByID(id, trackChanges: true);
            if (product == null)
            {
                _logger.LogInfo($"product with id : {id} NOT FOUND");
                return NotFound();
            }
            _repository.Product.DeleteProduct(product);
            await _repository.SaveAsync();
            return Ok("Data has been Deleted");
        }

        [HttpPost("form"), DisableRequestSizeLimit]
        public async Task<IActionResult> PostPhoto(int ProductID)
        {
            try
            {
                var form = await Request.ReadFormAsync(); //menangkap inputan user
                var file = form.Files.First(); //menahan data yg berupa file sperti gambar  sblm di proses
                //form.TryGetValue("LargePhoto", out var largePhoto).ToString(); //mencoba mndapatkan data dari inputan user ke dlm table
                form.TryGetValue("LargePhotoFileName", out var largePhotoFileName).ToString();
                //form.TryGetValue("ProductID", out var productId).ToString();
                using (var memoryStream = new MemoryStream())
                {
                    //mengubah file mnjadi objek
                    await file.CopyToAsync(memoryStream);
                    var photoDTO = new PhotoDTO()
                    {
                        LargePhotoFileName = largePhotoFileName,
                        LargePhoto = memoryStream.ToArray()
                    };
                    var photoEnitty = _mapper.Map<ProductPhoto>(photoDTO);
                    _repository.photoRepository.CreatePhoto(photoEnitty);
                    await _repository.SaveAsync();

                    var photoReturn = _mapper.Map<PhotoDTO>(photoEnitty);

                    var productPhoto = new ProductProductPhoto()
                    {
                        ProductID = ProductID,
                        ProductPhotoID = photoReturn.ProductPhotoID

                    };

                    _repository.ProductProductPhotoRepository.CreateProductPhotos(productPhoto);
                    await _repository.SaveAsync();

                    return CreatedAtRoute("GetPhotoByID", new { id = photoReturn.ProductPhotoID }, photoReturn);
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Content Type is Null {e}");
            }
        }
        [HttpGet("showimage",Name = "GetPhotoByID")]
        public async Task<IActionResult> GetPhotoProduct(int id)
        {
            var photo = await _repository.photoRepository.GetPhotoByID(id, trackChanges: true);
            if (photo == null)
            {
                _logger.LogInfo($"Image with id : {id} NOT FOUND");
                return NotFound();
            }
            byte[] picture = photo.LargePhoto;
            return base.File(picture,"image/jpeg");
        }
    }
}
