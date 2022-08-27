using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CountyApplication
{
    public partial class Site2 : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static AttemptEntries Attempts
        {
            get
            {
                return new AttemptEntries();
            }
        }

        public static QuestionEntries Questions
        {
            get
            {
                return new QuestionEntries();
            }
        }
    }
}