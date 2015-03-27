using Model.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Model.Configuration
{
	class CrmContextInitializator : MigrateDatabaseToLatestVersion<CrmContext, MigrationConfiguration>
	{
		public CrmContextInitializator()
			: base()
		{ }
	}
}
