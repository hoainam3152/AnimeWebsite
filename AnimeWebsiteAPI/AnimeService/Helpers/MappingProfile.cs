using AnimeService.DTOs.Response;
using AnimeService.Entities;
using AutoMapper;

namespace AnimeService.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Anime, AnimeResponse>();
        }
    }
}
