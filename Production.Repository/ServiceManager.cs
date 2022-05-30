using Production.Contracts;
using Production.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Production.Entities.DTO;

namespace Production.Repository
{
    public class ServiceManager : IServiceManager
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        public ServiceManager()
        {
        }

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper,ILoggerManager logger)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _logger = logger;
        }

        public Task<ProductPhoto> AddPhoto(PhotoDTO photoDTO)
        {
            //Product product = new Product();
            //ProductPhoto productPhoto = new ProductPhoto();
            //ProductProductPhoto productPhoto2 = new ProductProductPhoto();
            throw new NotImplementedException();
        }

        public async Task<Product> AddProductInformation(ProductWorkOrderDTO productWorkOrderDTO)
        {
            Product product = new Product();
            product.ProductID = productWorkOrderDTO.ProductID;
            product.Name = productWorkOrderDTO.Name;
            product.ProductNumber = productWorkOrderDTO.ProductNumber;
            product.DaysToManufacture = productWorkOrderDTO.DaytoManufacture;
            product.ListPrice = productWorkOrderDTO.ListPrice;
            _repositoryManager.Product.CreateProduct(product);
            await _repositoryManager.SaveAsync();
            return product;
        }

        public async Task<WorkOrder> AddtoOrder(WorkOrderDTO workOrderDTO)
        {
            WorkOrder workOrder = new WorkOrder();
            workOrder.OrderQty = workOrderDTO.OrderQty;
            workOrder.StockedQty = workOrderDTO.StockedQty;
            workOrder.StartDate = workOrderDTO.StartDate;
            workOrder.EndDate = workOrderDTO.EndDate;
            workOrder.DueDate = workOrderDTO.DueDate;
            _repositoryManager.WorkOrderRepository.CreateWorkOrder(workOrder);
            await _repositoryManager.SaveAsync();
            return workOrder;
        }

        public Tuple<int, WorkOrder, string> AddtoOrders(int Id, short quantity, string custId, int employeeId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<WorkOrderRouting>> GetAllOrderRouting(bool trackChanges)
        {
            //IEnumerable<WorkOrderRouting> routings = null;
            try
            {
                IEnumerable<WorkOrderRouting> routings1 = await _repositoryManager.WorkOrderRoutingRepository.GetAllOrderRouting(trackChanges: false);
                //IEnumerable<WorkOrderRouting> a = _mapper.Map<WorkOrderRoutingDTO>(routings1);
                return routings1;
            }
            catch (Exception e)
            {
                _logger.LogInfo(e.Message);
                return null;
            }
        }

        public Tuple<int, ScrapReason, string> Reasoon(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAll(PhotoDTO photoDTO)
        {
            throw new NotImplementedException();
        }
    }
}
