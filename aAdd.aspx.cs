using System;
using System.Data;
using static Fred.FMjrDB;

namespace Fred
{
    public partial class aAdd : System.Web.UI.Page
    {
        private int retval;


        public void Page_Load(object Sender, EventArgs E)
        {
            Title = "Add Article";

            PreviewLabel.Text = aContent.Text;
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            if (aTitle.Text != string.Empty & aContent.Text != string.Empty)
            {
                retval = AddArticle(aTitle.Text, aContent.Text, "Fred Mwila", DateTime.Now);
                Response.Redirect("read?ID=" + retval);
            }
        }


        protected void PreviewButton_Click(object sender, EventArgs e)
        {
            PreviewLabel.Text = aContent.Text;
        }

    }

}
