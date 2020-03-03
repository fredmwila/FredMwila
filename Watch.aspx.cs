using System;

using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Fred.FMjrDB;

namespace Fred
{
    public partial class Watch : System.Web.UI.Page
    {

    
        private DataTable rs;


        public void Page_Load(object Sender, EventArgs E)
        {
            if (Request.QueryString["ID"] != null)
                id_video.Value = Request.QueryString["ID"];
            else
                Response.Redirect("/videos");

            Load_Video();

            Title = vTitle.Text;
        }

        public void Load_Video()
        {
            rs = GetVideos("Watch", int.Parse(id_video.Value));

            vTitle.Text = rs.Rows[0]["title"].ToString();
            Description.Text = rs.Rows[0]["description"].ToString();
            EU.Text = rs.Rows[0]["eu"].ToString();
            ED.Text = rs.Rows[0]["ed"].ToString();
            I1.Src = rs.Rows[0]["embed"].ToString();
            titlebanner.Src = rs.Rows[0]["thumbnail"].ToString();
            // Response.Redirect(getduration(I1.Src))
            

            rs = GetSearchVideos(vTitle.Text + " " + Description.Text,"Related", int.Parse(id_video.Value));

            VideosRepeater.DataSource = rs;
            VideosRepeater.DataBind();

            rs = null;
        }
    }

}
