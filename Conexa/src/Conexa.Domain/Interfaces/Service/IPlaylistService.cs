using SpotifyAPI.Web;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conexa.Domain.Interfaces.Service
{
    public interface IPlaylistService
    {
        Task<IEnumerable<SimpleTrack>> ObterPorClimaDaCidade(string cidade);
        Task<IEnumerable<SimpleTrack>> ObterPorClimaDaLocalizacao(decimal latitude, decimal longitude);
    }
}
