using Conexa.Infra.Integracoes.Spotify.Interfaces;
using SpotifyAPI.Web;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conexa.Infra.Integracoes.Spotify.Services
{
    public class Tracks : ITracks
    {
        private readonly IAuth _auth;

        public Tracks(IAuth auth)
        {
            _auth = auth;
        }

        public async Task<List<FullTrack>> ObterPorGenero(string genero)
        {
            var client = await _auth.ObterClienteComToken();

            var searchRequest = new SearchRequest(SearchRequest.Types.Track, genero);

            searchRequest.Query = $"genre={genero}";

            var searchResponse = await client.Search.Item(searchRequest);

            return searchResponse.Tracks.Items;
        }
    }
}
