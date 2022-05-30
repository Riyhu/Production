using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production.Contracts
{
    public interface IRepositoryManager
    {
        IProductRepository productRepository { get; }
        IvProductRepository vProductRepository { get; }
        IAddProductRepository Product { get; }
        IProductModelRepository productModelRepository { get; }
        IUnitMeasureRepository unitMeasureRepository { get; }
        IProductSubCategoryRepository productSubCategoryRepository { get; }
        IProductCategoryRepository productCategoryRepository { get; }

        void Save();
        Task SaveAsync();
    }
}
