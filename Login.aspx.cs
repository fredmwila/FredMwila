using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Fred.FMjrDB;

namespace Fred
{

    public partial class Login : System.Web.UI.Page
    {
        private DataTable RS;
        private DataTable RS2;
        private string retval;
        private int UserID = 0;


        protected void Page_Load(object sender, System.EventArgs e)
        {
            Page.Title = "Fred Mwila Jr - Login";

            if (Session["UserType"] == null)
            {
                LoginPanel.Visible = true;
                LogoutPanel.Visible = false;
            }
            else
            {
                LogoutPanel.Visible = true;
                LoginPanel.Visible = false;
            }

            errorLabel.Text = "";


            if (Request.QueryString.ToString() != "" & !IsPostBack)
            {
                switch (Request.QueryString["error"])
                {
                    case "1":
                        {
                            errorLabel.Text = "Your session has timed out due to inactivity.";
                            break;
                        }

                    case "2":
                        {
                            errorLabel.Text = "The session cookie was not set.  Please ensure you have cookies enabled in your browser settings.";
                            break;
                        }

                    case "3":
                        {
                            errorLabel.Text = "Access Denied";
                            break;
                        }
                }
            }
            else if (IsPostBack)
            {
                Page.Validate();


                if (Page.IsValid)
                    validateLogin(User_ID.Text, Password.Text);
            }
        }


        public void validateLogin(string ID, string Pass)
        {
            retval = GetUserID(ID, Pass);

            if (retval == "locked" | retval == "fail")
            {
                if (retval == "locked")
                    errorLabel.Text = "Invalid User ID or Password.  The account has been temporarily locked due to too many failed login attempts.  Please try again later.";
                else
                    errorLabel.Text = "Invalid User ID or Password";
            }
            else
            {
                // Login successful
                UserID = Convert.ToInt32(retval);
                RS = GetUser(UserID.ToString());
                if (RS.Rows.Count >= 1)
                {
                    // ---------  Set session cookies  ---------
                    Session["UserType"] = RS.Rows[0]["UserType"];
                    Session["PersonID"] = UserID;
                    Session["UserName"] = RS.Rows[0]["Username"];
                    Session["PersonName"] = RS.Rows[0]["F_Name"] + " " + RS.Rows[0]["L_Name"];
                    Session["FirstName"] = RS.Rows[0]["F_Name"];
                    // Session("AL") = RS.Rows(0)("AL")            
                    // Response.Redirect("hello")
                    // Response.Redirect(Session("UserType").ToString)
                    Response.Redirect("/");
                }
                else
                {
                    Session.RemoveAll();
                    errorLabel.Text = "Access Denied";
                }
                RS = null;
            }
        }


        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("/");
        }

    }
}