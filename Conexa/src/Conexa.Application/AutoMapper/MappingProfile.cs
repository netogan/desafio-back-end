using AutoMapper;
using Conexa.Application.ViewModel;
using SpotifyAPI.Web;
using System.Collections.Generic;
using System.Linq;

namespace Conexa.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FullTrack, PlaylistResumidaViewModel>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Name))
                .ForPath(dest => dest.Artista, opt => opt.MapFrom(src => PreencherArtistas(src.Artists)));

            CreateMap<SimpleTrack, PlaylistResumidaViewModel>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Name))
                .ForPath(dest => dest.Artista, opt => opt.MapFrom(src => PreencherArtistas(src.Artists)));
        }

        private string PreencherArtistas(List<SimpleArtist> artistas)
        {
            if (artistas.Any())
                return artistas.Select(x => x.Name).Aggregate((current, next) => current + " | " + next);
            else
                return string.Empty;
        }
    }
}
