using CPMWeb.Areas.Admin.Models;
using CPMWeb.Common;
using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CPMWeb.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            var session = (UserLogin)Session[Common.CommonConstants.USER_SESSION];
            if(session!=null)
            {
                return RedirectToAction("Index", "Home");
            }
            {
                if (ModelState.IsValid)
                {
                    var dao = new UserDAO();
                    var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password));
                    if (result)
                    {
                        var user = dao.getByID(model.UserName);
                        var userSession = new UserLogin();
                        userSession.UserName = user.UserName;
                        userSession.UserID = user.ID;
                        Session.Add(CommonConstants.USER_SESSION, userSession);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng nhập không đúng");
                        return View();
                    }
                }
                return View();
            }
        
        }
        public ActionResult Logout()
        {
            Session.Remove(CommonConstants.USER_SESSION);
            return RedirectToAction("Login", "Account");
        }
    }
}