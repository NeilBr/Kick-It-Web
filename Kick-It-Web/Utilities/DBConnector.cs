using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kick_It_Web.Models;
using MySql.Data;
using MySql.Data.MySqlClient;
using MySql.Web;

namespace Kick_It_Web.Utilities
{
    public class DBConnector
    {
        private MySqlConnection connection;
        private MySqlCommand command;

        public DBConnector()
        {
        }

        public void Connect()
        {
            connection = new MySqlConnection("Server=localhost;Database=KICK-IT;Uid=root;Pwd=loserforce4;");
            command = connection.CreateCommand();
        }

        public Adventurer checkUser(String email, String pword) {
            connection.Open(); 
            command.CommandText = "SELECT * FROM Adventurers WHERE email = " +email +" AND password = " + pword + ";";

          MySqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                Adventurer user = new Adventurer();
                //Create adventurer here
                user.email = reader.GetString(1);
                user.id = reader.GetInt16(0);
                return user;
            }
            else {
                return null;
            }

        }
        public void resetPassword(String email, String pword)
        {
            connection.Open();
            command.CommandText = "UPDATE Adventurer SET advPassword = "+ pword +" WHERE email = " + email + " ;";

            MySqlDataReader reader = command.ExecuteReader();
         
        }
    }
}