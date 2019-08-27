using Kick_It_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Kick_It_Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Adventurer user)
        {
            UserENT userent = new UserENT();

            user = userent.ValidateUser(user.email, user.password);

          
            return RedirectToRoute(new
            {
                controller = "Admin",
                action = "Index",
                id = user.email
            });

        }

        [HttpPost]
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}