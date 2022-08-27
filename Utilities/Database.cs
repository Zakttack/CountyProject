using Npgsql;
using System;
using System.Data;

namespace CountyApplication
{
    public class Database
    {
        private readonly NpgsqlConnection connection;

        public Database(string databaseName)
        {
            connection = new NpgsqlConnection("Server=localhost; Port=7359; " + "Database=" +
                    databaseName + "; User Id=postgres; Password=Ndsu#5973");
        }

        public void Add(object entry)
        {
            try
            {
                if (entry == null)
                {
                    throw new ArgumentNullException("Entry", "The entry doesn't exist!!!");
                }
                string statement = "INSERT INTO ";
                if (entry is User user)
                {
                    statement += "\"User\" (\"UserName\", \"Password\") VALUES ('" + user.UserName +
                        "', '" + user.Password + "');";
                }
                else if (entry is StateEntry state)
                {
                    statement += "\"State\" (\"StateName\") VALUES ('" + state.StateName + "');";
                }
                else if (entry is CountyEntry county)
                {
                    statement += "\"County\" (\"CountyName\") VALUES ('" + county.CountyName + "');";
                }
                else if (entry is CountySeatEntry countySeat)
                {
                    statement += "\"CountySeat\" (\"CountyID\", \"StateID\", \"CountySeatName\") VALUES" +
                        " (" + countySeat.County.CountyID + ", " + countySeat.State.StateID + ", '" +
                        countySeat.CountySeatName + "');";
                }
                else if (entry is AttemptEntry attempt)
                {
                    statement += "\"Attempt\" (\"StateName\",\"AttemptDate\",\"Score\",\"UserName\") " +
                        "VALUES ('" + attempt.StateName + "','" + attempt.AttemptDate + "'," + attempt.Score +
                        ",'" + attempt.UserName + "');";
                }
                else if (entry is QuestionEntry question)
                {
                    statement += "\"Question\" (\"QuestionNumber\",\"AttemptID\",\"CountyName\"," +
                        "\"SelectedCountySeatName\",\"CorrectCountySeatName\") VALUES (" +
                        question.QuestionNumber + "," + question.Attempt.ID + ",'" + question.CountyName
                        + "','" + question.SelectedCountySeatName + "','" +
                        question.CorrectCountySeatName + "');";
                }
                NpgsqlCommand addCommand = new NpgsqlCommand(statement, connection);
                if (addCommand.Connection.State != ConnectionState.Open)
                {
                    addCommand.Connection.Open();
                }
                addCommand.ExecuteNonQuery();
                addCommand.Connection.Close();
            }
            catch (Exception ex)
            {
                Site1.ViewError(ex);
            }
        }

        public DataTable GetTable(string tableName)
        {
            try
            {
                string statement = "SELECT ";
                DataTable table = new DataTable(tableName);
                switch (tableName)
                {
                    case "User": statement += "\"UserName\", \"Password\" FROM \"User\";"; break;
                    case "State": statement += "* FROM \"State\";"; break;
                    case "County": statement += "* FROM \"County\";"; break;
                    case "CountySeat": statement += "* FROM \"CountySeat\";"; break;
                    case "Attempt": statement += UserLoginPage.UserName.Equals("Admin") ? 
                            "* FROM \"Attempt\";" : "* FROM \"Attempt\" WHERE \"UserName\" = " +
                            UserLoginPage.UserName + ";"; break;
                    case "Question": statement += "* FROM \"Question\";"; break;
                }
                NpgsqlCommand viewCommand = new NpgsqlCommand(statement, connection);
                if (viewCommand.Connection.State != ConnectionState.Open)
                {
                    viewCommand.Connection.Open();
                }
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(viewCommand);
                adapter.Fill(table);
                viewCommand.Connection.Close();
                return table;
            }
            catch (Exception ex)
            {
                Site1.ViewError(ex);
                return null;
            }
        }

