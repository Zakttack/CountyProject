using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Windows.Forms;

namespace CountyProject
{
    public partial class PasswordResetPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                userNames.Items.Clear();
                foreach (User current in Site1.Users)
                {
                    userNames.Items.Add(current.UserName);
                }
                userNames.SelectedIndex = 0;
            }
        }

        protected void CheckPassword(object sender, EventArgs e)
        {
            if (newPasswordInput.Text == "")
            {
                passwordMessageOutput.Text = "Enter a password!!!";
            }
            else
            {
                resetPasswordButton.Visible = !ContainsPassword();
                passwordMessageOutput.Text = resetPasswordButton.Visible ? "Valid Password!!!" 
                    : "Invalid Password!!!";
            }
        }

        protected void UserSelected(object sender, EventArgs e)
        {
            userNameControls.Visible = userNames.SelectedItem.Text == "Admin";
            passwordResetControls.Visible = !userNameControls.Visible;
        }

        private bool ContainsPassword()
        {
            foreach(User current in Site1.Users)
            {
                if (newPasswordInput.Text == current.Password)
                {
                    return true;
                }
            }
            return false;
        }

        protected void ResetPassword(object sender, EventArgs e)
        {
            foreach (User current in Site1.Users)
            {
                if (userNames.SelectedItem.Text == current.UserName)
                {
                    current.Password = newPasswordInput.Text;
                    break;
                }
            }
            Thread messageThread = new Thread(() =>
            {
                MessageBox.Show("Password Changed Successfully!!!");
            });
            messageThread.Start();
            messageThread.Join();
            Response.Redirect("~\\UserLoginPage.aspx");
        }

        protected void UndoSelection(object sender, EventArgs e)
        {
            passwordResetControls.Visible = false;
            userNameControls.Visible = !passwordResetControls.Visible;
            userNames.SelectedIndex = 0;
        }

        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("~\\UserLoginPage.aspx");
        }
    }
}