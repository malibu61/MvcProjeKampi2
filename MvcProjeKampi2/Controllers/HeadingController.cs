using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi2.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager _headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());
        AuthorManager _authorManager = new AuthorManager(new EfAuthorDal());


        public ActionResult HeadingList()
        {
            var values = _headingManager.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> categoryValues = (from x in _categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }
                                                  ).ToList();


            List<SelectListItem> authorValues = (from x in _authorManager.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.AuthorName + " " + x.AuthorSurname,
                                                     Value = x.AuthorId.ToString()
                                                 }
                                                 ).ToList();
            ViewBag.vCategories = categoryValues;
            ViewBag.vAuthors = authorValues;

            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            _headingManager.HeadingAdd(heading);
            return RedirectToAction("HeadingList");
        }


        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> categoryValues = (from x in _categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }
                                                 ).ToList();


            List<SelectListItem> authorValues = (from x in _authorManager.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.AuthorName + " " + x.AuthorSurname,
                                                     Value = x.AuthorId.ToString()
                                                 }
                                                 ).ToList();
            ViewBag.vCategories = categoryValues;
            ViewBag.vAuthors = authorValues;

            var values = _headingManager.GetByID(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            _headingManager.HeadingUpdate(heading);
            return RedirectToAction("HeadingList");
        }

        public ActionResult DeleteHeading(int id)
        {
            var values = _headingManager.GetByID(id);
            values.HeadingStatus = false;
            _headingManager.HeadingUpdate(values);
            return RedirectToAction("HeadingList");
        }

        public ActionResult CorrectHeading(int id)
        {
            var values = _headingManager.GetByID(id);
            values.HeadingStatus = true;
            _headingManager.HeadingUpdate(values);
            return RedirectToAction("HeadingList");
        }

    }
}