using AutoMapper;
using Entity.Dto.Default;
using Entity.Dto.Select;
using Entity.Model;

namespace Web.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            //Modulo de seguridad
            CreateMap<Rol,RolSelectDto>().ReverseMap();
            CreateMap<Rol, RolDto>().ReverseMap();


            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserSelectDto>().ReverseMap();

            CreateMap<RolUser, RolUserSelectDto>().ReverseMap();
            CreateMap<RolUser, RolUserDto>().ReverseMap();

            CreateMap<Form, FormSelectDto>().ReverseMap();
            CreateMap<Form, FormDto>().ReverseMap();

            CreateMap<Permission, PermissionSelectDto>().ReverseMap();
            CreateMap<Permission, PermissionDto>().ReverseMap();

            CreateMap<RolFormPermission, RolFormPermissionSelectDto>().ReverseMap();
            CreateMap<RolFormPermission, RolFormPermissionDto>().ReverseMap();

            CreateMap<Module, ModuleSelectDto>().ReverseMap();
            CreateMap<Module, ModuleDto>().ReverseMap();

            CreateMap<FormModule, FormModuleSelectDto>().ReverseMap();
            CreateMap<FormModule, FormModuleDto>().ReverseMap();

            CreateMap<Person, PersonSelectDto>().ReverseMap();
            CreateMap<Person, PersonDto>().ReverseMap();

        }
    }
}
