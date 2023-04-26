using CountyLibrary.Models;
using CountyLibrary.Tables;
namespace CountyLibrary
{
    public class CountyService
    {
        private IEnumerable<Entry> entries;
        public CountyService()
        {
            entries = new EntriesTable();
        }

        public string GetGrade(IEnumerable<ResultEntry> resultEntries)
        {
            double correctCount = 0, count = 0;
            foreach (ResultEntry entry in resultEntries)
            {
                if (entry.Message == "Correct")
                {
                    correctCount++;
                }
                count++;
            }
            double result = (correctCount / count) * 100;
            return $"{result.ToString("0.##")}% ({correctCount}/{count})";
        }

        public IEnumerable<State> States
        {
            get
            {
                ICollection<State> states = new SortedSet<State>(new StateComparer());
                foreach (Entry entry in entries)
                {
                    states.Add(entry.State);
                }
                return states;
            }
        }

        public IEnumerable<ResultEntry> GetResults(IReadOnlyList<TestEntry> testEntries)
        {
            return new ResultTable(testEntries);
        }

        public IReadOnlyList<TestEntry> GetTest(State selectedState)
        {
            return new TestTable(selectedState, GetEntriesByState(selectedState));
        }

        public IEnumerable<SelectedCountySeatView> GetCountySeatsByState(State selectedState)
        {
            ICollection<SelectedCountySeatView> contents = new SortedSet<SelectedCountySeatView>(new CountySeatComparer());
            foreach (Entry entry in entries)
            {
                if (entry.State == selectedState)
                {
                    contents.Add(new SelectedCountySeatView(entry.CountySeatName));
                }
            }
            return contents;
        }

        private IEnumerable<Entry> GetEntriesByState(State selectedState)
        {
            ICollection<Entry> subEntries = new SortedSet<Entry>(new EntryComparer());
            foreach (Entry entry in entries)
            {
                if (entry.State == selectedState)
                {
                    subEntries.Add(entry);
                }
            }
            return subEntries;
        }

        private class CountySeatComparer : IComparer<SelectedCountySeatView>
        {
            public int Compare(SelectedCountySeatView a, SelectedCountySeatView b)
            {
                return a.CountySeatName.CompareTo(b.CountySeatName);
            }
        }
        private class EntryComparer : IComparer<Entry>
        {
            public int Compare(Entry a, Entry b)
            {
                return a.County.CompareTo(b.County);
            }
        }

        private class StateComparer : IComparer<State>
        {
            public int Compare(State a, State b)
            {
                return a.CompareTo(b);
            }
        }
    }
}