using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;

namespace Utils
{
    public class UserFinder
    {
        public static DataTable FindUserByUsername(string username)
        {

            //public static List<UserResult> FindUserByUsername(string username)
            //{

            //        XDocument xdoc = null;
            //        xdoc = XDocument.Load(@"../../Users.xml");

            //        var result = from usr in xdoc.Descendants("USER")
            //                     where usr.Element("USERNAME").Value == username
            //                     select new UserResult
            //                     {
            //                         username = usr.Element("USERNAME").Value,
            //                         password = usr.Element("PASSWORD").Value,
            //                         firstname = usr.Element("FIRST_NAME").Value,
            //                         lastname = usr.Element("LAST_NAME").Value,
            //                         email = usr.Element("EMAIL").Value,
            //                         DOB = usr.Element("DOB").Value,
            //                         role = usr.Element("ROLE").Value

            //                     };


            //        return result.ToList();

            //    }

            DataTable table = new DataTable();
            string query = @"select * from Users where username = '" + username + "' ";
            SqlConnection Cn = new SqlConnection(ConfigurationManager.ConnectionStrings["xmlDBOrigConnectionString1"].ConnectionString);
            SqlCommand Com = new SqlCommand(query, Cn);
            Cn.Open();
            SqlDataReader Dr = Com.ExecuteReader();
            table.Load(Dr);
            Cn.Close();
            return table;
        }

            public class UserResult
            {

            public UserResult()
            {

            }

            public String username { get; set; }
            public String password { get; set; }
            public String firstname { get; set; }
            public String lastname { get; set; }
            public String email { get; set; }
            public String DOB { get; set; }
            public String role { get; set; }


        }


        }
    }

