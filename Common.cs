using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Online_Banking_Transaction
{
    public class Common
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["BankingTransactionConnectionString"].ConnectionString;
        }
    }
    public class Utils
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;

        public int accountBalance(int userId)
        {
            int balanceAmaunt = 0;
            try
            {
                con = new SqlConnection(Common.GetConnectionString());
                cmd = new SqlCommand(@"select Amaunt from Account where AccountId=@AccountId", con);
                cmd.Parameters.AddWithValue("@AccountId", userId);
                sda = new SqlDataAdapter(cmd);
                dt=new DataTable();
                sda.Fill(dt);
                balanceAmaunt = Convert.ToInt32(dt.Rows[0]["Amaunt"]) == 0 ? 0 : Convert.ToInt32(dt.Rows[0]["Amaunt"]);
            }
            catch (Exception ex)
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert('Error='"+ex.Message+"');</script>");
            }
            return balanceAmaunt;

        }
    }
        
}