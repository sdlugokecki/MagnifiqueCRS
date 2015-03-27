using Autofac;
using Autofac.Integration.Mvc;
using Interfaces;
using MagnifiqueCRM.App_Start;
using Model;
using Repositories.Impl;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MagnifiqueCRM
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			IocConfig.RegisterDependencies();
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}
	}
}