        public DataTable GetQuestionsByAttempt(AttemptEntry attempt)
        {
            try
            {
                DataTable table = new DataTable("Attempt" + attempt.ID);
                string statement = "SELECT \"QuestionNumber\",\"CountyName\"," +
                    "\"SelectedCountySeatName\",\"CorrectCountySeatName\" FROM \"Question\" " +
                    "WHERE \"AttemptID\" = " + attempt.ID + " ORDER BY \"QuestionNumber\" ASC;";
                NpgsqlCommand questionsViewCommand = new NpgsqlCommand(statement, connection);
                if (questionsViewCommand.Connection.State != ConnectionState.Open)
                {
                    questionsViewCommand.Connection.Open();
                }
                NpgsqlDataAdapter questionViewAdapter = new NpgsqlDataAdapter(questionsViewCommand);
                questionViewAdapter.Fill(table);
                return table;
            }
            catch (Exception ex)
            {
                Site1.ViewError(ex);
                return null;
            }
        }

        public DataTable GetTableByState(StateEntry stateEntry)
        {
            DataTable table = new DataTable(stateEntry.StateName);
            string statement = "SELECT \"CountyName\",\"CountySeatName\" FROM \"County\" LEFT JOIN \"CountySeat\"" +
                " ON \"County\".\"CountyID\" = \"CountySeat\".\"CountyID\" LEFT JOIN \"State\" ON \"CountySeat\"." +
                "\"StateID\" = \"State\".\"StateID\" WHERE \"State\".\"StateID\" = " + stateEntry.StateID + " ORDER BY " +
                "\"CountyName\" ASC;";
            NpgsqlCommand getCommand = new NpgsqlCommand(statement, connection);
            if (getCommand.Connection.State != ConnectionState.Open)
            {
                getCommand.Connection.Open();
            }
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(getCommand);
            adapter.Fill(table);
            getCommand.Connection.Close();
            return table;
        }

        public void Remove(object entry)
        {
            try
            {
                if (entry == null)
                {
                    throw new ArgumentNullException("Entry", "The Entry Doesn't Exist!!!");
                }
                string statement = "DELETE FROM ";
                if (entry is User user)
                {
                    statement += "\"User\" WHERE \"UserName\"='" + user.UserName + "' AND \"Password\"='" +
                        user.Password + "';";
                }
                else if (entry is AttemptEntry attempt)
                {
                    statement += "\"Attempt\" WHERE \"AttemptID\" = " + attempt.ID + ";";
                }
                NpgsqlCommand deleteCommand = new NpgsqlCommand(statement, connection);
                if (deleteCommand.Connection.State != ConnectionState.Open)
                {
                    deleteCommand.Connection.Open();
                }
                deleteCommand.ExecuteNonQuery();
                deleteCommand.Connection.Close();
            }
            catch (Exception ex)
            {
                Site1.ViewError(ex);
            }
        }

        public void Update(object entry)
        {
            try
            {
                if (entry == null)
                {
                    throw new ArgumentNullException("Entry", "The entry doesn't exist!!!");
                }
                string statement = "UPDATE ";
                if (entry is AttemptEntry attempt)
                {
                    statement += "\"Attempt\" SET \"Score\" = " + attempt.Score + " WHERE \"AttemptID\" = "
                        + attempt.ID + ";";
                }
                else if (entry is QuestionEntry question)
                {
                    statement += "\"Question\" SET \"SelectedCountySeatName\" = " +
                        question.SelectedCountySeatName + " WHERE \"QuestionNumber\" = " + question.QuestionNumber
                        + " AND \"AttemptID\" = " + question.Attempt.ID + ";"; 
                }
                NpgsqlCommand updateCommand = new NpgsqlCommand(statement, connection);
                if (updateCommand.Connection.State != ConnectionState.Open)
                {
                    updateCommand.Connection.Open();
                }
                updateCommand.ExecuteNonQuery();
                updateCommand.Connection.Close();
            }
            catch (Exception ex)
            {
                Site1.ViewError(ex);
            }
        }
    }
}