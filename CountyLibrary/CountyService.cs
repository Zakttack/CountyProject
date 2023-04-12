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

        public IReadOnlyList<TestEntry> GetTest(State selectedState)
        {
            return new TestTable(selectedState, GetEntriesByState(selectedState));
        }

        public IEnumerable<string> GetCountySeatsByState(State selectedState)
        {
            ICollection<string> contents = new SortedSet<string>();
            foreach (Entry entry in entries)
            {
                if (entry.State == selectedState)
                {
                    contents.Add(entry.CountySeatName);
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