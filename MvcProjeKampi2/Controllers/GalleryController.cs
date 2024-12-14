using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi2.Controllers
{
    public class GalleryController : Controller
    {
        ImageManager _imageManager = new ImageManager(new EfImageDal());
        public ActionResult Index()
        {
            var values = _imageManager.GetList();
            return View(values);
        }
    }
}