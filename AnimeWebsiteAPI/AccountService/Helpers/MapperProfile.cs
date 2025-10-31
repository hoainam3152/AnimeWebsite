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
            //Role Service
            CreateMap<Role, RoleResponse>();

            //User Service
            CreateMap<UserProfile, UserProfileResponse>();

            //UserRole Service
            CreateMap<UserRoleRequest, UserRole>();
            CreateMap<UserRole, UserRoleResponse>();
        }
    }
}
