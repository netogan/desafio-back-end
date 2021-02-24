using AutoMapper;
using Conexa.Application.Interface;
using Conexa.Application.ViewModel;
using Conexa.Domain.Interfaces.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conexa.Application
{
    public class PlaylistAppService : IPlaylistAppService
    {
        public IPlaylistService _playlistService { get; set; }
        private readonly IMapper _mapper;

        public PlaylistAppService(IPlaylistService playlistService, IMapper mapper)
        {
            _playlistService = playlistService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlaylistResumidaViewModel>> ObterPorCidade(string cidade)
        {
            var musicas = await _playlistService.ObterPorCidade(cidade);

            var playlistViewModel = _mapper.Map<IEnumerable<PlaylistResumidaViewModel>>(musicas);

            return playlistViewModel;
        }
    }
}
