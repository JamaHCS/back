using AutoMapper;
using Domain.DTO.Roles;
using Domain.Entities.Roles;

namespace Domain.Mapping
{
    public class RolesMapping : Profile
    {
        public RolesMapping() 
        {
            CreateMap<AppRole, RoleWithPermissions>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Permissions, opt => opt.MapFrom(src => src.RolePermissions));

            CreateMap<RolePermission, PermissionDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Permission.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Permission.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Permission.Description));
        }
    }
}
