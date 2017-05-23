using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


    public class BrokerStatusFilterer
    {

        public static DataTable ApprovedStatus()
        {
            return FindStatus("Approved");
        }


        public static DataTable DeniedStatus()
        {
            return FindStatus("Denied");
        }


        public static DataTable SuspendedStatus()
        {
            return FindStatus("Suspended");
        }


        private static DataTable FindStatus(String status)
        {
            DataTable table = new DataTable();
            SqlConnection Cn = new SqlConnection(ConfigurationManager.ConnectionStrings["xmlDBOrigConnectionString1"].ConnectionString);
            SqlCommand Com = new SqlCommand(@"SELECT b.first_name, b.last_name, se.name AS 'stock_exchange', bse.status FROM brokers b inner join broker_stock_ex bse on b.broker_id = bse.broker_id inner join stock_exchanges se on se.stock_ex_id = bse.stock_ex_id where bse.status ='" + status + "' order by se.name", Cn);
            Cn.Open();
            SqlDataReader Dr = Com.ExecuteReader();
            table.Load(Dr);
            Cn.Close();
            return table;



        }

    }

