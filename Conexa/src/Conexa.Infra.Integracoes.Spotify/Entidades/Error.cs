using Newtonsoft.Json;

namespace Conexa.Infra.Integracoes.Spotify.Entidades
{
    public class Error
    {
        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
