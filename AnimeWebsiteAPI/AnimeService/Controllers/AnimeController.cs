using System.Net;
using AnimeService.Constants;
using AnimeService.DTOs.Requests;
using AnimeService.Interfaces.ServiceInterfaces;
using CoreApiResponse;
using Microsoft.AspNetCore.Mvc;

namespace AnimeService.Controllers
{
    [Route("v1/api/animes")]
    [ApiController]
    public class AnimeController : BaseController
    {
        private readonly IAnimeService _animeService;

        public AnimeController(IAnimeService animeService)
        {
            this._animeService = animeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAnimesAsync(int pageIndex, int pageSize, string? sortBy, string? order, string? select)
        {
            try
            {
                var pagedAnimes = await _animeService.GetItemsAsync(pageIndex, pageSize, sortBy, order, select);
                if (pagedAnimes != null)
                {
                    return Ok(pagedAnimes);
                }
                return NotFound(ResponseMessage.EMPTY);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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

        [HttpGet("search")]
        public async Task<IActionResult> SearchAnimesAsync(string q)
        {
            try
            {
                var anime = await _animeService.SearchAsync(q);
                if (anime.Any())
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
    }
}
