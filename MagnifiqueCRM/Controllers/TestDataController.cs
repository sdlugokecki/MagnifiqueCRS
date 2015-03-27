﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.Model;
using Model;
using Interfaces;
using Model.ViewModel;

namespace MagnifiqueCRM.Controllers
{
	public class TestDataController : Controller
	{
		private ITestData _testData;

		public TestDataController(ITestData testData)
		{
			_testData = testData;
		}

		// GET: /TestData/
		public ActionResult Index()
		{
			var baseData = _testData.GetAll();
			List<TestDataViewModel> viewDatas = new List<TestDataViewModel>();

			foreach (var data in baseData)
			{
				viewDatas.Add(new TestDataViewModel
				{
					Date = data.Date,
					Id = data.Id,
					Name = data.Name,
					Value = data.Value
				});
			}

			return View(viewDatas);
		}

		// GET: /TestData/Details/5
		public ActionResult Details(int? id)
		{
			if (!id.HasValue)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			TestData testdata = _testData.Find(id.Value);
			if (testdata == null)
			{
				return HttpNotFound();
			}
			return View(testdata);
		}

		// GET: /TestData/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: /TestData/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,Name,Date,Value")] TestDataViewModel viewData)
		{
			if (ModelState.IsValid)
			{
				var baseData = new TestData
				{
					Name = viewData.Name,
					Date = viewData.Date,
					Value = viewData.Value,
					CreateBy = "Crud add",
					CreateDate = DateTime.Now
				};

				_testData.Add(baseData);
				return RedirectToAction("Index");
			}

			return View(viewData);
		}

		// GET: /TestData/Edit/5
		public ActionResult Edit(int? id)
		{
			if (!id.HasValue)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			TestData testdata = _testData.Find(id.Value);
			
			if (testdata == null)
			{
				return HttpNotFound();
			}

			TestDataViewModel viewData = new TestDataViewModel
			{
				Id = testdata.Id,
				Name = testdata.Name,
				Date = testdata.Date,
				Value = testdata.Value
			};

			return View(viewData);
		}

		// POST: /TestData/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Name,Date,Value")] TestDataViewModel viewData)
		{
			if (ModelState.IsValid)
			{
				var baseData = new TestData
				{
					Id = viewData.Id,
					Name = viewData.Name,
					Date = viewData.Date,
					Value = viewData.Value,
					UpdateBy = "Crud update",
					UpdateDate = DateTime.Now
				};

				_testData.Update(baseData);
				return RedirectToAction("Index");
			}
			return View(viewData);
		}

		// GET: /TestData/Delete/5
		public ActionResult Delete(int? id)
		{
			if (!id.HasValue)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			TestData testdata = _testData.Find(id.Value);
			if (testdata == null)
			{
				return HttpNotFound();
			}
			return View(testdata);
		}

		// POST: /TestData/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			TestData testdata = _testData.Find(id);
			_testData.Delete(testdata);
			return RedirectToAction("Index");
		}
	}
}
