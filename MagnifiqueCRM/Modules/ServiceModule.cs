using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MagnifiqueCRM.Modules
{
	public class ServiceModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterAssemblyTypes(Assembly.Load("Services"))
				.Where(t => t.Name.EndsWith("Services"))
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();
		}
	}
}