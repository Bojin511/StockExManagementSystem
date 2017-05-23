using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Configuration;

namespace Utils
{
    public class UserBanner
    {
        public static void banUserByUsername(string username)
        {
            //XDocument xdoc = XDocument.Load(@"../../Users.xml");
            //var query = (from usr in xdoc.Descendants("USER")
            //             where usr.Element("USERNAME").Value == username
            //             select usr);
            //query.Remove();
            //xdoc.Save(@"../../Users.xml");

            string query = @"delete from Users where username = '" + username + "' ";
            SqlConnection Cn = new SqlConnection(ConfigurationManager.ConnectionStrings["xmlDBOrigConnectionString1"].ConnectionString);
            SqlCommand Com = new SqlCommand(query, Cn);
            Cn.Open();
            int res = Com.ExecuteNonQuery();
            Cn.Close();
        }
    }
}
