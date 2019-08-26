using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kick_It_Web.Models
{
    public class Adventurer
    {   
       public String email, password;

        public int id;

        public Adventurer() {
        }

        public Adventurer(string email, string password)
        {
            this.email = email ;
            this.password = password ;
        }
    }
}