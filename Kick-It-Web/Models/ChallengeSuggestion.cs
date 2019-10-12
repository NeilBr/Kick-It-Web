using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kick_It_Web.Models
{
    public class ChallengeSuggestion
    {

        public int c_id {get; set; }
        public int c_points {get; set; }
        public string c_name { get; set; }
        public string c_description { get; set; }
        public double c_price { get; set; }
        public bool c_status { get; set; }


        public ChallengeSuggestion() {
            
        }
        public string toJSON() {
            return "";

        }
    }
}