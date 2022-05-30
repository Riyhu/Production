using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Production.Contracts;
using Production.Entities.DTO;
using System.Threading.Tasks;

namespace ProductionWebApi.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryProductController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public CategoryProductController(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IServiceManager serviceManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        [HttpGet("Category")]
        public async Task<IActionResult> GetAllCategoryProduct()
        {
            var categoryProduct = await _repositoryManager.productCategoryRepository.GetAllProductCategory(false);

            if (categoryProduct != null)
            {
                return Ok(categoryProduct);
            }
            else
            {
                return BadRequest($"Data Not Found");
            }
        }

        [HttpGet("SubCategory")]
        public async Task<IActionResult> GetAllSubCategoryProduct()
        {
            var subCategoryProduct = await _repositoryManager.productSubCategoryRepository.GetAllProductSubCategory(false);

            if (subCategoryProduct != null)
            {
                return Ok(subCategoryProduct);
            }
            else
            {
                return BadRequest($"Data Not Found");
            }
        }

        [HttpGet("{id}", Name = "CategoryProductById")]
        public async Task<IActionResult> GetCategoryProduct(int id)
        {
            var categoryProduct = await _serviceManager.GetProductCategory(id);

            if (categoryProduct.ProductCategoryID != null)
            {
                return Ok(categoryProduct);
            }
            else
            {
                return BadRequest($"Category Product Not Found");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCategoryProduct([FromBody] AddEditCategoryProductDTO addCategoryProductDTO)
        {
            if(addCategoryProductDTO == null)
            {
                _loggerManager.LogError("Category object is null");
                return BadRequest("Category object is null");
            }

            var result = await _serviceManager.AddCategoryProduct(addCategoryProductDTO);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest($"unable to post data");
            }
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateCategoryProduct(int id, [FromBody] AddEditCategoryProductDTO editCategoryProductDTO)
        {
            if (editCategoryProductDTO == null)
            {
                _loggerManager.LogError("Category object is null");
                return BadRequest("Category object is null");
            }

            var result = await _serviceManager.UpdateCategoryProduct(id, editCategoryProductDTO);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest($"unable to update data");
            }
        }

        [HttpDelete("subcategory")]
        public async Task<IActionResult> DeleteSubCategory(int id)
        {
            var subcategory = await _repositoryManager.productSubCategoryRepository.GetProductSubCategoryByID(id, trackChanges: true);
            if (subcategory == null)
            {
                _loggerManager.LogInfo($"Customer with id : {id} doesn't exist in database");
                return NotFound();
            }

            _repositoryManager.productSubCategoryRepository.DeleteProductSubCategory(subcategory);
            await _repositoryManager.SaveAsync();
            return Ok($"Data has been deleted");
        }

        [HttpDelete("category")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _serviceManager.DeleteFamilyCategoryProduct(id, trackChanges: true);

            if (result != null)
            {
                return Ok($"Data has been deleted");
            }
            else
            {
                return BadRequest($"unable to delete data");
            }
        }
    }
}
