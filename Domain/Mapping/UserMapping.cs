using AutoMapper;
using Domain.DTO.Users;
using Domain.Entities.Auth;

namespace Domain.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping() 
        {
            CreateMap<AppUser, GetUserDTO>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber)); 
        }
    }
}
