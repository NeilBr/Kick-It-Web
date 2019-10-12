using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kick_It_Web.Models
{
    public class Adventurer
    {        
        public int adv_id;
        public string adv_firstname, adv_surname, adv_email, adv_telephone, adv_password, adv_profilepic;
        public double adv_totalPoints;
        public bool adv_active, adv_admin;

        public Adventurer() {
        }

        public Adventurer(string email, string password)
        {
            this.adv_email = email ;
            this.adv_password = password ;
        }
    }
}