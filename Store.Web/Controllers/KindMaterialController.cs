using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Store.Bll;
using Store.Bll.Bll;
using Store.Model;
using Store.Model.DTOObjects;
using Store.Model.RequestObjects;

namespace Store.Web.Controllers
{
    [RoutePrefix("api/kindMaterial")]
    public class KindMaterialController : BaseApiController
    {
        private readonly IKindMaterialBll _kindMaterialBll;

         public KindMaterialController(IFactoryBll factoryBll)
        {
            if (factoryBll == null)
            {
                throw new ArgumentNullException("factoryBll");
            }
            _kindMaterialBll = factoryBll.KindMaterialBll;
        }

			[HttpGet]
			public List<KindMaterialDTO> GetKindMaterials([FromUri] QueryRequest queryRequest)
			{
			  List<KindMaterialDTO> list = Mapper.Map<IQueryable<KindMaterial>, List<KindMaterialDTO>>(_kindMaterialBll.GetAll());
			  return list;
			}

			[HttpPost]
			public KindMaterialDTO CreateKindMaterial([FromBody] KindMaterialDTO model)
			{
			  KindMaterial entity = Mapper.Map<KindMaterialDTO, KindMaterial>(model);
			  model = Mapper.Map<KindMaterial, KindMaterialDTO>(_kindMaterialBll.Save(entity));
			  return model;
			}

			[HttpPut]
			public KindMaterialDTO UpdateKindMaterial([FromBody] KindMaterialDTO model)
			{
			  KindMaterial entity = Mapper.Map<KindMaterialDTO, KindMaterial>(model);
			  model = Mapper.Map<KindMaterial, KindMaterialDTO>(_kindMaterialBll.Save(entity)); // AddorUpdate
			  return model;
			}

			[HttpDelete]
			public bool DeleteKindMaterial([FromUri] int id)
			{
			  return _kindMaterialBll.Delete(id);
			}
    }
}