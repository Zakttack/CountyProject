using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace CountyProject
{
    public class StateEntries : ICollection<StateEntry>
    {
        private Database database;

        public StateEntries()
        {
            database = new Database("County");
        }

        public int Count
        {
            get
            {
                return StateTable.Rows.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public DataTable StateTable
        {
            get
            {
                return database.GetTable("State");
            }
        }

        public StateEntry this[int index]
        {
            get
            {
                return StateEntry.GetState(StateTable.Rows[index]);
            }
        }

        public void Add(StateEntry entry)
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

        public bool Contains(StateEntry entry)
        {
            foreach (StateEntry state in this)
            {
                if (state.Equals(entry))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(StateEntry[] collection, int index)
        {
            throw new NotSupportedException("This opperation doesn't apply!!!");
        }

        public bool Remove(StateEntry entry)
        {
            throw new NotSupportedException("This opperation doesn't apply!!!");
        }

        public IEnumerator<StateEntry> GetEnumerator()
        {
            return new StateEnumerator(StateTable);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class StateEnumerator : IEnumerator<StateEntry>
        {
            private int index;
            private DataTable table;

            public StateEnumerator(DataTable table)
            {
                index = 0;
                this.table = table;
            }

            public StateEntry Current
            {
                get
                {
                    return StateEntry.GetState(table.Rows[index++]);
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