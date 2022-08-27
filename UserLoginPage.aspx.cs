using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CountyApplication
{
    public partial class UserLoginPage : Page
    {
        public static string UserName
        {
            get
            {
                return CurrentUser.UserName;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                userLogin.CreateUserText = "Create An Account!!!";
                userLogin.CreateUserUrl = "~\\CreateAnAccountPage.aspx";
                userLogin.DisplayRememberMe = CurrentUser != null;
                userLogin.DestinationPageUrl = "~\\UserMainPage.aspx";
            }
        }

        protected void Login(object sender, LoginCancelEventArgs e)
        {
            CurrentUser = new User(userLogin.UserName, userLogin.Password);
            CurrentUser.Remember = userLogin.RememberMeSet;
        }

        protected void CheckUser(object sender, AuthenticateEventArgs e)
        {
            e.Authenticated = CurrentUser.Remember || Site1.Users.Contains(CurrentUser);
        }

        protected void LoginError(object sender, EventArgs e)
        {
            userLogin.PasswordRecoveryText = "Reset Password";
            userLogin.PasswordRecoveryUrl = "~\\PasswordResetPage.aspx";
        }

        private static User CurrentUser
        {
            get;
            set;
        }

        protected void OpenMainPage(object sender, EventArgs e)
        {
            Response.Redirect(userLogin.DestinationPageUrl);
        }
    }
}