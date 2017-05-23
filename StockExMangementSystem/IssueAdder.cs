using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Configuration;

namespace Utils
{
    public class IssueAdder
    {
        public static void addRequest(string username, string issue, string date, string description, string status)
        {
            //XDocument xdoc = XDocument.Load(@"../../UserRequests.xml");
            //XElement xReq = new XElement("REQUEST",
            //                new XElement("USERNAME", username),
            //                new XElement("ISSUE", issue),
            //                new XElement("DATE", date),
            //                new XElement("DESCRIPTION", description),
            //                new XElement("STATUS", status));

            //xdoc.Element("REQUESTS").Add(xReq);
            //xdoc.Save(@"../../UserRequests.xml");

            string query = @"insert into UserRequests(username, issue, date, description, status) values ('" + username + "', '" + issue + "', '" + date + "', '" + description + "', '" + status + "')";
            SqlConnection Cn = new SqlConnection(ConfigurationManager.ConnectionStrings["xmlDBOrigConnectionString1"].ConnectionString);
            SqlCommand Com = new SqlCommand(query, Cn);
            Cn.Open();
            int res = Com.ExecuteNonQuery();
            Cn.Close();

        }
    }
}
