
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

using System.IO;
using System.Data.SqlClient;

partial class Login : System.Web.UI.Page
{

    int UserID = 0;


    protected void Page_Load(object sender, System.EventArgs e)
    {

        if (IsPostBack)
        {
            Page.Validate();


            if (Page.IsValid)
            {
                validateLogin(Username.Text, Password.Text);
            }
        }


    }



    public void validateLogin(string User, string Pass)
    {
        string Output = null;

        SqlConnection cn = new SqlConnection("Data Source=KATUTA-PC;Initial Catalog=LoginExample;Integrated Security=True");

        cn.Open();
        SqlCommand cmd = new SqlCommand("Login_SP", cn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = User;
        cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = Pass;
        cmd.Parameters.Add("@Output", SqlDbType.VarChar, 50).Value = "";

        cmd.Parameters["@Output"].Direction = ParameterDirection.Output;

        cmd.ExecuteNonQuery();

        cn.Close();

        Output = cmd.Parameters["@Output"].Value.ToString();



        if (Output == "fail")
        {
            errorLabel.Text = "Invalid User ID or Password";
        }
        else
        {
            //Login successful
            UserID = Convert.ToInt32(Output);
            //---------  Set session cookies  ---------
            Session["UserID"] = UserID;
            Session["UserName"] = Username.Text;

            Response.Redirect("defaultCS.aspx");
        }

    }
    public Login()
    {
        Load += Page_Load;
    }

}
