using AutoMapper;
using Conexa.Application.ViewModel;
using SpotifyAPI.Web;
using System.Collections.Generic;

namespace Conexa.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FullTrack, PlaylistResumidaViewModel>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Mp3Preview, opt => opt.MapFrom(src => src.PreviewUrl));
                //.ForMember(dest => dest.Artista, opt => opt.MapFrom(src => src.Artists))
                //.ForPath(dest => dest.Inventory.Warehouses, opt => opt.MapFrom(src => PreencherDeInventarioParaWarehouse(src.Inventario)));
        }

        //private string UnirArtistas(List<SimpleArtist> artistas)
        //{
        //    var nomesArtistas = artistas.
        //}
    }
}
