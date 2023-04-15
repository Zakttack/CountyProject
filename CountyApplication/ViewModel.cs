using CountyLibrary.Models;

namespace CountyApplication
{
    public class ViewModel
    {
        public ViewModel(IReadOnlyList<TestEntry> testEntries)
        {
            SelectedCountySeats = new List<string>();
            while (SelectedCountySeats.Count < testEntries.Count)
            {
                SelectedCountySeats.Add("");
            }
        }

        public IList<string> SelectedCountySeats
        {
            get;
            private set;
        }
    }
}