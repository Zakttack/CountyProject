using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace CountyProject
{
    public partial class Site1 : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public static CountySeatEntries CountySeatEntries
        {
            get
            {
                return new CountySeatEntries();
            }
        }

        public static CountyEntries CountyEntries
        {
            get
            {
                return new CountyEntries();
            }
        }

        public static StateEntries StateEntries
        {
            get
            {
                return new StateEntries();
            }
        }

        public static Users Users
        {
            get
            {
                return new Users();
            }
        }

        public static void ViewError(Exception ex)
        {
            MessageBoxButtons button = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Error;
            Thread errorThread = new Thread(() =>
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), button, icon);
            });
            errorThread.Start();
            errorThread.Join();
        }
    }
}