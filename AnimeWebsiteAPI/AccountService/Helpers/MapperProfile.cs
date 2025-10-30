using AccountService.DTOs.Requests;
using AccountService.DTOs.Response;
using AccountService.Entities;
using AutoMapper;

namespace AccountService.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Role, RoleResponse>();
        }
    }
}
