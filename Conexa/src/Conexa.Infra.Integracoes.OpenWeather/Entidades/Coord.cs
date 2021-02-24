using Newtonsoft.Json;

namespace Conexa.Infra.Integracoes.OpenWeather.Entidades
{
    public class Coord
    {
        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }
    }
}
