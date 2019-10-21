using Kick_It_Web.Models;
using Kick_It_Web.Utilities;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Configuration;
using System.Web.Security;

namespace Kick_It_Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Name"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("Index","Login");
        }
        
        public string Reports() {

            DBConnector dbCon = new DBConnector();
            List<Report> repList = dbCon.getReports();
            string json = "[";
            foreach (Report r in repList)
            {
                if (repList.Count - 1 != repList.IndexOf(r))
                {
                    json += Newtonsoft.Json.JsonConvert.SerializeObject(r) + ",";
                }
                else
                {
                    json += Newtonsoft.Json.JsonConvert.SerializeObject(r) ;
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
        public string getChallenges()
        {

            DBConnector dbCon = new DBConnector();
            List<ChallengeSuggestion> challList = dbCon.getChallenges();
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
            List<Adventurer> advList = dbCon.getAdventurers();
            string json = "[";
            foreach (Adventurer a in advList)
            {


                if (advList.Count - 1 != advList.IndexOf(a))
                {
                    json += Newtonsoft.Json.JsonConvert.SerializeObject(a) + ",";
                }
                else
                {
                    json += Newtonsoft.Json.JsonConvert.SerializeObject(a);
                }


            }
            json += "]";

            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(json);

        }
        public string getBucketlists()
        {

            DBConnector dbCon = new DBConnector();
            List<Bucketlist> blList = dbCon.getBucketLists();
            string json = "[";
            foreach (Bucketlist bl in blList)
            {


                if (blList.Count - 1 != blList.IndexOf(bl))
                {
                    json += Newtonsoft.Json.JsonConvert.SerializeObject(bl) + ",";
                }
                else
                {
                    json += Newtonsoft.Json.JsonConvert.SerializeObject(bl);
                }


            }
            json += "]";

            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(json);

        }
    }
}