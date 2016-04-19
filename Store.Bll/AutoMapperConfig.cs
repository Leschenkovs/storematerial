using AutoMapper;
using Store.Model;
using Store.Model.DTOObjects;

namespace Store.Bll
{
  public class AutoMapperConfig
  {
	  public static void RegisterAllObjects()
	  {
		  RegisterMappingsUser();
		  RegisterMappingsRole();
	  }

	  private static void RegisterMappingsUser()
	  {
		 Mapper.CreateMap<User, UserDTO>();
		 Mapper.CreateMap<UserDTO, User>();

		 Mapper.CreateMap<UserDTO, User>()
					.ForMember("Id", opt => opt.MapFrom(src => src.id))
					 .ForMember("Tn", opt => opt.MapFrom(src => src.tn))
					 .ForMember("Fio", opt => opt.MapFrom(src => src.fio))
					 .ForMember("Department", opt => opt.MapFrom(src => src.department))
					 .ForMember("Position", opt => opt.MapFrom(src => src.position))
					 .ForMember("RoleId", opt => opt.MapFrom(src => src.roleId));

		 Mapper.CreateMap<User, UserDTO>()
			 .ForMember("id", opt => opt.MapFrom(src => src.Id))
			 .ForMember("tn", opt => opt.MapFrom(src => src.Tn))
			 .ForMember("fio", opt => opt.MapFrom(src => src.Fio))
			 .ForMember("department", opt => opt.MapFrom(src => src.Department))
			 .ForMember("position", opt => opt.MapFrom(src => src.Position))
			 .ForMember("roleName", opt => opt.MapFrom(src => src.RoleObj.Name));
	  }

	  private static void RegisterMappingsRole()
	  {
		 Mapper.CreateMap<Role, RoleDTO>();
		 Mapper.CreateMap<RoleDTO, Role>();
	  }
  }
}
