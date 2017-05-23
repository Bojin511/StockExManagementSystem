using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


    public class ShareholderViewer
    {
        public static DataTable ViewShareholder()
        {

            DataTable table = new DataTable();
            SqlConnection Cn = new SqlConnection(ConfigurationManager.ConnectionStrings["xmlDBOrigConnectionString1"].ConnectionString);
            SqlCommand Com = new SqlCommand(@"SELECT sh.first_name, sh.last_name, se.name AS 'stock_exchange', shse.status FROM share_holders sh inner join share_holder_stock_ex shse on sh.share_holder_id = shse.share_holder_id inner join stock_exchanges se on se.stock_ex_id = shse.stock_ex_id order by se.name", Cn);
            Cn.Open();
            SqlDataReader Dr = Com.ExecuteReader();
            table.Load(Dr);
            Cn.Close();
            return table;


        }
}

