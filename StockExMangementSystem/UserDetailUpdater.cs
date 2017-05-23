using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Configuration;

namespace Utils
{
    public class UserDetailUpdater
    {
        public static void updateUserDetailByUsername(string username, string password, string firstname, string lastname, string email, string DOB)
        {
            //XDocument xdoc = XDocument.Load(@"../../Users.xml");

            //var query = (from usr in xdoc.Descendants("USER")
            //             where usr.Element("USERNAME").Value == username
            //             select usr);

            //foreach (var usr in query)
            //{
            //    usr.SetElementValue("USERNAME", username);
            //    usr.SetElementValue("PASSWORD", password);
            //    usr.SetElementValue("FIRST_NAME", firstname);
            //    usr.SetElementValue("LAST_NAME", lastname);
            //    usr.SetElementValue("EMAIL", email);
            //    usr.SetElementValue("DOB", DOB);
            //}

            //xdoc.Save(@"../../Users.xml");
            //xdoc.Save(@"../../Backup.xml");


            string query = @"update Users set password = '" + password + "', first_name = '" + firstname + "', last_name = '" + lastname + "', email = '" + email + "', DOB = '" + DOB + "' where username = '" + username + "'"; 
            SqlConnection Cn = new SqlConnection(ConfigurationManager.ConnectionStrings["xmlDBOrigConnectionString1"].ConnectionString);
            SqlCommand Com = new SqlCommand(query, Cn);
            Cn.Open();
            int res = Com.ExecuteNonQuery();
            Cn.Close();


        }
    }
}
