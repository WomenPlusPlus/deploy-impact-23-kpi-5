using AutoMapper;
using Domain.Contracts.User;
using Domain.Entities.User;

namespace Api.Common
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserResponse>()
                .ForMember(r => r.Circle,
                    opt => opt.MapFrom(s => s.Circle))
                .ForMember(r => r.UserPermission,
                    opt => opt.MapFrom(s => s.UserPermission));

            CreateMap<UserPermission, UserPermissionRoleResponse>();
        }
    }
    



}