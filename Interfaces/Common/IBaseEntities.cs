using Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
	public interface IBaseEntities<T> where T : BaseEntities
	{
		IEnumerable<T> GetAll();

		void Add(T item);

		void Update(T item);

		void Delete(T item);

		T Find(int id);
	}
}
