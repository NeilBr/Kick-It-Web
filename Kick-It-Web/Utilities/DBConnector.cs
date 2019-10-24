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
            if (reader.Read())
            {
                Adventurer user = new Adventurer();
                //Create adventurer here
                
                user.adv_email = (string) reader["adv_email"];
                user.adv_id = (double) reader["adv_id"];
                user.adv_firstname = (string) reader["adv_firstName"];
                user.adv_surname = (string)reader["adv_surname"];
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
            command.CommandText = "SELECT * FROM ((reports AS r INNER JOIN adventurers AS a ON r.adv_id = a.adv_id) INNER JOIN posts AS p ON p.p_id = r.p_id);" ;

            List<Report> repList = new List<Report>();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int rep_id, adv_id, p_id;
                string rep_reason, reported_by;
                rep_id = (int) reader["rep_id"];
                adv_id = (int) reader["adv_id"];
                p_id = (int) reader["p_id"];
                rep_reason = (string) reader["rep_reason"];
                reported_by = (string)reader["adv_firstName"] + " " + (string)reader["adv_surname"];
                Report report = new Report(rep_id,adv_id,p_id,rep_reason);

                repList.Add(report);
            }
            connection.Close();
            return repList;


        }
        public List<Adventurer> getAdventurers()
        {
            MySqlConnection connection = Connect();
            MySqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "SELECT * FROM adventurers;";

            List<Adventurer> advList = new List<Adventurer>();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Adventurer curAdv = new Adventurer();
                curAdv.adv_id = (double) reader["adv_id"];
                curAdv.adv_firstname = (string)reader["adv_firstName"];
                curAdv.adv_surname = (string)reader["adv_surname"];
                curAdv.adv_telephone = (string)reader["adv_telephone"];
                curAdv.adv_totalPoints = (double)reader["adv_totalPoints"];
                curAdv.adv_profilepic = (string)reader["adv_profilepic"];
                curAdv.adv_password = (string)reader["adv_password"];
                curAdv.adv_email = (string)reader["adv_email"];

                advList.Add(curAdv);
            }
            connection.Close();
            return advList;


        }

        public List<ChallengeSuggestion> challenges() {
            MySqlConnection connection = Connect();
            MySqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "SELECT * FROM challenges WHERE c_status = 0 ;";

            List<ChallengeSuggestion> challList = new List<ChallengeSuggestion>();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                ChallengeSuggestion curChall = new ChallengeSuggestion();

                curChall.c_id = (int)reader["c_id"];
                curChall.c_points = (int)reader["c_points"];
                curChall.c_name = (string)reader["c_name"];
                curChall.c_description = (string)reader["c_description"];
                curChall.c_price= (double)reader["c_price"];
                curChall.c_status = (bool)reader["c_status"];
        
                challList.Add(curChall);
            }
            connection.Close();
            return challList;

        }

       

        public List<ChallengeSuggestion> getChallenges()
        {
            MySqlConnection connection = Connect();
            MySqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "SELECT * FROM challenges WHERE c_status = 1 ;";

            List<ChallengeSuggestion> challList = new List<ChallengeSuggestion>();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                ChallengeSuggestion curChall = new ChallengeSuggestion();

                curChall.c_id = (int)reader["c_id"];
                curChall.c_points = (int)reader["c_points"];
                curChall.c_name = (string)reader["c_name"];
                curChall.c_description = (string)reader["c_description"];
                curChall.c_price = (double)reader["c_price"];
                curChall.c_status = (bool)reader["c_status"];

                challList.Add(curChall);
            }
            connection.Close();
            return challList;

        }


        public List<Bucketlist> getBucketLists()
        {
            MySqlConnection connection = Connect();
            MySqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "SELECT * FROM bucketlists;";

            List<Bucketlist> blList = new List<Bucketlist>();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                Bucketlist curBl = new Bucketlist();

                curBl.bl_id = (int)reader["bl_id"];
                curBl.bl_reqPoints = (int)reader["bl_reqPoints"];
                curBl.bl_name = (string)reader["bl_name"];
                curBl.bl_description = (string)reader["bl_description"];

                blList.Add(curBl);
            }
            connection.Close();
            return blList;

        }
        public Boolean deleteUser(string adv_id)
        {
            MySqlConnection connection = Connect();
            MySqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "Delete FROM adventurers WHERE adv_id = " + adv_id +";";

           command.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public Adventurer getAdventurer(string adv_id)
        {
            MySqlConnection connection = Connect();
            MySqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "Select * FROM adventurers WHERE adv_id = " + adv_id + ";";

            MySqlDataReader reader = command.ExecuteReader();
            Adventurer curAdv = new Adventurer();
            while (reader.Read())
            {
               
                curAdv.adv_id = (double)reader["adv_id"];
                curAdv.adv_firstname = (string)reader["adv_firstName"];
                curAdv.adv_surname = (string)reader["adv_surname"];
                curAdv.adv_telephone = (string)reader["adv_telephone"];
                curAdv.adv_totalPoints = (double)reader["adv_totalPoints"];
                curAdv.adv_profilepic = (string)reader["adv_profilepic"];
                curAdv.adv_password = (string)reader["adv_password"];
                curAdv.adv_email = (string)reader["adv_email"];
                curAdv.adv_active = (bool)reader["adv_active"];
                curAdv.adv_admin = (bool)reader["adv_admin"];


    
            }
            connection.Close();
            return curAdv;
        }
    }
}