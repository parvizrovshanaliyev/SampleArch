﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleArch.Model;
using SampleArch.Services;

namespace SampleArch.Web.Controllers
{
    public class CountryController : Controller
    {
        //initialize service object
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
           _countryService = countryService;
        }

        //
        // GET: /Country/
        public IActionResult Index()
        {
            return View(_countryService.GetAll());
        }

        //
        // GET: /Country/Create
        public IActionResult Create()
        {
            return View();
        }


        //
        // POST: /Country/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Country country)
        {

            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
               _countryService.Create(country);
                return RedirectToAction("Index");
            }
            return View(country);

        }

        //
        // GET: /Country/Edit/5
        public IActionResult Edit(int id)
        {
            Country country =_countryService.GetById(id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }

        //
        // POST: /Country/Edit
        [HttpPost]
        public IActionResult Edit(Country country)
        {

            if (ModelState.IsValid)
            {
               _countryService.Update(country);
                return RedirectToAction("Index");
            }
            return View(country);

        }

        //
        // GET: /Country/Delete/5
        public IActionResult Delete(int id)
        {
            var country = _countryService.GetById(id);
            if (country == null)
            {
                return NotFound();
            }
            _countryService.Delete(country);
            return RedirectToAction("Index");
        }

        //
        // POST: /Country/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id)
        //{
        //    Country country =_countryService.GetById(id);
        //   _countryService.Delete(country);
        //    return RedirectToAction("Index");
        //}
    }
}