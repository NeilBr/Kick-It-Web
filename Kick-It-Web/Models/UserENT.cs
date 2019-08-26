using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kick_It_Web.Models
{
    public class UserENT
    {
        public Adventurer ValidateUser(string email, string password)
        {
            return new Adventurer(email, password);
        }
    }
}