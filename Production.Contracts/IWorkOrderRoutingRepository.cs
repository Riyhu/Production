using Production.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production.Contracts
{
    public interface IWorkOrderRoutingRepository
    {
        Task<IEnumerable<WorkOrderRouting>> GetAllOrderRouting(bool trackChanges);
    }
}
