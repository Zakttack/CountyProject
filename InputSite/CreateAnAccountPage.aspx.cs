using System;
using System.Threading;
using System.Web.UI;
using System.Windows.Forms;

namespace CountyProject
{
    public partial class CreateAnAccountPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CheckAttributes(object sender, EventArgs e)
        {
            userNameMessageOutput.Text = "Valid User Name!!!";
            if (userNameInput.Text == "")
            {
                userNameMessageOutput.Text = "Enter a User Name!!!";
            }
            else
            {
                foreach (User current in Site1.Users)
                {
                    if (userNameInput.Text == current.UserName)
                    {
                        userNameMessageOutput.Text = "User Already Exists!!!";
                        break;
                    }
                }
            }
            passwordMessageOutput.Text = "Valid Password!!!";
            if (passwordInput.Text == "")
            {
                passwordMessageOutput.Text = "Enter a Passowd!!!";
            }
            else
            {
                foreach (User current in Site1.Users)
                {
                    if (passwordInput.Text == current.Password)
                    {
                        passwordMessageOutput.Text = "Password Has Been Taken!!!";
                    }
                }
            }
            createAccountButton.Enabled = userNameMessageOutput.Text == "Valid User Name!!!" &&
                passwordMessageOutput.Text == "Valid Password!!!";
        }

        protected void CreateAccount(object sender, EventArgs e)
        {
            User newUser = new User(userNameInput.Text, passwordInput.Text);
            Site1.Users.Add(newUser);
            Thread messageThread = new Thread(() =>
            {
                MessageBox.Show("User Created Successfully!!!");
            });
            messageThread.Start();
            messageThread.Join();
            Response.Redirect("~\\UserLoginPage.aspx");
        }
    }
}