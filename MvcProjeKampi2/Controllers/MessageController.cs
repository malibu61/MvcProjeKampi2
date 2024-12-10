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
    public class MessageController : Controller
    {
        MessageManager _messageManager = new MessageManager(new EfMessageDal());
        public ActionResult InBox()
        {
            var values = _messageManager.GetListInBox();
            ViewBag.inboxCount=values.Count();
            return View(values);
        }

        public ActionResult SendBox()
        {
            var values = _messageManager.GetListSendBox();
            ViewBag.sendboxCount = values.Count();
            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            _messageManager.MessageAdd(message);
            return RedirectToAction("Inbox");
        }
    }
}