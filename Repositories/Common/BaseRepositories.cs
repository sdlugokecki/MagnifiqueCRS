using Interfaces;
using Model;
using Model.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
			if (item == null)
				throw new ArgumentNullException("baseEntity add");

			item.CreateBy = "Crud add";
			item.CreateDate = DateTime.Now;
			Context.Set<T>().Add(item);
			Context.SaveChanges();
		}

		public void Update(T item)
		{
			if (item == null)
				throw new ArgumentNullException("item");

			Context.Set<T>().Attach(item);
			Context.Entry<T>(item).State = EntityState.Modified;
			Context.SaveChanges();
		}

		public void Delete(T item)
		{
			if (item == null)
				throw new ArgumentNullException("baseEntity delete");

			Context.Set<T>().Remove(item);
			Context.SaveChanges();
		}

		public T Find(int id)
		{
			return Context.Set<T>().Find(id);
		}
	}
}
