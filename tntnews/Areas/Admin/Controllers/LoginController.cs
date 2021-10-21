using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tntnews.Areas.Admin.Code;
using tntnews.Areas.Admin.Models;

namespace tntnews.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        string err = string.Empty;
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AccountModel model)
        {
            var result = new AccountDb().Login(ref err, model.UserName, model.Password);
            if (result && ModelState.IsValid)
            {
                SessionHelper.SetSession(new Session() { UserName = model.UserName });
                return RedirectToAction("Index", "Home", new { Area = "Admin" });
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hay mật khẩu sai");
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            SessionHelper.SetSession(null);
            return RedirectToAction("Index", "Home", new { Area = "Admin" });
        }
    }
}