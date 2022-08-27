using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace CountyApplication
{
    public class AttemptEntries : ICollection<AttemptEntry>
    {
        private readonly Database database;

        public AttemptEntries()
        {
            database = new Database("Result");
        }

        public DataTable AttemptTable
        {
            get
            {
                return database.GetTable("Attempt");
            }
        }

        public int Count
        {
            get
            {
                return AttemptTable.Rows.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public AttemptEntry this[int index]
        {
            get
            {
                return AttemptEntry.GetAttempt(AttemptTable.Rows[index]);
            }
            set
            {
                database.Update(value);
            }
        }

        public void Add(AttemptEntry entry)
        {
            database.Add(entry);
        }

        public void Clear()
        {
            throw new NotSupportedException("This operation doesn't apply!!!");
        }

        public bool Contains(AttemptEntry entry)
        {
            foreach (AttemptEntry attempt in this)
            {
                if (attempt.Equals(entry))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(AttemptEntry[] collection, int index)
        {
            throw new NotSupportedException("This operation doesn't apply!!!");
        }

        public int IndexOf(AttemptEntry entry)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Equals(entry))
                {
                    return i;
                }
            }
            throw new DataException("Entry Not Found!!!");
        }

        public bool Remove(AttemptEntry entry)
        {
            database.Remove(entry);
            return true;
        }

        public IEnumerator<AttemptEntry> GetEnumerator()
        {
            return new AttemptEnumerator(AttemptTable);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class AttemptEnumerator : IEnumerator<AttemptEntry>
        {
            private readonly DataTable table;
            private int index;

            public AttemptEnumerator(DataTable table)
            {
                this.table = table;
                index = 0;
            }

            public AttemptEntry Current
            {
                get
                {
                    return AttemptEntry.GetAttempt(table.Rows[index++]);
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