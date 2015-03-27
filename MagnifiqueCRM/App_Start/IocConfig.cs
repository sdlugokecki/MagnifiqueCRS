using Autofac;
using Autofac.Integration.Mvc;
using MagnifiqueCRM.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagnifiqueCRM.App_Start
{
	public class IocConfig
	{
		public static void RegisterDependencies()
		{
			var builder = new ContainerBuilder();
			builder.RegisterControllers(typeof(MvcApplication).Assembly);
			builder.RegisterModule(new ContextModule());
			builder.RegisterModule(new RepositoryModule());

			// or we can use ServiceModule
			//builder.RegisterModule(new ServiceModule());

			IContainer container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
		}
	}
}