using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data.SqlClient;
using System.Configuration;

namespace Utils
{
    public class LoginCounter
    {
        public static LoginStats CountLoginAttempts()
        {
            //XmlDocument doc = new XmlDocument();
            //doc.Load(@"../../loginLog.xml");

            //int count = doc.SelectNodes("LOGINS/LOGIN").Count;
            ////MessageBox.Show(count.ToString());
            //int NoSuccessCount = doc.SelectNodes("LOGINS/LOGIN/ATTEMPT[. = \"Success\"]").Count;
            ////MessageBox.Show("Number of success login is " + NoSuccessCount.ToString());
            //int NoFailedCount = doc.SelectNodes("LOGINS/LOGIN/ATTEMPT[. = \"Failed\"]").Count;
            ////MessageBox.Show("Number of failed login is " + NoFailedCount.ToString());

            SqlConnection Cn = new SqlConnection(ConfigurationManager.ConnectionStrings["xmlDBOrigConnectionString1"].ConnectionString);
            SqlCommand Com = new SqlCommand(@"SELECT COUNT(*) FROM loginLog where attempt = 'Success' ", Cn);
            SqlCommand Com1 = new SqlCommand(@"SELECT COUNT(*) FROM loginLog where attempt = 'Failed' ", Cn);
            Cn.Open();

            Int32 NoSuccessCount = (Int32)Com.ExecuteScalar();
            Int32 NoFailedCount = (Int32)Com1.ExecuteScalar();


            Cn.Close();

            LoginStats Stats = new LoginStats();
            Stats.NoFailedCount = NoFailedCount;
            Stats.NoSuccessCount = NoSuccessCount;
            return Stats;


            
            //LoginStats Stats = new LoginStats();
            //Stats.NoFailedCount = NoFailedCount;
            //Stats.NoSuccessCount = NoSuccessCount;
            //return Stats;

        }

            
    }

    public class LoginStats
    {
        public int NoSuccessCount { set; get; }
        public int NoFailedCount { set; get; }


        
    }
}
