using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi2.Controllers
{
    public class LoginController : Controller
    {
        AdminManager _adminManager = new AdminManager(new EfAdminDal());
        [HttpGet]
        public ActionResult Index()
        {
            Session["Abc"] = int.Parse(1.ToString());
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            //Context context = new Context();
            //var adminUserInfo = context.Admins.Where(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword).FirstOrDefault();

            //if (adminUserInfo != null)
            //{
            //    Session["adminUserName"] = adminUserInfo.AdminUserName;
            //    Session["adminPassword"] = adminUserInfo.AdminPassword;
            //    return RedirectToAction("Index", "AdminCategory");
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Login");
            //}

            var values = _adminManager.AdminLoginVerification(admin.AdminUserName, admin.AdminPassword);

            if (values != null)
            {
                if (values == true)
                {
                    FormsAuthentication.SetAuthCookie(admin.AdminUserName, false);
                    Session["AdminUserName"] = admin.AdminUserName;
                    return RedirectToAction("Index", "AdminCategory");
                }
                else
                {
                    Session["Abc"] = int.Parse(0.ToString());
                    return View();
                }
            }

            else
            {
                Session["Abc"] = int.Parse(0.ToString());
                return View();
            }
        }

        //[HttpPost]
        //public ActionResult Index(Admin admin)
        //{
        //    var isLoginValid = _adminManager.AdminLoginVerificationHash(admin.AdminUserName, admin.AdminPassword);

        //    if (isLoginValid)
        //    {
        //        Session["Abc"] = 1; // Giriş başarılı
        //        return RedirectToAction("Index", "AdminCategory");
        //    }
        //    else
        //    {
        //        Session["Abc"] = 0; // Giriş başarısız
        //        return View();
        //    }
        //}

    }
}