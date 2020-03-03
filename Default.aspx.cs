using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Fred.FMjrDB;

namespace Fred
{
    public partial class Default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Fred Mwila Jr";
            Load_Videos();
        }

        public void Load_Videos()
        {
            DataTable dt = new DataTable();

            dt = GetVideos("LatestVideos",0);
            VideosRepeater.DataSource = dt;
            VideosRepeater.DataBind();

             dt = GetVideos("LatestVideo",0);

            // vTitle.Text = rs.Rows(0)("title").ToString
            Description.Text = dt.Rows[0]["description"].ToString();
            EU.Text = dt.Rows[0]["eu"].ToString();
            ED.Text = DateTime.Parse(dt.Rows[0]["ed"].ToString()).ToString("dd MMM yyyy");
            I1.Src = dt.Rows[0]["embed"].ToString();
        }
    }
}