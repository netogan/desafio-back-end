using SpotifyAPI.Web;
using System.Threading.Tasks;

namespace Conexa.Infra.Integracoes.Spotify.Interfaces
{
    public interface IAuth
    {
        Task<SpotifyClient> ObterClienteComToken();
        Task<string> ObterToken();
    }
}
