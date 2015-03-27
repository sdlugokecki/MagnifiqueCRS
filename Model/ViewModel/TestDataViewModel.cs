using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
	public class TestDataViewModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "This field cannot be empty", AllowEmptyStrings = false)]
		public string Name { get; set; }

		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
		public DateTime Date { get; set; }

		[Range(0, Int32.MaxValue, ErrorMessage = "Allowed value must be in range {1}..{2}")]
		public int Value { get; set; }
	}
}
