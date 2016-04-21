using System.Linq;
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
		  RegisterMappingsCostumer();
		  RegisterMappingsUnit();
		  RegisterMappingsSupply();
		  RegisterMappingsExperse();
		  RegisterMappingsPrice();
		  RegisterMappingsMaterialInStore();
		  RegisterMappingsKindMaterial();
		  RegisterMappingsUnitMaterial();
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
      }

      private static void RegisterMappingsCostumer()
      {
          Mapper.CreateMap<Costumer, CostumerDTO>();
          Mapper.CreateMap<CostumerDTO, Costumer>();

      }

      private static void RegisterMappingsUnit()
      {
          Mapper.CreateMap<Unit, UnitDTO>();
          Mapper.CreateMap<UnitDTO, Unit>();
      }

	  private static void RegisterMappingsUser()
	  {
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

      private static void RegisterMappingsKindMaterial()
      {
          Mapper.CreateMap<KindMaterialDTO, KindMaterial>()
              .ForMember("Id", opt => opt.MapFrom(src => src.id))
              .ForMember("Articul", opt => opt.MapFrom(src => src.articul))
              .ForMember("Name", opt => opt.MapFrom(src => src.name));

          Mapper.CreateMap<KindMaterial, KindMaterialDTO>()
              .ForMember("id", opt => opt.MapFrom(src => src.Id))
              .ForMember("articul", opt => opt.MapFrom(src => src.Articul))
              .ForMember("name", opt => opt.MapFrom(src => src.Name))
              .ForMember("units", opt => opt.MapFrom(src => src.UnitMaterials.Aggregate("/", (current, a) => current + a.UnitObj.Name)));
      }

      private static void RegisterMappingsSupply()
      {
          Mapper.CreateMap<CreateSupplyDTO, Supply>()
              .ForMember("Id", opt => opt.MapFrom(src => src.id))
              .ForMember("Count", opt => opt.MapFrom(src => src.count))
              .ForMember("Ttn", opt => opt.MapFrom(src => src.ttn))
              .ForMember("PriceSupply", opt => opt.MapFrom(src => src.priceSupply))
              .ForMember("ProviderId", opt => opt.MapFrom(src => src.providerId))
              .ForMember("MaterialInStoreId", opt => opt.MapFrom(src => src.unitMaterialId));

          Mapper.CreateMap<Supply, SupplyDTO>()
              .ForMember("id", opt => opt.MapFrom(src => src.Id))
              .ForMember("count", opt => opt.MapFrom(src => src.Count))
              .ForMember("ttn", opt => opt.MapFrom(src => src.Ttn))
              .ForMember("kindMaterialName", opt => opt.MapFrom(src => src.MaterialInStoreObj.UnitMaterialObj.KindMaterialObj.Name))
              .ForMember("unitName", opt => opt.MapFrom(src => src.MaterialInStoreObj.UnitMaterialObj.UnitObj.ShortName))
              .ForMember("providerName", opt => opt.MapFrom(src => src.ProviderObj.Name))
              .ForMember("priceSupply", opt => opt.MapFrom(src => src.PriceSupply))
			  .ForMember("data", opt => opt.MapFrom(src => src.AddedDate));
      }

      private static void RegisterMappingsExperse()
      {
          Mapper.CreateMap<MaterialInStore, CreateExperseDTO>()
              .ForMember("materialInStoreId", opt => opt.MapFrom(src => src.UnitMaterialId))
              .ForMember("kindMaterialName", opt => opt.MapFrom(src => src.UnitMaterialObj.KindMaterialObj.Name))
              .ForMember("unitShortName", opt => opt.MapFrom(src => src.UnitMaterialObj.UnitObj.ShortName));

          Mapper.CreateMap<CreateExperseDTO, Experse>()
              .ForMember("Id", opt => opt.MapFrom(src => src.id))
              .ForMember("Count", opt => opt.MapFrom(src => src.count))
              .ForMember("CostumerId", opt => opt.MapFrom(src => src.costumerId))
              .ForMember("MaterialInStoreId", opt => opt.MapFrom(src => src.materialInStoreId))
              .ForMember("UserId", opt => opt.MapFrom(src => src.userId));

          Mapper.CreateMap<Experse, ExperseDTO>()
              .ForMember("id", opt => opt.MapFrom(src => src.Id))
              .ForMember("count", opt => opt.MapFrom(src => src.Count))
              .ForMember("kindMaterialName", opt => opt.MapFrom(src => src.MaterialInStoreObj.UnitMaterialObj.KindMaterialObj.Name))
              .ForMember("costumerName", opt => opt.MapFrom(src => src.CostumerObj.Name))
              .ForMember("userFio", opt => opt.MapFrom(src => src.UserObj.Fio))
              .ForMember("data", opt => opt.MapFrom(src => src.AddedDate))
             .ForMember("materialInStoreId", opt => opt.MapFrom(src => src.MaterialInStoreId));
      }

      private static void RegisterMappingsPrice()
      {
          Mapper.CreateMap<PriceDTO, Price>()
              .ForMember("Id", opt => opt.MapFrom(src => src.id))
              .ForMember("PriceValue", opt => opt.MapFrom(src => src.priceValue))
              .ForMember("DateOt", opt => opt.MapFrom(src => src.dateOt))
              .ForMember("DateDo", opt => opt.MapFrom(src => src.dateDo))
              .ForMember("MaterialInStoreId", opt => opt.MapFrom(src => src.materialInStoreId));

          Mapper.CreateMap<Price, PriceDTO>()
              .ForMember("id", opt => opt.MapFrom(src => src.Id))
              .ForMember("priceValue", opt => opt.MapFrom(src => src.PriceValue))
              .ForMember("dateOt", opt => opt.MapFrom(src => src.DateOt))
              .ForMember("dateDo", opt => opt.MapFrom(src => src.DateDo));
      }

      private static void RegisterMappingsMaterialInStore()
      {
          Mapper.CreateMap<MaterialInStoreDTO, MaterialInStore>()
              .ForMember("Count", opt => opt.MapFrom(src => src.count))
              .ForMember("UnitMaterialId", opt => opt.MapFrom(src => src.unitMaterialId));

          Mapper.CreateMap<MaterialInStore, MaterialInStoreDTO>()
              .ForMember("unitMaterialId", opt => opt.MapFrom(src => src.UnitMaterialId))
              .ForMember("count", opt => opt.MapFrom(src => src.Count))
              .ForMember("kindMaterialName", opt => opt.MapFrom(src => src.UnitMaterialObj.KindMaterialObj.Name));

          Mapper.CreateMap<CreateSupplyDTO, MaterialInStore>()
              .ForMember("Count", opt => opt.MapFrom(src => src.count))
              .ForMember("UnitMaterialId", opt => opt.MapFrom(src => src.unitMaterialId));
      }

      private static void RegisterMappingsUnitMaterial()
      {
          Mapper.CreateMap<UnitMaterial, UnitMaterialDTO>()
              .ForMember("id", opt => opt.MapFrom(src => src.Id))
              .ForMember("unitShotrName", opt => opt.MapFrom(src => src.UnitObj.ShortName));

          Mapper.CreateMap<UnitMaterialDTO, UnitMaterial>()
              .ForMember("Id", opt => opt.MapFrom(src => src.id))
              .ForMember("UnitId", opt => opt.MapFrom(src => src.unitId))
              .ForMember("KindMaterialId", opt => opt.MapFrom(src => src.kindMaterialId));
      }

  }
}
