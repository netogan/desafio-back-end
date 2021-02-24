using Conexa.Application.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conexa.Application.Interface
{
    public interface IPlaylistAppService
    {
        Task<IEnumerable<PlaylistResumidaViewModel>> ObterPorCidade(string cidade);
    }
}
