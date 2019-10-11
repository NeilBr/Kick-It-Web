using System;
using System.Collections;
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
             public DBConnector()
        {
        }

        public MySqlConnection Connect()
        {
            MySqlConnection connection = new MySqlConnection("Server=kickit-db.cqqbwmmosjza.eu-west-1.rds.amazonaws.com;Database=kickit;Uid=kickitadmin;Pwd=kickitwrr302;");
            return connection;


        }

        public Adventurer checkUser(String email, String pword) {
            MySqlConnection connection =  Connect();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM adventurers WHERE adv_email = '" +email +"' AND adv_password = '" + pword + "';";

          MySqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                Adventurer user = new Adventurer();
                //Create adventurer here
                reader.Read();
                user.email = reader.GetString(1);
                user.id = reader.GetInt16(0);
                connection.Close();
                return user;
            }
            else {
                connection.Close();
                return null;
            }

        }
        public void resetPassword(String email, String pword)
        {
            //connection.Open();
            //command.CommandText = "UPDATE Adventurer SET advPassword = "+ pword +" WHERE email = " + email + " ;";

            //MySqlDataReader reader = command.ExecuteReader();
            //connection.Close();
        }

        public List<Report> getReports()
        {
          MySqlConnection connection = Connect();
            MySqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "SELECT * FROM reports ;";

            List<Report> repList = new List<Report>();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int rep_id, adv_id, p_id;
                string rep_reason;

                rep_id = reader.GetInt32(0);
                adv_id = reader.GetInt32(1);
                p_id = reader.GetInt32(2);
                rep_reason = reader.GetString(3);
                Report report = new Report(rep_id,adv_id,p_id,rep_reason);

                repList.Add(report);
            }
            connection.Close();
            return repList;


        }
    }
}