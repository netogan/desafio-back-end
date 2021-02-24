using System.Threading.Tasks;

namespace Conexa.Domain.Interfaces.Service
{
    public interface IPlaylistService
    {
        Task<string> ObterPorCidade(string cidade);
    }
}
