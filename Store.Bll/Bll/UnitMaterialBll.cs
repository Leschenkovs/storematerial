
using System.Collections.Generic;
using System.Linq;
using Store.Bll.Exception;
using Store.Dal;
using Store.Model;

namespace Store.Bll.Bll
{
  public interface IUnitMaterialBll
  {
	 IList<UnitMaterial> GetByKindMaterialId(int id);
	  bool Delete(int id);
	  UnitMaterial Add(int idUnit, int idKindMaterial);
  }

  public class UnitMaterialBll : IUnitMaterialBll
  {
	 protected IFactoryDal FactoryDal;

	 public UnitMaterialBll(IFactoryDal factoryDal)
	 {
		FactoryDal = factoryDal;
	 }

	 public IList<UnitMaterial> GetByKindMaterialId(int id)
	 {
		 IList<UnitMaterial> list =
			 FactoryDal.UnitMaterialDal.FindBy(x => x.KindMaterialId == id).OrderBy(x => x.UnitObj.ShortName).ToList();
		return list;
	 }

	  public bool Delete(int id)
	  {
		 UnitMaterial obj = FactoryDal.UnitMaterialDal.First(x => x.Id == id);
		 if (obj == null) throw new DbOwnException("Запись отсутствует в БД!");
		 return FactoryDal.UnitMaterialDal.Delete(obj);
	  }

	  public UnitMaterial Add(int idUnit, int idKindMaterial)
	  {
		 bool isExist = FactoryDal.UnitMaterialDal.First(x => x.UnitId == idUnit && x.KindMaterialId == idKindMaterial) == null ? true : false;
		 if (isExist) throw new DbOwnException("Запись уже существует в БД!");

		 UnitMaterial obj = new UnitMaterial{ UnitId = idUnit, KindMaterialId = idKindMaterial};
		 UnitMaterial newObj = FactoryDal.UnitMaterialDal.Add(obj);
		 return newObj;
	  }
  }
}
