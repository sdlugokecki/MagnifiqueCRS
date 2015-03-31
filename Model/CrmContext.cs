using Model.Common;
using Model.Configuration;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model
{
	public class CrmContext : DbContext
	{
		public CrmContext()
			: base("DefaultConnection")
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

		public override int SaveChanges()
		{
			var modifiedEntries = ChangeTracker.Entries()
					.Where(enitity => enitity.Entity is BaseEntities
						&& enitity.State == EntityState.Added || enitity.State == EntityState.Modified);
			foreach (var entry in modifiedEntries)
			{
				BaseEntities entity = entry.Entity as BaseEntities;
				if (entity != null)
				{
					string identityName = string.IsNullOrEmpty(Thread.CurrentPrincipal.Identity.Name) ? "sys" : Thread.CurrentPrincipal.Identity.Name;
					DateTime now = DateTime.UtcNow;
					if (entry.State == System.Data.Entity.EntityState.Added)
					{
						entity.CreateBy = identityName;
						entity.CreateDate = now;
					}
					else
					{
						base.Entry(entity).Property(x => x.CreateBy).IsModified = false;
						base.Entry(entity).Property(x => x.CreateDate).IsModified = false;
						entity.UpdateBy = identityName;
						entity.UpdateDate = now;
					}
				}
			}
			try
			{
				return base.SaveChanges();
			}
			catch (DbEntityValidationException ex)
			{
				// Retrieve the error messages as a list of strings.
				var errorMessages = ex.EntityValidationErrors
						.SelectMany(x => x.ValidationErrors)
						.Select(x => x.ErrorMessage);
				// Join the list to a single string.
				var fullErrorMessage = string.Join("; ", errorMessages);
				// Combine the original exception message with the new one.
				var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
				// Throw a new DbEntityValidationException with the improved exception message.
				throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
			}
		}
	}
}
