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
    public class WorkOrderRoutingRepository : RepositoryBase<WorkOrderRouting>, IWorkOrderRoutingRepository
    {
        public WorkOrderRoutingRepository(AdventureContext adventure) : base(adventure)
        {
        }

        public async Task<IEnumerable<WorkOrderRouting>> GetAllOrderRouting(bool trackChanges)
        {
            return await FindAll(trackChanges)
            .OrderBy(x => x.WorkOrderID)
            .ToListAsync();
        }
    }
}
