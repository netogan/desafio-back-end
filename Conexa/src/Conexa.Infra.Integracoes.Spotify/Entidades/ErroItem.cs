using Newtonsoft.Json;

namespace Conexa.Infra.Integracoes.Spotify.Entidades
{
    public class ErroItem
    {
        [JsonProperty("error")]
        public Error Error { get; set; }
    }
}
