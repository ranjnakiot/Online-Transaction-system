using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Banking_Transaction
{
    public partial class PerformTransaction : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader dr;
        SqlTransaction transaction = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userId"] == null)
                {
                    Response.Redirect("login.aspx");
                }
                getAccountNumber();
            }
        }
        void getAccountNumber()
        {
            con = new SqlConnection(Common.GetConnectionString());
            cmd = new SqlCommand($"select AccountId,AccountNumber from Account where AccountId != {Session["userId"]}", con);
            //cmd.Parameters.AddWithValue("@AccountId", Session["userId"]);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            ddlPayeeAccountNumber.DataSource = dt;
            ddlPayeeAccountNumber.DataTextField = "AccountNumber";
            ddlPayeeAccountNumber.DataValueField = "AccountId";
            ddlPayeeAccountNumber.DataBind();

        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (Session["userId"] != null)
            {
                con = new SqlConnection(Common.GetConnectionString());
                con.Open();
                try
                {
                    int r = 0;
                    Utils utils = new Utils();
                    int balanceAmaunt = utils.accountBalance(Convert.ToInt32(Session["userId"]));
                    if (Convert.ToInt32(txtAmaunt.Text.Trim()) <= balanceAmaunt)
                    {
                        cmd = new SqlCommand(@"insert into [Transaction](SenderAccountId,ReceiverAccountId,MobileNo,Amaunt,TransactionType,Remarks) values(@SenderAccountId,@ReceiverAccountId,@MobileNo,
                        @Amaunt,@TransactionType,@Remarks )",con);

                        cmd.Parameters.AddWithValue("@SenderAccountId", Session["userId"]);
                        cmd.Parameters.AddWithValue("@ReceiverAccountId", ddlPayeeAccountNumber.SelectedValue);
                        cmd.Parameters.AddWithValue("@MobileNo", txtMobileNumber.Text.Trim());
                        cmd.Parameters.AddWithValue("@Amaunt", txtAmaunt.Text.Trim());
                        cmd.Parameters.AddWithValue("@TransactionType", "DR");
                        cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text.Trim());
                        r = cmd.ExecuteNonQuery();
                        con.Close();
                        int x = r;
                        UpdateSenderAccountBalance(Convert.ToInt32(Session["userId"]), balanceAmaunt, Convert.ToInt32(txtAmaunt.Text.Trim()), con, transaction);
                        UpdateReceiverAccountBalance(Convert.ToInt32(ddlPayeeAccountNumber.SelectedValue), Convert.ToInt32(txtAmaunt.Text.Trim()), con, transaction);
                        r = 1;
                        if (r > 0)
                        {
                            Response.Redirect("Mydebits.aspx", false);
                        }
                        else
                        {
                            error.InnerText = "Invalid Input";
                        }
                    }
                    else
                    {
                        error.InnerText = "Invalid Input";
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception)
                    {
                        Response.Write("<script>alert('" + ex.Message + "')</script>");
                    }
                }
                finally
                {
                    con.Close();
                }
            }
        }
        void UpdateSenderAccountBalance(int _senderId, int _dbAmaunt, int _amaunt, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            try
            {
                if (_dbAmaunt >= _amaunt)
                {
                    sqlConnection.Open();
                    _dbAmaunt -= _amaunt;
                    cmd = new SqlCommand("update Account set Amaunt=@Amaunt where AccountId=@AccountId", sqlConnection, sqlTransaction);
                    cmd.Parameters.AddWithValue("@Amaunt", _dbAmaunt);
                    cmd.Parameters.AddWithValue("@AccountId", _senderId);
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')");
            }
        }
        void UpdateReceiverAccountBalance(int _receiverId, int _amaunt, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            sqlConnection.Open();
            cmd = new SqlCommand("Select Amaunt from Account where AccountId=@AccountId", sqlConnection, sqlTransaction);
            cmd.Parameters.AddWithValue("@AccountId", _receiverId);
            try
            {
                dr = cmd.ExecuteReader();
                dr.Read();
                
                    int _dbAmaunt =  (int)dr["Amaunt"];
                    _dbAmaunt += _amaunt;
                sqlConnection.Close();
                sqlConnection.Open();
                cmd = new SqlCommand("update Account set Amaunt=@Amaunt where AccountId=@AccountId", sqlConnection, sqlTransaction);
                    cmd.Parameters.AddWithValue("@Amaunt", _dbAmaunt);
                    cmd.Parameters.AddWithValue("@AccountId", _receiverId);
                    cmd.ExecuteNonQuery();

                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PerformTransaction.aspx");
        }
    }
}
