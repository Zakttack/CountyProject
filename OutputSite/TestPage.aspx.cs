using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CountyProject
{
    public partial class TestPage : Page
    {
        public static Attempt CurrentAttempt
        {
            get;
            private set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                stateNameLabel.Text = UserMainPage.SelectedState.CountyTable.TableName;
                CurrentAttempt = new Attempt(testTable);
            }
        }
    }
}