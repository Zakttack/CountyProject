using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CountyApplication
{
    public partial class AttemptViewPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            stateNameLabel.Text = AttemptsPage.SelectedAttempt.StateName;
            attemptDateLabel.Text = AttemptsPage.SelectedAttempt.AttemptDate.ToString();
            Attempt temp = new Attempt(AttemptsPage.SelectedAttempt);
            questionsView.DataSource = temp.QuestionTable;
            questionsView.DataBind();
            scoreLabel.Text = AttemptsPage.SelectedAttempt.Score + "%";
        }

        protected void GoBackToAttempts(object sender, EventArgs e)
        {
            Response.Redirect("~\\AttemptsPage.aspx");
        }
    }
}