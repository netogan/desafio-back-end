﻿using SpotifyAPI.Web;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conexa.Infra.Integracoes.Spotify.Interfaces
{
    public interface ITracks
    {
        Task<List<SimpleTrack>> ObterPorGenero(string genero);
    }
}
