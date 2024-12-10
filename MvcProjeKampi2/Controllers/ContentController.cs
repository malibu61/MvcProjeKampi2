using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi2.Controllers
{
    public class ContentController : Controller
    {
        ContentManager _contentManager = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ContentByHeading(int id)
        {
            var values = _contentManager.GetListById(id);
            return View(values);
        }
    }
}