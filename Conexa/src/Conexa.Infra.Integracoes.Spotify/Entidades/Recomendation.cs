using SpotifyAPI.Web;

namespace Conexa.Infra.Integracoes.Spotify.Entidades
{
    public class Recomendation : RecommendationsResponse
    {
        public ErroItem ErroItem { get; set; }
    }
}
