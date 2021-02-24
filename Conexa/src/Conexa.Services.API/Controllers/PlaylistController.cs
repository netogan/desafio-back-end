using Conexa.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Conexa.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        public IPlaylistAppService _playlistAppService { get; set; }

        public PlaylistController(IPlaylistAppService playlistAppService)
        {
            _playlistAppService = playlistAppService;
        }

        [HttpGet]
        [Route("ObterPorCidade")]
        public async Task<ActionResult> ObterPorCidade(string cidade)
        {
            var ret = await _playlistAppService.ObterPorCidade(cidade);

            if (ret == null)
                return NotFound();

            return Ok(ret);
        }
    }
}
