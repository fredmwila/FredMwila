
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

partial class _Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (Session["Username"] == null)
        {
            LogIn.Visible = true;
            LogOut.Visible = false;
        }
        else
        {
            Label1.Text = "welcome " + Session["Username"].ToString();
            LogIn.Visible = false;
            LogOut.Visible = true;
        }
    }
    public _Default()
    {
        Load += Page_Load;
    }

    protected void LogIn_Click(object sender, EventArgs e)
    {
        Response.Redirect("loginvb.aspx");
    }

    protected void LogOut_Click(object sender, EventArgs e)
    {
        Session["Username"] = null;
        Session["UserID"] = null;
        LogIn.Visible = true;
        LogOut.Visible = false;
        Label1.Text = "";
    }

}