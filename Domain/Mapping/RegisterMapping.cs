using AutoMapper;
using Domain.DTO.Auth;
using Domain.Entities.Auth;

namespace Domain.Mapping
{
    public class RegisterMapping : Profile
    {
        public RegisterMapping()
        {
            CreateMap<RegisterDTO, AppUser>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.MiddleName))
                .ForMember(dest => dest.MotherLastName, opt => opt.MapFrom(src => src.MotherLastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.NormalizedEmail,
                    opt => opt.MapFrom(src => src.Email.ToUpperInvariant()))
                .ForMember(dest => dest.NormalizedUserName,
                    opt => opt.MapFrom(src => src.Email.ToUpperInvariant()));
        }
    }
}
