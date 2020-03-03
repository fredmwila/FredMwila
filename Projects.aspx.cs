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
    public partial class Projects : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadProjects();
        }

        public void LoadProjects()
        {
            DataTable dt = GetProjects();

            ProjectRepeater.DataSource = dt;
            ProjectRepeater.DataBind();

        }

        protected void ProjectRepeater_ItemDataBound(object source, RepeaterItemEventArgs e)
        {
            Repeater r2 = (Repeater)e.Item.FindControl("ProjectSkillsRepeater");
            string hiddenProject = ((HiddenField)e.Item.FindControl("HiddenProjectID")).Value.ToString();
            int projectid = int.Parse(hiddenProject);
            System.Diagnostics.Debug.WriteLine(projectid);
            
            DataTable dt = GetProjectSkills(projectid);
            System.Diagnostics.Debug.WriteLine(dt.Rows.Count);
            r2.DataSource = dt; // you'll have to query for appropriate data
            r2.DataBind();
        }
    }
}