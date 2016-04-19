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
          RegisterMappingsProvider();
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

      private static void RegisterMappingsProvider()
      {
          Mapper.CreateMap<Model.Provider, ProviderDTO>();
          Mapper.CreateMap<ProviderDTO, Model.Provider>();

          Mapper.CreateMap<ProviderDTO, Model.Provider>()
              .ForMember("Id", opt => opt.MapFrom(src => src.id))
              .ForMember("Name", opt => opt.MapFrom(src => src.name))
              .ForMember("Address", opt => opt.MapFrom(src => src.address))
              .ForMember("Telephone", opt => opt.MapFrom(src => src.telephone))
              .ForMember("Description", opt => opt.MapFrom(src => src.description));

          Mapper.CreateMap<Model.Provider, ProviderDTO>()
              .ForMember("id", opt => opt.MapFrom(src => src.Id))
              .ForMember("name", opt => opt.MapFrom(src => src.Name))
              .ForMember("address", opt => opt.MapFrom(src => src.Address))
              .ForMember("telephone", opt => opt.MapFrom(src => src.Telephone))
              .ForMember("description", opt => opt.MapFrom(src => src.Description));
      }

  }
}
