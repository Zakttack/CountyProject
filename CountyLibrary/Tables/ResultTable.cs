using CountyLibrary.Models;
using System.Collections;

namespace CountyLibrary.Tables
{
    public class ResultTable : IEnumerable<ResultEntry>
    {
        private readonly ICollection<ResultEntry> resultEntries;

        public ResultTable(IEnumerable<TestEntry> testEntries)
        {
            resultEntries = new List<ResultEntry>();
            foreach (TestEntry testEntry in testEntries)
            {
                ResultEntry resultEntry = new ResultEntry(testEntry);
                resultEntries.Add(resultEntry);
            }
        }

        public IEnumerator<ResultEntry> GetEnumerator()
        {
            return resultEntries.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}