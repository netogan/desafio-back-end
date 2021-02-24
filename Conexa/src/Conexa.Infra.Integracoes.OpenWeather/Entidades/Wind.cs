using Newtonsoft.Json;

namespace Conexa.Infra.Integracoes.OpenWeather.Entidades
{
    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("deg")]
        public long Deg { get; set; }
    }
}
