using Interfaces;
using Model;
using Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Common
{
	public class BaseRepositories<T> : IBaseEntities<T>
		where T : BaseEntities
	{
		protected CrmContext Context;

		public BaseRepositories(CrmContext context)
		{
			Context = context;
		}

		public IEnumerable<T> GetAll()
		{
			return Context.Set<T>().AsEnumerable();
		}

		public void Add(T item)
		{
			if (item != null)
			{
				item.CreateBy = "Crud add";
				item.CreateDate = DateTime.Now;
				Context.Set<T>().Add(item);
				Context.SaveChanges();
			}
			else
				throw new ArgumentNullException("baseEntity add");
		}

		public void Update(T item)
		{
			if (item != null)
			{
				var original = Context.Set<T>().Find(item.Id);
				if (original != null)
				{
					item.CreateBy = original.CreateBy;
					item.CreateDate = original.CreateDate;
					Context.Entry(original).State = System.Data.Entity.EntityState.Modified;
					Context.Entry<T>(original).CurrentValues.SetValues(item);
					Context.SaveChanges();
				}
				else
					throw new ArgumentNullException("Original value not found");
			}
			else
				throw new ArgumentNullException("baseEntity update");
		}

		public void Delete(T item)
		{
			if (item != null)
			{
				Context.Set<T>().Remove(item);
				Context.SaveChanges();
			}
			else
				throw new ArgumentNullException("baseEntity delete");
		}

		public T Find(int id)
		{
			return Context.Set<T>().Find(id);
		}
	}
}
