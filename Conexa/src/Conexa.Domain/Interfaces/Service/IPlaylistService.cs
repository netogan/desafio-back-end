﻿using SpotifyAPI.Web;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conexa.Domain.Interfaces.Service
{
    public interface IPlaylistService
    {
        Task<IEnumerable<SimpleTrack>> ObterPorCidade(string cidade);
    }
}
