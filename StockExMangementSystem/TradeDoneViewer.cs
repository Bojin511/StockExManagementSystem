using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public class TradeDoneViewer
{
    public static DataTable ViewTradeDone(string first_name, string last_name)
    {

        DataTable table = new DataTable();
        SqlConnection Cn = new SqlConnection(ConfigurationManager.ConnectionStrings["xmlDBOrigConnectionString1"].ConnectionString);
        SqlCommand Com = new SqlCommand(@"SELECT b.first_name, b.last_name, c.name as 'company_name', se.name as 'stock_exchange_name', tt.transaction_type, t.share_amount, t.price_total, t.transaction_time FROM brokers b inner join trades t on b.broker_id = t.broker_id inner join shares s on s.share_id = t.share_id inner join companies c on c.company_id = s.company_id inner join stock_exchanges se on se.stock_ex_id = t.stock_ex_id inner join transaction_types tt on tt.type_id = t.transaction_type where b.first_name ='" + first_name + "'and b.last_name ='" + last_name + "'", Cn);
        Cn.Open();
        SqlDataReader Dr = Com.ExecuteReader();
        table.Load(Dr);
        Cn.Close();
        return table;

    }


}

