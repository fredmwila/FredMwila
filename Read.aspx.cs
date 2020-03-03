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
    public partial class Read : System.Web.UI.Page
    {

        private DataTable rs;


        public void Page_Load(object Sender, EventArgs E)
        {
            if (Request.QueryString["ID"] != null)
            { 
                id_article.Value = Request.QueryString["ID"];

            Load_Article();
            }
            else
            {
                Response.Redirect("/articles");
            }

            Page.Title = aTitle.Text;
        }

        public void Load_Article()
        {
            rs = GetArticles("Read",int.Parse(id_article.Value));

            aTitle.Text = rs.Rows[0]["title"].ToString();
            Content.Text = rs.Rows[0]["content"].ToString();
            EU.Text = rs.Rows[0]["eu"].ToString();
            ED.Text = rs.Rows[0]["ed"].ToString();
            ProfilePic.ImageUrl = rs.Rows[0]["Profile"].ToString();
            About.Text = rs.Rows[0]["About"].ToString();
            rs = null;
        }
    }
}
