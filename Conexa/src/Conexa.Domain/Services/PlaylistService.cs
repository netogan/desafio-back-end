using Conexa.Domain.Interfaces.Service;
using Conexa.Infra.Integracoes.OpenWeather.Interfaces;
using Conexa.Infra.Integracoes.Spotify.Interfaces;
using Conexa.Infra.Integracoes.Spotify.Enum;
using SpotifyAPI.Web;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Conexa.Domain.Services
{
    public class PlaylistService : IPlaylistService
    {
        public IWeather _weatherService { get; set; }
        public ITracks _tracksService { get; set; }

        public PlaylistService(IWeather weatherService, ITracks tracksService)
        {
            _weatherService = weatherService;
            _tracksService = tracksService;
        }

        public async Task<IEnumerable<SimpleTrack>> ObterPorCidade(string cidade)
        {
            var clima = await _weatherService.ObterPorCidade(cidade);

            var tracks = new List<SimpleTrack>();

            switch (clima.Main.Temp)
            {
                case double n when n > 30:
                    tracks = await _tracksService.ObterPorGenero(nameof(TipoMusica.Party));
                    break;
                case double n when n >= 15 && n <= 30:
                    tracks = await _tracksService.ObterPorGenero(nameof(TipoMusica.Pop));
                    break;
                case double n when n >= 10 && n <= 14:
                    tracks = await _tracksService.ObterPorGenero(nameof(TipoMusica.Rock));
                    break;
                default:
                    tracks = await _tracksService.ObterPorGenero(nameof(TipoMusica.Classical));
                    break;
            }

            return tracks;
        }
    }
}
