using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Security.Application;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;
using System.EnterpriseServices;


namespace MvcProjeKampi2.Controllers
{
    public class MessageController : Controller
    {
        MessageManager _messageManager = new MessageManager(new EfMessageDal());
        MessageValidator _messageValidator = new MessageValidator();
        public ActionResult InBox()
        {
            var values = _messageManager.GetListInBox();
            ViewBag.inboxCount = values.Count();
            return View(values);
        }

        public ActionResult SendBox()
        {
            var values = _messageManager.GetListSendBox();
            ViewBag.sendboxCount = values.Count();
            return View(values);
        }


        public ActionResult GetInBoxMessageDetails(int id)
        {
            var values = _messageManager.GetByID(id);
            return View(values);
        }

        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var values = _messageManager.GetByID(id);
            return View(values);
        }


        [HttpGet]
        public ActionResult NewMessage()
        {
            var values = _messageManager.GetListInBox().FirstOrDefault();
            values.SenderMail = "";
            values.ReceiverMail = "";
            values.MessageContent = "";
            values.Subject = "";
            return View(values);
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult result = _messageValidator.Validate(message);

            if (result.IsValid)
            {
                // Kullanıcının girdiği HTML içeriği sanitize ediliyor
                message.MessageContent = Sanitizer.GetSafeHtmlFragment(message.MessageContent);

                // Mesajın diğer bilgileri dolduruluyor
                message.MessageDate = DateTime.Now;
                message.SenderMail = "admin@gmail.com"; // Gönderen sabit bir admin e-postası

                // Veritabanına kaydediliyor
                _messageManager.MessageAdd(message);

                return RedirectToAction("SendBox");

            }

            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View(message);

        }

    }
}