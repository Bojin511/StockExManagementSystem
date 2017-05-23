using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

    public class CompanyViewer
    {
        public static DataTable ViewCompany()
        {
            DataTable table = new DataTable();
            SqlConnection Cn = new SqlConnection(ConfigurationManager.ConnectionStrings["xmlDBOrigConnectionString1"].ConnectionString);
            SqlCommand Com = new SqlCommand(@"select top 8 c.name, sa.issued, sa.date_start, sa.date_end, cu.symbol, sp.price, sp.time_start, sp.time_end FROM companies c inner join shares s on s.company_id = c.company_id inner join shares_amounts sa on sa.share_id = s.share_id inner join shares_prices sp on sp.share_id = s.share_id inner join currencies cu on cu.currency_id = s.currency_id order by sp.time_start DESC", Cn);
            Cn.Open();
            SqlDataReader Dr = Com.ExecuteReader();
            table.Load(Dr);
            Cn.Close();
            return table;

        }

    }

