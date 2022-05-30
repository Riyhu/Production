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
        private IProductRepository _productRepository;
        private IWorkOrderRepository _workOrderRepository;
        private IProductWorkOrderRepository _productWorkOrderRepository;
        private IWorkOrderRoutingRepository _workOrderRoutingRepository;
        private IPhotoRepository _photoRepository;
        private IProductProductPhotoRepository _productProductPhotoRepository;
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

        

        public IProductRepository Product
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

        public IWorkOrderRepository WorkOrderRepository
        {
            get
            {
                if (_workOrderRepository == null)
                {
                    _workOrderRepository = new WorkOrderRepository(_adventureContext);
                }
                return _workOrderRepository;
            }
        }

        public IProductWorkOrderRepository ProductWorkOrderRepository
        {
            get
            {
                if (_productWorkOrderRepository == null)
                {
                    _productWorkOrderRepository = new ProductWorkOrderRepository(_adventureContext);
                }
                return _productWorkOrderRepository;
            }
        }

        public IWorkOrderRoutingRepository WorkOrderRoutingRepository
        {
            get
            {
                if (_workOrderRoutingRepository == null)
                {
                    _workOrderRoutingRepository = new WorkOrderRoutingRepository(_adventureContext);
                }
                return _workOrderRoutingRepository;
            }
        }

        public IPhotoRepository photoRepository
        {
            get
            {
                if (_photoRepository == null)
                {
                    _photoRepository = new PhotoRepository(_adventureContext);
                }
                return _photoRepository;
            }
        }

        public IProductProductPhotoRepository ProductProductPhotoRepository
        {
            get
            {
                if (_productProductPhotoRepository == null)
                {
                    _productProductPhotoRepository = new ProductProductPhotoRepository(_adventureContext);
                }
                return _productProductPhotoRepository;
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
