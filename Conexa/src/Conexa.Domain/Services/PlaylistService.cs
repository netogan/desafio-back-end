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

        public async Task<IEnumerable<SimpleTrack>> ObterPorClimaDaCidade(string cidade)
        {
            var clima = await _weatherService.ObterTemperaturaPorCidade(cidade);

            if (clima.Main?.Temp == null || clima.Main.Temp == double.MinValue)
                return null;

            var tracks = await RetornarMusicasPorTemperatura(clima.Main.Temp);

            return tracks;
        }

        public async Task<IEnumerable<SimpleTrack>> ObterPorClimaDaLocalizacao(decimal latitude, decimal longitude)
        {
            var clima = await _weatherService.ObterTemperaturaPorLocalizacao(latitude, longitude);

            if (clima.Main?.Temp == null || clima.Main.Temp == double.MinValue)
                return null;

            var tracks = await RetornarMusicasPorTemperatura(clima.Main.Temp);

            return tracks;
        }

        private async Task<List<SimpleTrack>> RetornarMusicasPorTemperatura(double temperatura)
        {
            var tracks = new List<SimpleTrack>();

            switch (temperatura)
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
