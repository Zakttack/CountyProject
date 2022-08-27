using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace CountyApplication
{
    public class CountySeatEntries : ICollection<CountySeatEntry> 
    {
        private readonly Database database;

        public CountySeatEntries()
        {
            database = new Database("County");
        }

        public DataTable CountySeatTable
        {
            get
            {
                return database.GetTable("CountySeat");
            }
        }

        public int Count
        {
            get
            {
                return CountySeatTable.Rows.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(CountySeatEntry entry)
        {
            if (!Contains(entry))
            {
                database.Add(entry);
            }
        }

        public void Clear()
        {
            throw new NotSupportedException("The clear operation doesn't apply!!!");
        }

        public bool Contains(CountySeatEntry entry)
        {
            foreach (CountySeatEntry current in this)
            {
                if (current.Equals(entry))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(CountySeatEntry[] collection, int index)
        {
            throw new NotSupportedException("The Copy To operation doesn't apply!!!");
        }

        public bool Remove(CountySeatEntry entry)
        {
            throw new NotSupportedException("The remove operation doesn't apply!!!");
        }

        public IEnumerator<CountySeatEntry> GetEnumerator()
        {
            return new CountySeatEnumerator(CountySeatTable);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class CountySeatEnumerator : IEnumerator<CountySeatEntry>
        {
            private int index;
            private DataTable table;

            public CountySeatEnumerator(DataTable table)
            {
                index = 0;
                this.table = table;
            }

            public CountySeatEntry Current
            {
                get
                {
                    return CountySeatEntry.GetCountySeat(table.Rows[index++]);
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