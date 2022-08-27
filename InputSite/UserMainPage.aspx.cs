using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace CountyProject
{
    public partial class UserMainPage : Page
    {
        public static State SelectedState
        {
            get;
            private set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    userNameOutput.Text = UserLoginPage.UserName;
                    adminUserControls.Visible = userNameOutput.Text == "Admin";
                    stateNames.Items.Clear();
                    FillStates();
                    stateNames.SelectedIndex = 0;
                    StateSelected(sender, e);
                }
                catch (Exception ex)
                {
                    if (ex is NullReferenceException)
                    {
                        Response.Redirect("~\\UserLoginPage.aspx");
                    }
                    else
                    {
                        Site1.ViewError(ex);
                    }
                }
            }
        }

        protected void ViewUsers(object sender, EventArgs e)
        {
            usersView.Visible = !usersView.Visible;
            usersView.DataSource = Site1.Users.UserTable;
            usersView.DataBind();
        }

        protected void SelectUser(object sender, GridViewCommandEventArgs e)
        {
            usersView.SelectedIndex = Convert.ToInt32(e.CommandArgument);
        }

        protected void DeletingUser(object sender, GridViewDeleteEventArgs e)
        {
            User current = Site1.Users[usersView.SelectedIndex];
            Site1.Users.Remove(current);
            usersView.SelectedIndex = Site1.Users.Count > 0 ? 0 : -1;
            Thread deletedMessage = new Thread(() =>
            {
                MessageBox.Show("The user was deleted sucessfully!!!");
            });
            deletedMessage.Start();
            deletedMessage.Join();
            ViewUsers(sender, e);
        }

        protected void StateSelected(object sender, EventArgs e)
        {
            SelectedState = new State(stateNames.SelectedItem.Text);
            countiesView.DataSource = SelectedState.CountyTable;
            countiesView.DataBind();
        }

        protected void TakeTest(object sender, EventArgs e)
        {
            Response.Redirect("~\\TestPage.aspx");
        }

        protected void Logout(object sender, EventArgs e)
        {
            Response.Redirect("~\\UserLoginPage.aspx");
        }

        private void FillStates()
        {
            IEnumerable<string> files = Directory.EnumerateFiles(@"C:\Users\zakme\OneDrive - " +
                @"North Dakota University System\Other\PersonalProgrammingProjects\CSharp\CountyProject\" +
                @"States", "*.txt");
            foreach (string file in files)
            {
                string[] parts = file.Split('\\');
                string statePart = parts[parts.Length - 1].Trim();
                stateNames.Items.Add(statePart.Substring(0, statePart.Length - 4));
            }
        }
    }
}