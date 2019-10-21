using Kick_It_Web.Models;
using Kick_It_Web.Utilities;
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
        public ActionResult Login(){
            string email = Request.Form["loginEmail"];
            string password = Request.Form["loginPassword"];

            UserENT userent = new UserENT();
           
           Adventurer validatedUser = userent.ValidateUser(email, password);

           Session["Name"] = validatedUser.adv_firstname + " " + validatedUser.adv_surname;
            return RedirectToRoute(new
            {
                controller = "Home",
                action = "Index"
              
            });

        }

        [HttpPost]
        [Authorize]
        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}