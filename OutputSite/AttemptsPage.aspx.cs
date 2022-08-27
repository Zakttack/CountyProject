using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CountyProject
{
    public partial class AttemptsPage : Page
    {
        public static AttemptEntry SelectedAttempt
        {
            get;
            private set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                attemptsView.DataSource = Site2.Attempts.AttemptTable;
                attemptsView.DataBind();
            }
        }

        protected void NewAttempt(object sender, EventArgs e)
        {
            Response.Redirect("~\\UserMainPage.aspx");
        }

        protected void SelectAttempt(object sender, GridViewCommandEventArgs e)
        {
            attemptsView.SelectedIndex = Convert.ToInt32(e.CommandArgument);
            SelectedAttempt = Site2.Attempts[attemptsView.SelectedIndex];
        }

        protected void ViewAttempt(object sender, EventArgs e)
        {
            Response.Redirect("~\\AttemptViewPage.aspx");
        }
    }
}