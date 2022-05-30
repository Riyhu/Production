using AutoMapper;
using Production.Entities.DTO;
using Production.Entities.Models;
using ProductionWebApi.Models;

namespace ProductionWebApi.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();

            CreateMap<vSearchProduct, ProductDTO>().ReverseMap();

            CreateMap<Product, AddProductDTO>().ReverseMap();

            CreateMap<Product, UpdateProductDTO>().ReverseMap();

            CreateMap<WorkOrder, AddWorkOrderDTO>().ReverseMap();
            
            CreateMap<Product, ProductWorkOrderDTO>().ReverseMap();

            CreateMap<WorkOrderRouting, WorkOrderRoutingDTO>().ReverseMap();

            CreateMap<ProductPhoto, PhotoDTO>().ReverseMap();
        }
    }
}
