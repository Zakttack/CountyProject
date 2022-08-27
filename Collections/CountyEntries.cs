using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace CountyApplication
{
    public class CountyEntries : ICollection<CountyEntry>
    {
        private readonly Database database;

        public CountyEntries()
        {
            database = new Database("County");
        }

        public DataTable CountyTable
        {
            get
            {
                return database.GetTable("County");
            }
        }

        public CountyEntry this[int index]
        {
            get
            {
                return CountyEntry.GetCounty(CountyTable.Rows[index]);
            }
        }

        public int Count
        {
            get
            {
                return CountyTable.Rows.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(CountyEntry entry)
        {
            if (!Contains(entry))
            {
                database.Add(entry);
            }
        }

        public void Clear()
        {
            throw new NotSupportedException("The clear opperation doesn't apply!!!");
        }

        public bool Contains(CountyEntry entry)
        {
            foreach (CountyEntry current in this)
            {
                if (current.Equals(entry))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(CountyEntry[] collection, int index)
        {
            throw new NotSupportedException("The Copy To Operation Doesn't Apply!!!");
        }

        public bool Remove(CountyEntry entry)
        {
            throw new NotSupportedException("The Remove Operation Doesn't Apply!!!");
        }

        public IEnumerator<CountyEntry> GetEnumerator()
        {
            return new CountyEnumerator(CountyTable);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class CountyEnumerator : IEnumerator<CountyEntry>
        {
            private int index;
            private DataTable table;

            public CountyEnumerator(DataTable table)
            {
                index = 0;
                this.table = table;
            }

            public CountyEntry Current
            {
                get
                {
                    return CountyEntry.GetCounty(table.Rows[index++]);
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public void Dispose()
            {
                index = 0;
            }

            public bool MoveNext()
            {
                return index < table.Rows.Count;
            }

            public void Reset()
            {
                index = 0;
            }
        }
    }
}