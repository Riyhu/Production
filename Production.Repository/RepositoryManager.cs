using Production.Contracts;
using Production.Entities.AdventureContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private AdventureContext _adventureContext;
        private IvProductRepository _vproductRepository;
        private IAddProductRepository _addProd;
        private IProductRepository _productRepository;
        private IProductSubCategoryRepository _productSubCategoryRepository;
        private IUnitMeasureRepository _unitMeasureRepository;
        private IProductModelRepository _productModelRepository;
        private IProductCategoryRepository _productCategoryRepository;

        public RepositoryManager(AdventureContext adventureContext)
        {
            _adventureContext = adventureContext;
        }

        //membuat objek ke memory... stiap program ada konstruktor, 
        public IvProductRepository ProductRepository
        {
            get
            {
                if (_vproductRepository == null)
                {
                    _vproductRepository = new vProductRepository(_adventureContext);
                }
                return _vproductRepository;
            }
        }

        public IProductRepository productRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_adventureContext);
                }
                return _productRepository;
            }
        }

        public IAddProductRepository Product
        {
            get
            {
                if (_addProd == null)
                {
                    _addProd = new AddProductRepository(_adventureContext);
                }
                return _addProd;
            }
        }

        public IvProductRepository vProductRepository
        {
            get
            {
                if (_vproductRepository == null)
                {
                    _vproductRepository = new vProductRepository(_adventureContext);
                }
                return _vproductRepository;
            }
        }

        public IProductModelRepository productModelRepository
        {
            get
            {
                if (_productModelRepository == null)
                {
                    _productModelRepository = new ProductModelRepository(_adventureContext);
                }
                return _productModelRepository;
            }
        }
        public IUnitMeasureRepository unitMeasureRepository
        {
            get
            {
                if (_unitMeasureRepository == null)
                {
                    _unitMeasureRepository = new UnitMeasureRepository(_adventureContext);
                }
                return _unitMeasureRepository;
            }
        }

        public IProductSubCategoryRepository productSubCategoryRepository
        {
            get
            {
                if (_productSubCategoryRepository == null)
                {
                    _productSubCategoryRepository = new ProductSubCategoryRepository(_adventureContext);
                }
                return _productSubCategoryRepository;
            }
        }

        public IProductCategoryRepository productCategoryRepository
        {
            get
            {
                if (_productCategoryRepository == null)
                {
                    _productCategoryRepository = new ProductCategoryRepository(_adventureContext);
                }
                return _productCategoryRepository;
            }
        }

        public void Save()
        {
            _adventureContext.SaveChanges();
        }


        public async Task SaveAsync()
        {
            await _adventureContext.SaveChangesAsync();
        }
    }
}
