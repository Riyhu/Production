using Microsoft.EntityFrameworkCore;
using Production.Contracts;
using Production.Entities.AdventureContexts;
using Production.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production.Repository
{
    public class WorkOrderRepository : RepositoryBase<WorkOrder>,IWorkOrderRepository
    {
        public WorkOrderRepository(AdventureContext adventure) : base(adventure)
        {
        }

        public void CreateWorkOrder(WorkOrder workOrder)
        {
            Create(workOrder);
        }


        public void DeleteWorkOrder(WorkOrder workOrder)
        {
            Delete(workOrder);
        }

        public Task<IEnumerable<WorkOrder>> GetAllWorkOrder(bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public async Task<WorkOrder> GetWorkOrderByID(int id, bool trackChanges)
        {
            return await FindByCondition(x => x.WorkOrderID.Equals(id), trackChanges).SingleOrDefaultAsync();
        }

        public WorkOrderRouting GetWorkOrderByIDRouting(int id, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public void UpdateWorkOrder(WorkOrder workOrder)
        {
            Update(workOrder);
        }

    }
}
