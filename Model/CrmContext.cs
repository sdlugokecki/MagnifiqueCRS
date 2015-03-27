using Model.Configuration;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class CrmContext : DbContext
	{
		public CrmContext() : base("DefaultConnection")
		{
		}

		public static CrmContext CreateCrmContext()
		{
			return new CrmContext();
		}

		static CrmContext()
		{
			Database.SetInitializer(new CrmContextInitializator());
		}

		public DbSet<TestData> TestDatas { get; set; } 
	}
}
