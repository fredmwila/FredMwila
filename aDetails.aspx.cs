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
    public partial class aDetails : System.Web.UI.Page
    {

        private DataTable rs;


        public void Page_Load(object Sender, EventArgs E)
        {
            Title = "Article Details";

            if (Request.QueryString["ID"] != null)
                id_article.Value = Request.QueryString["ID"];

            //if (Session["UserType"] == null)
            //    Response.Redirect("Read?ID=" + id_article.Value);
            //else if (Session["UserType"].ToString() != "admin")
            //    Response.Redirect("Read?ID=" + id_article.Value);
            if (!IsPostBack)
                Load_article();
        }

        public void Load_article()
        {
            rs = GetArticles("Read",int.Parse(id_article.Value));

            aTitle.Text = rs.Rows[0]["Title"].ToString();
            aContent.Text = rs.Rows[0]["content"].ToString();

            rs = null;
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            UpdateArticle(int.Parse(id_article.Value), aTitle.Text,aContent.Text) ;
            Response.Redirect("read?ID=" + id_article.Value);
        }

        protected void PreviewButton_Click(object sender, EventArgs e)
        {
            PreviewLabel.Text = aContent.Text;
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            DeleteArticle(int.Parse(id_article.Value));
            Response.Redirect("/articles");
        }

    }

}
