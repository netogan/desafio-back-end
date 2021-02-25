using Conexa.Infra.Integracoes.Spotify.Interfaces;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var tracks = new List<FullTrack>();

            try
            {
                var client = await _auth.ObterClienteComToken();

                var searchRequest = new SearchRequest(SearchRequest.Types.Track, genero);

                searchRequest.Query = $"genre:[{genero}]";
                searchRequest.Market = "BR";
                searchRequest.Limit = 50;

                var searchResponse = await client.Search.Item(searchRequest);

                searchRequest.Offset = new Random().Next(0, 50);

                searchResponse = await client.Search.Item(searchRequest);

                tracks = searchResponse.Tracks?.Items;
            }
            catch (Exception ex)
            {
            }

            return tracks;
        }
    }
}
