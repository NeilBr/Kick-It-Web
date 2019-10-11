using Kick_It_Web.Models;
using Kick_It_Web.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace Kick_It_Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public List<Report> Reports() {

            DBConnector dbCon = new DBConnector();
            List<Report> repList = dbCon.getReports();
            var jsonSerialiser = new JavaScriptSerializer();
            var json = JsonConvert.SerializeObject(repList);
            return repList;
        }
    }
}