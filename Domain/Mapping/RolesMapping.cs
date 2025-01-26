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
                .ForMember(dest => dest.Permissions, opt => opt.MapFrom(src => src.RolePermissions))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.createdBy, opt => opt.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.updatedBy, opt => opt.MapFrom(src => src.UpdatedBy))
                .ForMember(dest => dest.createdAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.updatedAt, opt => opt.MapFrom(src => src.UpdatedAt));


            CreateMap<RolePermission, PermissionDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Permission.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Permission.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Permission.Description));

            CreateMap<AppRole, RoleDTO>();
        }
    }
}
