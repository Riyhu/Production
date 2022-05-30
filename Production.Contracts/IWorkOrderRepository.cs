using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Production.Entities.Models;

namespace Production.Contracts
{
    public interface IWorkOrderRepository
    {
        Task<IEnumerable<WorkOrder>> GetAllWorkOrder(bool trackChanges);
        WorkOrderRouting GetWorkOrderByIDRouting(int id, bool trackChanges);
        //Task<Product> GetProductBy(int ProdID);
        void CreateWorkOrder(WorkOrder workOrder);
        void UpdateWorkOrder(WorkOrder workOrder);
        void DeleteWorkOrder(WorkOrder workOrder);
    }
}
