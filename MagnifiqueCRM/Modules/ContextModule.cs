using Autofac;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagnifiqueCRM.Modules
{
	public class ContextModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType(typeof(CrmContext)).InstancePerLifetimeScope();
		}
	}
}