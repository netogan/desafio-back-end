using AutoMapper;

namespace Conexa.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<Produto, ProdutoViewModel>()
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Nome))
            //    .ForPath(dest => dest.Inventory.Warehouses, opt => opt.MapFrom(src => PreencherDeInventarioParaWarehouse(src.Inventario)));
        }
    }
}
