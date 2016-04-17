using System.Collections.Generic;
using System.Linq;
using Store.Bll.Exception;
using Store.Dal;
using Store.Model;

namespace Store.Bll.Bll
{
	public interface IKindMaterialBll
	{
	  KindMaterial GetByArticul(string articul);
	  IList<KindMaterial> GetAll();
	  KindMaterial Add(KindMaterial obj);
	  KindMaterial Update(KindMaterial obj);
	  bool Delete(string articul);
		bool IsExistMaterialInStore(string articul);
	}

	public class KindMaterialBll : IKindMaterialBll
	{
		protected IFactoryDal FactoryDal;

		public KindMaterialBll(IFactoryDal factoryDal)
		{
			FactoryDal = factoryDal;
		}

		public KindMaterial GetByArticul(string articul)
		{
		  return FactoryDal.KindMaterialDal.First(x => x.Articul == articul.Trim());
		}

		public IList<KindMaterial> GetAll()
		{
		  return FactoryDal.KindMaterialDal.GetAll().OrderBy(x => x.Name).ToList();
		}

		public KindMaterial Add(KindMaterial obj)
		{
		  bool isExist = FactoryDal.KindMaterialDal.First(x => x.Articul == obj.Articul.Trim()) == null ? true : false;
		  if (isExist) throw new DbOwnException("Вид материала АРТИКУЛ = " + obj.Articul + " уже существует в БД!");

		  KindMaterial newObj = FactoryDal.KindMaterialDal.Add(obj);
		  return newObj;
		}

		public KindMaterial Update(KindMaterial obj)
		{
		  return FactoryDal.KindMaterialDal.Update(obj);
		}

		public bool Delete(string articul)
		{
		  KindMaterial obj = FactoryDal.KindMaterialDal.First(x => x.Articul == articul.Trim());
		  if (obj == null) throw new DbOwnException("Вида материала АРТИКУЛ = " + articul + " нет в БД!");
		  return FactoryDal.KindMaterialDal.Delete(obj);
		}

		public bool IsExistMaterialInStore(string articul)
		{
			return FactoryDal.KindMaterialDal.First(x => x.Articul == articul.Trim()).MaterialInStores.Any();
		}

	}
}
