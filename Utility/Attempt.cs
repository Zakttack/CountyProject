using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CountyProject
{
    public class Attempt
    {
        private readonly AttemptEntry attemptEntry;
        private readonly HtmlTable testTable;
        public Attempt(AttemptEntry attemptEntry)
        {
            this.attemptEntry = attemptEntry;
            testTable = null;
        }

        public Attempt(HtmlTable table)
        {
            testTable = table;
            attemptEntry = new AttemptEntry(UserMainPage.SelectedState.CountyTable.TableName,
                Time.ToTime(DateTime.Now), 0.0, UserLoginPage.UserName);
            Site2.Attempts.Add(attemptEntry);
            FillQuestions();
        }

        public DataTable QuestionTable
        {
            get
            {
                Database database = new Database("Result");
                return database.GetQuestionsByAttempt(attemptEntry);
            }
        }

        public void Grade()
        {
            int totalCorrect = 0;
            foreach (DataRow row in QuestionTable.Rows)
            {
                QuestionEntry entry = new QuestionEntry(Convert.ToInt32(row["QuestionNumber"]),
                    attemptEntry, row["CountyName"].ToString(), row["SelectedCountySeatName"].ToString(),
                    row["CorrectCountySeatName"].ToString());
                if (entry.IsCorrect)
                {
                    totalCorrect++;
                }
            }
            int index = Site2.Attempts.IndexOf(attemptEntry);
            attemptEntry.Score = ((double)(totalCorrect) / QuestionTable.Rows.Count) * 100;
            Site2.Attempts[index] = attemptEntry;
        }

        private void FillQuestions()
        {
            ISet<int> choosenPositions = new SortedSet<int>();
            Random rand = new Random();
            int questionNumber = 1;
            while (choosenPositions.Count < UserMainPage.SelectedState.CountyTable.Rows.Count)
            {
                int position = rand.Next(UserMainPage.SelectedState.CountyTable.Rows.Count);
                if (choosenPositions.Add(position))
                {
                    Question current = new Question(attemptEntry, position, questionNumber);
                    HtmlTableRow row = new HtmlTableRow();
                    QuestionEntry entry = QuestionEntry.GetQuestion(questionNumber, attemptEntry.ID);
                    HtmlTableCell questionNumberCell = new HtmlTableCell();
                    Label questionNumberLabel = new Label();
                    questionNumberLabel.Text = entry.QuestionNumber + "\t";
                    questionNumberLabel.Attributes.Add("runat", "server");
                    questionNumberCell.Controls.Add(questionNumberLabel);
                    row.Cells.Add(questionNumberCell);
                    row.Controls.Add(questionNumberCell);
                    HtmlTableCell countyNameCell = new HtmlTableCell();
                    Label countyNameLabel = new Label();
                    countyNameLabel.Text = entry.CountyName + "\t";
                    countyNameLabel.Attributes.Add("runat", "server");
                    countyNameCell.Controls.Add(countyNameLabel);
                    row.Cells.Add(countyNameCell);
                    row.Controls.Add(countyNameCell);
                    HtmlTableCell countySeatCell = new HtmlTableCell();
                    countySeatCell.Controls.Add(current.CountySeatOptions);
                    row.Cells.Add(countySeatCell);
                    row.Controls.Add(countySeatCell);
                    testTable.Rows.Add(row);
                    testTable.Controls.Add(row);
                    questionNumber++;
                }
            }
        }
    }
}