using Newtonsoft.Json;

namespace Conexa.Infra.Integracoes.OpenWeather.Entidades
{
    public class Clouds
    {
        [JsonProperty("all")]
        public long All { get; set; }
    }
}
