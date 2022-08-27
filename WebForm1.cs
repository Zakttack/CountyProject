using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CountyApplication
{
    public partial class DatabaseConnectionPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TestConnection(object sender, EventArgs e)
        {
            try
            {

            }
            NpgsqlConnection conn = GetConnection();
        }

        private NpgsqlConnection GetConnection()
        {
            string connectionString = "Server=" + serverNameInput.Text + "; Port" + portNumberInput.Text + 
                "; Database=" + databaseNameInput.Text + "User Id=" + userInput.Text + 
                "Passowrd=" + passwordInput.Text;
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            return connection;
        }
    }
}