using System.Net;
using AnimeService.Constants;
using AnimeService.Interfaces.ServiceInterfaces;
using CoreApiResponse;
using Microsoft.AspNetCore.Mvc;

namespace AnimeService.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class AnimeController : BaseController
    {
        private readonly IAnimeService _animeService;

        public AnimeController(IAnimeService animeService)
        {
            this._animeService = animeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAnimesAsync()
        {
            try
            {
                var animes = await _animeService.GetAllAsync();
                if (animes.Any())
                {
                    return CustomResult(ResponseMessage.SUCCESSFUL, animes, HttpStatusCode.OK);
                }
                return CustomResult(ResponseMessage.EMPTY, HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetAnimeByIdAsync(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var anime = await _animeService.GetByIdAsync(id);
                    if (anime != null)
                    {
                        return CustomResult(ResponseMessage.SUCCESSFUL, anime, HttpStatusCode.OK);
                    }
                    return CustomResult(ResponseMessage.DATA_NOT_FOUND, HttpStatusCode.NotFound);
                }
                catch (Exception ex)
                {
                    return CustomResult(ex.Message, HttpStatusCode.BadRequest);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
