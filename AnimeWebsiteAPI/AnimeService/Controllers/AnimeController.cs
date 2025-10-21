using AnimeService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnimeService.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class AnimeController : Controller
    {
        private readonly AnimeServiceCore _animeService;

        public AnimeController(AnimeServiceCore animeService)
        {
            this._animeService = animeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAnimesAsync()
        {
            try
            {
                var anime = await _animeService.GetAllAnimesAsync();
                if (anime == null || !anime.Any())
                {
                    return NotFound();
                }
                return Ok(anime);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetAnimeByIdAsync(int id)
        {
            try
            {
                var anime = await _animeService.GetAnimeByIdAsync(id);
                if (anime == null)
                {
                    return NotFound();
                }
                return Ok(anime);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
