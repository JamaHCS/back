using AutoMapper;
using Domain.DTO.Users;
using Domain.Entities.Auth;
using Domain.Entities.Roles;

namespace Domain.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<AppUser, GetUserDTO>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Roles, opt => opt.Ignore());

            CreateMap<AppRole, UserRoleDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
