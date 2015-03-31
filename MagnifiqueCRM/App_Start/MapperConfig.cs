using AutoMapper;
using Model.Model;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagnifiqueCRM.App_Start
{
	public class MapperConfig
	{
		public static void CreateMaps()
		{
			Mapper.CreateMap<TestData, TestDataViewModel>();
			Mapper.CreateMap<TestDataViewModel, TestData>();
		}
	}
}