using Kick_It_Web.Models;
using Kick_It_Web.Utilities;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Configuration;

namespace Kick_It_Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public string Reports() {

            DBConnector dbCon = new DBConnector();
            List<Report> repList = dbCon.getReports();
            string json = "[";
            foreach (Report r in repList)
            {
                if (repList.Count - 1 != repList.IndexOf(r))
                {
                    json += r.toJSON() + ",";
                }
                else
                {
                    json += r.toJSON();
                }


            }
            json += "]";

            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(json);

        }

        public string Challenges()
        {

            DBConnector dbCon = new DBConnector();
            List<ChallengeSuggestion> challList = dbCon.challenges();
            string json = "[";
            foreach (ChallengeSuggestion c in challList)
            {
               

                if (challList.Count - 1 != challList.IndexOf(c))
                {
                    json += Newtonsoft.Json.JsonConvert.SerializeObject(c) + ",";
                }
                else
                {
                    json += Newtonsoft.Json.JsonConvert.SerializeObject(c);
                }


            }
            json += "]";

            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(json);

        }

        public string Users()
        {

            DBConnector dbCon = new DBConnector();
            List<ChallengeSuggestion> challList = dbCon.challenges();
            string json = "[";
            foreach (ChallengeSuggestion c in challList)
            {


                if (challList.Count - 1 != challList.IndexOf(c))
                {
                    json += Newtonsoft.Json.JsonConvert.SerializeObject(c) + ",";
                }
                else
                {
                    json += Newtonsoft.Json.JsonConvert.SerializeObject(c);
                }


            }
            json += "]";

            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(json);

        }
    }
}