using Production.Contracts;
using Production.Entities.DTO;
using Production.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production.Repository
{
    public class ServiceManager : IServiceManager
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
        }

        public async Task<AddEditCategoryProductDTO> GetProductCategory(int id)
        {
            var category = await _repositoryManager.productCategoryRepository.GetProductCategoryByID(id, trackChanges : true);
           
            IEnumerable<ProductSubcategory> subcategory = _repositoryManager.productSubCategoryRepository.GetAllProductSubCategory(trackChanges: true)
               .Result.Where(c => c.ProductCategoryID == id);

            if (category == null)
            {
                _loggerManager.LogError($"Category Product with id : {id} not found");
            }

            AddEditCategoryProductDTO subDTO = new AddEditCategoryProductDTO();

            subDTO.ProductCategoryID = category.ProductCategoryID; 
            subDTO.Name = category.Name;

            List<string> nameSub = new List<string>();

            foreach (var item in subcategory)
            {
                nameSub.Add(item.Name);
            }

            subDTO.SubCategoryName = nameSub;

            return subDTO;
        }

        public async Task<AddEditCategoryProductDTO> AddCategoryProduct(AddEditCategoryProductDTO addCategoryProductDTO)
        {
            ProductCategory category = new ProductCategory(){
                Name = addCategoryProductDTO.Name
            };

            _repositoryManager.productCategoryRepository.CreateProductCategory(category);
            await _repositoryManager.SaveAsync();
            var cateResult = category;

            foreach (var sub in addCategoryProductDTO.ProductSubCategories)
            {
                ProductSubcategory subcategory = new ProductSubcategory() { 
                    ProductCategoryID = cateResult.ProductCategoryID,
                    Name = sub.Name
                };
                _repositoryManager.productSubCategoryRepository.CreateProductSubCategory(subcategory);
                await _repositoryManager.SaveAsync();
            }
            return addCategoryProductDTO;
        }

        public async Task<AddEditCategoryProductDTO> UpdateCategoryProduct(int id, AddEditCategoryProductDTO editCategoryProductDTO)
        {
            var categoryEntity = await _repositoryManager.productCategoryRepository.GetProductCategoryByID(id, trackChanges: true);
            categoryEntity.Name = editCategoryProductDTO.Name;
            if (categoryEntity == null)
            {
                _loggerManager.LogError($"Category Product with id : {id} not found");
            }
            //await _repositoryManager.SaveAsync();

            foreach (var sub in editCategoryProductDTO.ProductSubCategories)
            {
                try
                {
                    var subCateEntity = await _repositoryManager.productSubCategoryRepository.GetProductSubCategoryByID(sub.ProductSubcategoryID, trackChanges: true);

                    if (subCateEntity == null)
                    {
                        var subcateModel = new ProductSubcategory();

                        subcateModel.ProductSubcategoryID = sub.ProductSubcategoryID;
                        subcateModel.Name = sub.Name;
                        subcateModel.ProductCategoryID = sub.ProductCategoryID;

                        _repositoryManager.productSubCategoryRepository.CreateProductSubCategory(subcateModel);
                    }
                    else
                    {
                        subCateEntity.Name = sub.Name;
                        subCateEntity.ProductCategoryID = sub.ProductCategoryID;
                        _repositoryManager.productSubCategoryRepository.UpdateProductSubCategory(subCateEntity);
                    }
                }
                catch (Exception ex)
                {
                    _loggerManager.LogError($"Error when insert into SubCategories {ex.Message}");
                }
            }
            await _repositoryManager.SaveAsync();
            return editCategoryProductDTO;
        }
        public async Task<bool> DeleteFamilyCategoryProduct(int id, bool trackChanges)
        {
            var category = await _repositoryManager.productCategoryRepository.GetProductCategoryByID(id, trackChanges: true);
            IEnumerable<ProductSubcategory> subcategory = _repositoryManager.productSubCategoryRepository.GetAllProductSubCategory(trackChanges: true)
                .Result.Where(c => c.ProductCategoryID == id);

            //List<string> tampung = new List<string>();
            if ( subcategory != null)
            {
                foreach (var item in subcategory)
                {
                    _repositoryManager.productSubCategoryRepository.DeleteProductSubCategory(item);
                    await _repositoryManager.SaveAsync();
                }
            }

            _repositoryManager.productCategoryRepository.DeleteProductCategory(category);
            await _repositoryManager.SaveAsync();
            
            
            return true;
        }

        public Task<Product> AddProduct(AddProductDTO addProductDTO)
        {
            throw new InvalidOperationException("Logfile cannot be read-only");
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
