
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Fred.FMjrDB;

namespace Fred
{
    public partial class Videos : System.Web.UI.Page
    {
        private DataTable rs = new DataTable();



        public void Page_Load(object Sender, EventArgs E)
        {
            this.Form.DefaultButton = this.SearchButton.UniqueID;

            Title = "Fred Mwila Jr - Videos";

            if (Session["UserType"] != null)
            {
                if (Session["UserType"].ToString() == "admin")
                    {
                    AddVideoPanel.Visible = true;
                    }
            }

            if (Request.QueryString["pg"] != null)
            { 
                PageNumber = int.Parse(Request.QueryString["pg"]) - 1;
            }
            if (Request.QueryString["Search"] != null)
            {
                Search_Query.Value = Request.QueryString["Search"].Replace("+", " ");
                Search_Query.Value = Search_Query.Value.Replace("\"", "");
            }

            if (!IsPostBack)
            {
                Load_Videos();
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


        public void Load_Videos()
        {
            // If Search_Query.Value = String.Empty Then
            // rs = Database.Fetch.GenericRS("FMjr", "Get_Videos", 0, "", "", "", "", "", "")
            // Else
            // Results.Visible = True
            // rs = Database.Fetch.GenericRS("FMjr", "Get_Search_Videos", 0, "", Search_Query.Value + "*", "", "", "", "")
            // If rs.Rows.Count = 0 Then
            // Results.Text = "No Results Found for the search term """ & Search_Query.Value & """"
            // ElseIf rs.Rows.Count = 1 Then
            // Results.Text = "1 Result Found for the search term """ & Search_Query.Value & """"
            // Else
            // Results.Text = rs.Rows.Count & " results found for the search term """ & Search_Query.Value & """"
            // End If
            // End If




            
                if (Search_Query.Value == string.Empty)
                {
                    rs = GetVideos("All", 0);
                    // Results.Text = "There are " + rs.Rows.Count.ToString() + " videos";
                }
                else
                {
                try
                {
                    // Response.Redirect(Search_Query.Value);
                    rs = GetSearchVideos(Search_Query.Value, "Search", 0);
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
        }

                if (rs.Rows.Count > 0)
                {


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
                                pagebtn.BorderColor = System.Drawing.Color.Black;
                            pagebtn.ForeColor= System.Drawing.Color.Black;
                            pagebtn.BorderWidth = 3;
                            }
                        }
                    }
                    else
                        rptPaging.Visible = false;

                    VideosRepeater.DataSource = page;
                    VideosRepeater.DataBind();
                }
          
        }

        protected void rptPaging_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            PageNumber = Convert.ToInt32(e.CommandArgument);
            if (Search_Query.Value == string.Empty)
                Response.Redirect("videos?pg=" + PageNumber);
            else
                Response.Redirect("videos?search=" + Search_Query.Value.Replace(" ", "+") + "&pg=" + PageNumber);
        }


        protected void VideosRepeater_ItemEvent(object source, RepeaterItemEventArgs e)
        {
            if (Session["UserType"] != null)
            {
                if (Session["UserType"].ToString() == "admin")
                    e.Item.FindControl("editvideo").Visible = true;
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            if (Search.Text != string.Empty)
            {
                Search_Query.Value = Search.Text.Replace(" ", "+");
                Response.Redirect("videos?Search=" + Search_Query.Value);
            }
        }
    }
}
