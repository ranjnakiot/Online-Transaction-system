﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Banking_Transaction
{
    public partial class Registration : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblAccountNumber.Text = displayAccountNumber();
            }
        }
        string displayAccountNumber()
        {
            con = new SqlConnection(Common.GetConnectionString());
            cmd = new SqlCommand(@"Select 'ABC20220000' +   CAST(MAX(CAST(SUBSTRING(AccountNumber,12,50)AS INT))+1 AS VARCHAR)AS AccountNumber from Account", con);
            con.Open();
            reader = cmd.ExecuteReader();
            string accountNumber = string.Empty;
            while (reader.Read())
            {
                accountNumber = reader["AccountNumber"].ToString();
            }
            reader.Close();
            con.Close();
            return accountNumber;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(Common.GetConnectionString());
            cmd = new SqlCommand(@"insert into Account(AccountNumber,AccountType,UserName,Gender,Email,Address,securityId,Answer,Amaunt,Password)
             values(@AccountNumber,@AccountType,@UserName,@Gender,@Email,@Address,@securityId,@Answer,@Amaunt,@Password)", con);
            cmd.Parameters.AddWithValue("@AccountNumber", lblAccountNumber.Text);
            cmd.Parameters.AddWithValue("@AccountType", lblAccountType.Text);
            cmd.Parameters.AddWithValue("@UserName", txtUsername.Text.Trim());
            cmd.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
            cmd.Parameters.AddWithValue("@securityId", ddlsecurity.SelectedValue);
            cmd.Parameters.AddWithValue("@Answer", txtAnswer.Text.Trim());
            cmd.Parameters.AddWithValue("@Amaunt", txtAmaunt.Text.Trim());
            cmd.Parameters.AddWithValue("@Password", txtpassword.Text.Trim());
            try
            {
                con.Open();
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    Response.Redirect("Login.aspx", false);
                }
                else
                {
                    error.InnerText = "invalid input.";
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Violation of    UNIQUE KEY constraint"))
                {
                    error.InnerText = "User name already exists.";
                }
                else
                {
                    Response.Write("<script>alert('Error-" + ex.Message + "');</script>");
                }
            }
            finally
            {
                con.Close();
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}

