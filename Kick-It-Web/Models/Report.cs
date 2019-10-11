using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kick_It_Web.Models
{
    public class Report
    {

        int rep_id;
        int adv_id;
        int p_id;
        string rep_reason;

        public Report(int rid , int aid, int pid, string  reason) {
            this.rep_id = rid;
            this.adv_id = aid;
            this.p_id = pid;
            this.rep_reason = reason;
        }

    }
}