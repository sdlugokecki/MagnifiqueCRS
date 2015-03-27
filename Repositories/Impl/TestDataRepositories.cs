using Interfaces;
using Model;
using Model.Model;
using Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Impl
{
	public class TestDataRepositories : BaseRepositories<TestData>, ITestData
	{
		public TestDataRepositories(CrmContext context)
			: base(context)
		{
		}

		public IEnumerable<TestData> GetSpecyficRange(int startId, int endId)
		{
			throw new NotImplementedException();
		}
	}
}

