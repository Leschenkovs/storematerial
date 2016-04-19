using System.Web.Http;
using Store.Web.App_Start;

namespace Store.Web
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			config.EnsureInitialized();

			config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
			config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;

			config.Routes.MapHttpRoute(
					name: "DefaultApi",
					routeTemplate: "api/{controller}/{action}/{id}",
					defaults: new { id = RouteParameter.Optional, action = RouteParameter.Optional },
					constraints: null
					);

			config.DependencyResolver = new UnityResolver(ComponentRegistry.RegisterComponents());
		}
	}
}
