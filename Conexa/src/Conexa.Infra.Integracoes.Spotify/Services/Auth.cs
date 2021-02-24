using Conexa.Infra.Integracoes.Spotify.Config;
using Conexa.Infra.Integracoes.Spotify.Interfaces;
using Microsoft.Extensions.Options;
using SpotifyAPI.Web;
using System.Threading.Tasks;

namespace Conexa.Infra.Integracoes.Spotify.Services
{
    public class Auth : IAuth
    {
        private SpotifyConfig _spotifyConfig;

        public Auth(IOptions<SpotifyConfig> spotifyConfig)
        {
            _spotifyConfig = spotifyConfig.Value;
        }

        public async Task<SpotifyClient> ObterClienteComToken()
        {
            var config = SpotifyClientConfig.CreateDefault();

            var request = new ClientCredentialsRequest(_spotifyConfig.ClientId, _spotifyConfig.Secret);

            var response = await new OAuthClient(config).RequestToken(request);

            var client = new SpotifyClient(config.WithToken(response.AccessToken));

            return client;
        }
    }
}
