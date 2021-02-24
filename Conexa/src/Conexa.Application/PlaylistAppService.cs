using AutoMapper;
using Conexa.Application.Interface;
using Conexa.Domain.Interfaces.Service;
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

        public async Task<string> ObterPorCidade(string cidade)
        {
            var ret = await _playlistService.ObterPorCidade(cidade);

            return ret;

            //return _mapper.Map<ProdutoViewModel>(ret);
        }
    }
}
