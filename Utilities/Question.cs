using System;
using System.Web.UI.WebControls;

namespace CountyApplication
{
    public class Question
    {
        private readonly QuestionEntry questionEntry;
        public Question(AttemptEntry attempt, int position, int questionNumber)
        {
            CountySeatOptions = new DropDownList();
            UserMainPage.SelectedState.FillCountySeats(CountySeatOptions);
            CountySeatOptions.TextChanged += new EventHandler(SelectCountySeat);
            CountySeatOptions.Attributes.Add("runat", "server");
            CountySeatEntry current = UserMainPage.SelectedState[position];
            questionEntry = new QuestionEntry(questionNumber, attempt, current.County.CountyName,
                "", current.CountySeatName);
            Site2.Questions.Add(questionEntry);
        }

        public DropDownList CountySeatOptions
        {
            get;
        }

        protected void SelectCountySeat(object sender, EventArgs e)
        {
            int index = Site2.Questions.IndexOf(questionEntry);
            questionEntry.SelectedCountySeatName = CountySeatOptions.SelectedItem.Text;
            Site2.Questions[index] = questionEntry;
        }
    }
}