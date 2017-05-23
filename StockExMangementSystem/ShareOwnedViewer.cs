using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


    public class ShareOwnedViewer
    {
        public static DataTable ViewShareOwned(string first_name, string last_name)
        {

            DataTable table = new DataTable();
            SqlConnection Cn = new SqlConnection(ConfigurationManager.ConnectionStrings["xmlDBOrigConnectionString1"].ConnectionString);
            SqlCommand Com = new SqlCommand(@"SELECT sh.first_name, sh.last_name, c.name, shs.amount FROM share_holders sh inner join share_holder_shares shs on sh.share_holder_id = shs.share_holder_id inner join shares s on s.share_id = shs.share_id inner join companies c on c.company_id = s.company_id where sh.first_name ='" + first_name + "'and sh.last_name ='" + last_name + "'", Cn);
            Cn.Open();
            SqlDataReader Dr = Com.ExecuteReader();
            table.Load(Dr);
            Cn.Close();
            return table;

        }


    }

