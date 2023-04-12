using CountyLibrary.Models;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountyLibrary.Tables
{
    public class TestTable : IEnumerable<TestEntry>
    {
        private readonly State selectedState;
        private readonly IEnumerable<Entry> entries;
        private readonly ICollection<TestEntry> testEntries;

        public TestTable(State selectedState, IEnumerable<Entry> entries)
        {
            this.selectedState = selectedState;
            this.entries = entries;
            testEntries = new HashSet<TestEntry>();
            foreach (Entry entry in entries)
            {
                testEntries.Add(new TestEntry(entry));
            }
        }

        public IEnumerator<TestEntry> GetEnumerator()
        {
            return testEntries.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}