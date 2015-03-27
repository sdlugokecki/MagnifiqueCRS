using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
	public interface ITestData : IBaseEntities<TestData>
	{
		IEnumerable<TestData> GetSpecyficRange(int startId, int endId);
	}
}
