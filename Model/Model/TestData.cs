using Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
	public class TestData : BaseEntities
	{
		public string Name { get; set; }

		public DateTime Date { get; set; }

		public int Value { get; set; }
	}
}
