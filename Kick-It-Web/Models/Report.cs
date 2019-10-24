using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kick_It_Web.Models
{
    public class Report
    {

      public  int rep_id { get; set; }
      public  int adv_id { get; set; }
        public int p_id { get; set; }
        public string rep_reason { get; set; }

        public Report(int rid , int aid, int pid, string  reason) {
            this.rep_id = rid;
            this.adv_id = aid;
            this.p_id = pid;
            this.rep_reason = reason;
        }
    }
}