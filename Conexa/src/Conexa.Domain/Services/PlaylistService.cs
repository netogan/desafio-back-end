using Conexa.Domain.Interfaces.Service;
using Conexa.Infra.Integracoes.OpenWeather.Config;
using Conexa.Infra.Integracoes.OpenWeather.Interfaces;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Conexa.Domain.Services
{
    public class PlaylistService : IPlaylistService
    {
        public IWeather _weatherService { get; set; }

        public PlaylistService(IWeather weatherService)
        {
            _weatherService = weatherService;
        }

        public Task<string> ObterPorCidade(string cidade)
        {

            var result = _weatherService.ObterClima(cidade);


            return Task.FromResult(string.Empty);
        }
    }
}
