using Newtonsoft.Json;

namespace Conexa.Infra.Integracoes.OpenWeather.Entidades
{
    public class Erro
    {
        [JsonProperty("cod")]
        public string Cod { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
