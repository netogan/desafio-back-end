using Conexa.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
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
        [Route("ObterPorClimaDaCidade")]
        public async Task<ActionResult> ObterPorClimaDaCidade(string cidade)
        {
            var ret = await _playlistAppService.ObterPorClimaDaCidade(cidade);

            if (ret == null || ret.Count() == 0)
                return NotFound(string.Empty);

            return Ok(ret);
        }


        [HttpGet]
        [Route("ObterPorClimaDaLocalizacao")]
        public async Task<ActionResult> ObterPorClimaDaLocalizacao(decimal latitude, decimal longitude)
        {
            var ret = await _playlistAppService.ObterPorClimaDaLocalizacao(latitude, longitude);

            if (ret == null || ret.Count() == 0)
                return NotFound(string.Empty);

            return Ok(ret);
        }
    }
}
