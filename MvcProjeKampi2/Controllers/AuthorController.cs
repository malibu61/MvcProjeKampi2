using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi2.Controllers
{
    public class AuthorController : Controller
    {
        AuthorManager authorManager = new AuthorManager(new EfAuthorDal());
        public ActionResult AuthorList()
        {
            var authorValues = authorManager.GetList();
            return View(authorValues);
        }


        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAuthor(Author author)
        {
            AuthorValidator authorValidator = new AuthorValidator();
            ValidationResult result = authorValidator.Validate(author);

            if (result.IsValid)
            {
                authorManager.AuthorAdd(author);
                return RedirectToAction("AuthorList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View();
            }
        }


        [HttpGet]
        public ActionResult EditAuthor(int id)
        {
            var values = authorManager.GetByID(id);
            return View(values);
        }


        [HttpPost]
        public ActionResult EditAuthor(Author author)
        {


            AuthorValidator authorValidator = new AuthorValidator();
            ValidationResult result = authorValidator.Validate(author);

            if (result.IsValid)
            {
                authorManager.AuthorUpdate(author);
                return RedirectToAction("AuthorList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View();
            }

        }
    }
}