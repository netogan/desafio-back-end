using Conexa.Infra.Integracoes.OpenWeather.Config;
using Conexa.Infra.Integracoes.OpenWeather.Entidades;
using Conexa.Infra.Integracoes.OpenWeather.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

namespace Conexa.Infra.Integracoes.OpenWeather.Services
{
    public class Weather : IWeather
    {
        private OpenWeatherConfig _openWeatherConfig;

        public Weather(IOptions<OpenWeatherConfig> openWeatherConfig)
        {
            _openWeatherConfig = openWeatherConfig.Value;
        }

        public async Task<Clima> ObterClima(string cidade)
        {
            var _client = new RestClient(_openWeatherConfig.Url);
            var _request = new RestRequest(Method.GET);

            _request.Resource = $"/data/2.5/weather";

            _request.AddParameter("q", cidade);
            _request.AddParameter("appid", _openWeatherConfig.AppId);
            _request.AddParameter("units", "metric");

            var response = await _client.ExecuteAsync(_request);

            var clima = new Clima();

            if (response.IsSuccessful)
                clima = JsonConvert.DeserializeObject<Clima>(response.Content);
            else
                clima.Erro = JsonConvert.DeserializeObject<Erro>(response.Content);

            return clima;
        }
    }
}
