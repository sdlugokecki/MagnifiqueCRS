using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;

namespace Model.Configuration
{
	public class MigrationConfiguration : DbMigrationsConfiguration<CrmContext>
	{
		public MigrationConfiguration()
		{
			AutomaticMigrationsEnabled = true;
			AutomaticMigrationDataLossAllowed = true;
		}

		protected override void Seed(CrmContext context)
		{
		}
	}
}
