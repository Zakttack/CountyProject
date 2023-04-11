using CountyLibrary.Models;
using CountyLibrary.Tables;
namespace CountyLibrary
{
    public class CountyService
    {
        private IReadOnlyList<Entry> entries;
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

        public IEnumerable<TestEntry> GetTest(State selectedState)
        {
            return new TestTable(selectedState, entries);
        }

        private class CountyComparer : IComparer<County>
        {
            public int Compare(County a, County b)
            {
                return a.CompareTo(b);
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