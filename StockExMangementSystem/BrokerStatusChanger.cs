using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Configuration;

 public class BrokerStatusChanger
    {
        public static void changeBrokerStatus(string firstname, string lastname, string stockEx, string status)
        {
            string query = @"update broker_stock_ex set status = '" + status + "' where broker_id =(select broker_id from brokers where first_name = '" + firstname + "' and last_name = '" + lastname + "') and stock_ex_id = (select stock_ex_id from stock_exchanges where name = '" + stockEx + "')";
            SqlConnection Cn = new SqlConnection(ConfigurationManager.ConnectionStrings["xmlDBOrigConnectionString1"].ConnectionString);
            SqlCommand Com = new SqlCommand(query, Cn);
            Cn.Open();
            int res = Com.ExecuteNonQuery();
            Cn.Close();
        }
    }

