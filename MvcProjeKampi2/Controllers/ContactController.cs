using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi2.Controllers
{
    public class ContactController : Controller
    {
        ContactManager _contactManager = new ContactManager(new EfContactDal());
        MessageManager _messageManager = new MessageManager(new EfMessageDal());

        public ActionResult Index()
        {
            var values = _contactManager.GetList();
            return View(values);
        }

        public ActionResult ContactDetail(int id)
        {
            var values = _contactManager.GetByID(id);
            return View(values);
        }




        public PartialViewResult MessageLeftPartial()
        {

            ViewBag.inboxCount = _messageManager.GetListInBox().Count();
            ViewBag.sendCount = _messageManager.GetListSendBox().Count();
            ViewBag.messagesCount = _messageManager.GetListSendBox().Count() + _messageManager.GetListInBox().Count();
            return PartialView();
        }
    }
}