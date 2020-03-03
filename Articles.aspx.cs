using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Collections;
using static Fred.FMjrDB;

namespace Fred
{
    public partial class Articles : System.Web.UI.Page
    {
        private DataTable rs;

            public void Page_Load(object Sender, EventArgs E)
            {
                this.Form.DefaultButton = this.SearchButton.UniqueID;

                Title = "Fred Mwila Jr - Articles";

                if (Session["UserType"] != null)
                {
                    if (Session["UserType"].ToString() == "admin")
                        AddArticle.Visible = true;
                }

                if (Request.QueryString["pg"] != null)
                    PageNumber = int.Parse(Request.QueryString["pg"]) - 1;
                if (Request.QueryString["Search"] != null)
                {
                    Search_Query.Value = Strings.Replace(Request.QueryString["Search"], "+", " ");
                    Search_Query.Value = Search_Query.Value.Replace( "\"", "");
                }

                if (!IsPostBack)
                {
                    Load_Articles();
                    rs = null;
                }
            }

            // This property will contain the current page number 
            public int PageNumber
            {
                get
                {
                    if (ViewState["PageNumber"] != null)
                        return Convert.ToInt32(ViewState["PageNumber"]);
                    else
                        return 0;
                }
                set
                {
                    ViewState["PageNumber"] = value;
                }
            }


        public void Load_Articles()
        {


            if (Search_Query.Value == string.Empty)
            {
                rs = GetArticles("All", 0);
            }
            else
            {
                try
                {
                    rs = GetSearchArticles(Search_Query.Value, "Search", 0); ;
                  
                    if (rs.Rows.Count == 0)
                    {
                        Results.Text = "No Results Found for the search term '" + Search_Query.Value + "'.";
                    }
                    else if (rs.Rows.Count == 1)
                    {
                        Results.Text = "1 Result Found for the search term '" + Search_Query.Value + "'.";
                    }
                    else
                    {
                        Results.Text = rs.Rows.Count + " results found for the search term '" + Search_Query.Value + "'.";
                    }
                }
                catch
                {
                    Results.Text = "There are invalid characters in the search term. please try again.";
                    rs = new DataTable();
                }
                // Response.Redirect(Search_Query.Value);
         
            }


            PagedDataSource page = new PagedDataSource();
            page.DataSource = rs.DefaultView;
            page.AllowPaging = true;
            page.PageSize = 24;
            page.CurrentPageIndex = PageNumber;


            if (page.PageCount > 1)
            {
                rptPaging.Visible = true;
                ArrayList pages = new ArrayList();
                for (int i = 0; i <= page.PageCount - 1; i++)
                    pages.Add((i + 1).ToString());

                rptPaging.DataSource = pages;
                rptPaging.DataBind();


                foreach (RepeaterItem item in rptPaging.Items)
                {
                    LinkButton pagebtn = (LinkButton)item.FindControl("btnPage");

                    if (int.Parse(pagebtn.CommandArgument.ToString()) == PageNumber + 1)
                    {
                        pagebtn.BackColor = System.Drawing.Color.Transparent;
                        pagebtn.BorderColor = System.Drawing.Color.White;
                        pagebtn.BorderWidth = 3;
                    }
                }
            }
            else
                rptPaging.Visible = false;

            ArticlesRepeater.DataSource = page;
            ArticlesRepeater.DataBind();
        }

        protected void rptPaging_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
            {
                PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
                if (Search_Query.Value == string.Empty)
                    Response.Redirect("Articles?pg=" + PageNumber + 1);
                else
                    Response.Redirect("Articles?search=" + Search_Query.Value.Replace(" ", "+") + "&pg=" + PageNumber + 1);
            }


            protected void ArticlesRepeater_ItemEvent(object source, RepeaterItemEventArgs e)
            {
                if (Session["UserType"] != null)
                {
                    if (Session["UserType"].ToString() == "admin")
                        e.Item.FindControl("editArticle").Visible = true;
                }
            }

            protected void SearchButton_Click(object sender, EventArgs e)
        {
                if (Search.Text != string.Empty)
                {
                    Search_Query.Value = Search.Text.Replace(" ", "+");
                    Response.Redirect("Articles?Search=" + Search_Query.Value);
                }
            }

    
    }

    }
