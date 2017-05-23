using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Configuration;

namespace Utils
{
    public class UserPermissionChanger
    {
        public static void changePermissionByUsername(string firstname, string lastname, string stockEx, string status)
        {
            //XDocument xdoc = XDocument.Load(@"../../Users.xml");

            //var query = (from usr in xdoc.Descendants("USER")
            //             where usr.Element("USERNAME").Value == username
            //             select usr);

            //foreach (var usr in query)
            //{ usr.SetElementValue("ROLE", permission); }

            //xdoc.Save(@"../../Users.xml");

            string query = @"update share_holder_stock_ex set status = '" + status + "' where share_holder_id =(select share_holder_id from share_holders where first_name = '" + firstname + "' and last_name = '" + lastname + "') and stock_ex_id = (select stock_ex_id from stock_exchanges where name = '" + stockEx + "')";
            SqlConnection Cn = new SqlConnection(ConfigurationManager.ConnectionStrings["xmlDBOrigConnectionString1"].ConnectionString);
            SqlCommand Com = new SqlCommand(query, Cn);
            Cn.Open();
            int res = Com.ExecuteNonQuery();
            Cn.Close();
        }
    }
}
