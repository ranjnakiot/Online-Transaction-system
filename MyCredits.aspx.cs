using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Banking_Transaction
{
    
    public partial class MyCredits : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userId"] == null)
                {
                    Response.Redirect("login.aspx");
                }
                getMyCredits();
            }
        }
            void getMyCredits()
            {
                try
                {
                    con = new SqlConnection(Common.GetConnectionString());
                    cmd = new SqlCommand(@"select a.AccountNumber,a.UserName,t.Amaunt,t.Remarks from [Transaction] t inner join Account a on t.SenderAccountId=a.AccountId 
                    where t.ReceiverAccountId=@ReceiverAccountId", con);
                    cmd.Parameters.AddWithValue("@ReceiverAccountId", Session["userId"]);
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);
                    gvMyCredits.DataSource = dt;
                    gvMyCredits.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>('" + ex.Message + "')</script>");
                }
            }
    }
}