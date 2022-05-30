using Production.Entities.DTO;
using Production.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production.Contracts
{
    public interface IServiceManager
    {

        Task<Product> AddProductInformation(ProductWorkOrderDTO productWorkOrderDTO);
        Task<WorkOrder> AddtoOrder(WorkOrderDTO workOrderDTO);
        Task<IEnumerable<WorkOrderRouting>> GetAllOrderRouting(bool trackChanges);

        Task<bool> SaveAll(PhotoDTO photoDTO);
        Tuple<int, WorkOrder, string> AddtoOrders(int Id, short quantity, string custId, int employeeId, bool trackChanges);
        
        Tuple<int, ScrapReason, string> Reasoon(int id);
       // Tuple<int, Order, string> ShipOrder(int id, ShipperDTO shipperDTO);
    }
}
