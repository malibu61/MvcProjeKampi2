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
    public class AboutController : Controller
    {
        AboutManager _aboutManager = new AboutManager(new EfAboutDal());
        public ActionResult AboutList()
        {
            var values = _aboutManager.GetList();
            return View(values);
        }

        public ActionResult AddAbout(About about)
        {
            _aboutManager.AboutAdd(about);
            return RedirectToAction("AboutList");
        }

        public PartialViewResult AddAboutPopUp()    //pou-up bu view'da
        {
            return PartialView();
        }
    }
}