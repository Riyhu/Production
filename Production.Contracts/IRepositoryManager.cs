using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production.Contracts
{
    public interface IRepositoryManager
    {
        
        IvProductRepository vProductRepository { get; }
        IProductRepository Product { get; }
        IWorkOrderRepository WorkOrderRepository { get; }
        IProductWorkOrderRepository ProductWorkOrderRepository { get; }
        IWorkOrderRoutingRepository WorkOrderRoutingRepository { get; }
        IPhotoRepository photoRepository { get; }
        IProductProductPhotoRepository ProductProductPhotoRepository { get; }
        void Save();
        Task SaveAsync();
    }
}
