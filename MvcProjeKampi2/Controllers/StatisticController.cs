using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi2.Controllers
{
    public class StatisticController : Controller
    {

        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        AuthorManager authorManager = new AuthorManager(new EfAuthorDal());

        public ActionResult StatisticList()
        {
            ViewBag.v1 = categoryManager.TCategoryCount();
            ViewBag.v2 = headingManager.TSoftwareCategoryCountInHeadingTable();
            ViewBag.v3 = authorManager.TAuthorNameCountIncludeA();
            ViewBag.v4 = categoryManager.TCategoryWithMostTitle();
            ViewBag.v5 = categoryManager.DistinctionBetweenTrueAndFalseInCategory();
            ViewBag.v6 = categoryManager.LongestCategoryName();

            return View();
        }
    }
}