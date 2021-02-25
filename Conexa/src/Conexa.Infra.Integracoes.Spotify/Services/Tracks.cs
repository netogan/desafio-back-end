using Conexa.Infra.Integracoes.Spotify.Entidades;
using Conexa.Infra.Integracoes.Spotify.Interfaces;
using Newtonsoft.Json;
using RestSharp;
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

        public async Task<List<SimpleTrack>> ObterPorGenero(string genero)
        {
            var tracks = new List<FullTrack>();

            var recommendation = new Recomendation();

            try
            {
                var token = await _auth.ObterToken();

                var _client = new RestClient("https://api.spotify.com/v1");
                var _request = new RestRequest(Method.GET);

                _request.Resource = $"/recommendations";

                _request.AddParameter("market", "BR");
                _request.AddParameter("seed_genres", genero.ToLower());

                _request.AddHeader("Authorization", $"Bearer {token}");

                var response = await _client.ExecuteAsync(_request);

                if (response.IsSuccessful)
                    recommendation = JsonConvert.DeserializeObject<Recomendation>(response.Content);
                else
                    recommendation.ErroItem = JsonConvert.DeserializeObject<ErroItem>(response.Content);
            }
            catch (Exception ex)
            {
            }

            return recommendation.Tracks;
        }
    }
}
