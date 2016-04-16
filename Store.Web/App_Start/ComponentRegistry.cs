using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Microsoft.Practices.Unity;
using Store.Bll.Bll;

namespace Store.Web.App_Start
{
	public class ComponentRegistry
	{
		public static IUnityContainer RegisterComponents()
		{
			IUnityContainer container = new UnityContainer();
			container.RegisterType<IUserBll, UserBll>();
			return container;
		}

		public class UnityResolver : IDependencyResolver
		{
			protected IUnityContainer container;

			public UnityResolver(IUnityContainer container)
			{
				if (container == null)
				{
					throw new ArgumentNullException("container");
				}
				this.container = container;
			}

			public object GetService(Type serviceType)
			{
				try
				{
					return container.Resolve(serviceType);
				}
				catch (ResolutionFailedException)
				{
					return null;
				}
			}

			public IEnumerable<object> GetServices(Type serviceType)
			{
				try
				{
					return container.ResolveAll(serviceType);
				}
				catch (ResolutionFailedException)
				{
					return new List<object>();
				}
			}

			public IDependencyScope BeginScope()
			{
				var child = container.CreateChildContainer();
				return new UnityResolver(child);
			}

			public void Dispose()
			{
				container.Dispose();
			}
		}
	}
}