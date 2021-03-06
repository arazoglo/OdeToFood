﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdeToFood.Models;
using OdeToFood.Queries;

namespace OdeToFood.Controllers
{
    public class ReviewsController : Controller
    {
        OdeToFoodDb _db = new OdeToFoodDb();

        public ActionResult Index()
        {
            var model = _db.Reviews.FindTheLatest(3);
            return View(model);
        }

        [ChildActionOnly]
        public  ActionResult BestReview()
        {
            var model = _db.Reviews.FindTheBest();
            return PartialView("_Review", model);
        }
        //
        // GET: /Default1/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Default1/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Default1/Edit/5
 
        public ActionResult Edit(int id)
        {
            var review = _db.Reviews.FindById(id);
            return View(review);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var review = _db.Reviews.FindById(id);

            if(TryUpdateModel(review))
            {
                return RedirectToAction("Index");
            }
            return View(review);
            
        }

        //
        // GET: /Default1/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
