using System.Threading.Tasks;

namespace Conexa.Application.Interface
{
    public interface IPlaylistAppService
    {
        Task<string> ObterPorCidade(string cidade);
    }
}
