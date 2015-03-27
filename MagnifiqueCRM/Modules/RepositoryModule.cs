using Autofac;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MagnifiqueCRM.Modules
{
	public class RepositoryModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterAssemblyTypes(Assembly.Load("Repositories"))
				.Where(t => t.Name.EndsWith("Repositories"))
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();
		}
	}
}