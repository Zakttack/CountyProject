
namespace CountyLibrary.Models
{
    public class ResultEntry
    {
        private readonly TestEntry testEntry;
        public ResultEntry(TestEntry testEntry)
        {
            this.testEntry = testEntry;
        }

        public string CountyName
        {
            get
            {
                return testEntry.County.CountyName;
            }
        }

        public string SelectedCountySeatName
        {
            get
            {
                return testEntry.SelectedCountySeat;
            }
        }

        public string Message
        {
            get
            {
                return testEntry.IsCorrect ? "Correct" : $"The Correct Answer Is: {testEntry.CorrectCountySeat}";
            }
        }


    }
}