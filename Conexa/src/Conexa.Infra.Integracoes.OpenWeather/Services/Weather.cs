using Conexa.Infra.Integracoes.OpenWeather.Config;
using Conexa.Infra.Integracoes.OpenWeather.Entidades;
using Conexa.Infra.Integracoes.OpenWeather.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
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

        public async Task<Clima> ObterTemperaturaPorCidade(string cidade)
        {
            var _client = new RestClient(_openWeatherConfig.Url);
            var _request = new RestRequest(Method.GET);

            var clima = new Clima();

            _request.Resource = $"/data/2.5/weather";

            _request.AddParameter("q", cidade);
            _request.AddParameter("appid", _openWeatherConfig.AppId);
            _request.AddParameter("units", "metric");

            try
            {
                var response = await _client.ExecuteAsync(_request);

                if (response.IsSuccessful)
                    clima = JsonConvert.DeserializeObject<Clima>(response.Content);
                else
                    clima.Erro = JsonConvert.DeserializeObject<Erro>(response.Content);
            }
            catch (Exception ex)
            {
            }

            return clima;
        }

        public async Task<Clima> ObterTemperaturaPorLocalizacao(decimal latitude, decimal longitude)
        {
            var _client = new RestClient(_openWeatherConfig.Url);
            var _request = new RestRequest(Method.GET);

            var clima = new Clima();

            _request.Resource = $"/data/2.5/weather";

            _request.AddParameter("lat", latitude);
            _request.AddParameter("lon", longitude);
            _request.AddParameter("appid", _openWeatherConfig.AppId);
            _request.AddParameter("units", "metric");

            try
            {
                var response = await _client.ExecuteAsync(_request);

                if (response.IsSuccessful)
                    clima = JsonConvert.DeserializeObject<Clima>(response.Content);
                else
                    clima.Erro = JsonConvert.DeserializeObject<Erro>(response.Content);
            }
            catch (Exception ex)
            {
            }

            return clima;
        }
    }
}
