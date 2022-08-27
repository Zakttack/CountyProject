using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace CountyProject
{
    public class QuestionEntries : ICollection<QuestionEntry>
    {
        private readonly Database database;

        public QuestionEntries()
        {
            database = new Database("Result");
        }

        public DataTable QuestionTable
        {
            get
            {
                return database.GetTable("Question");
            }
        }

        public int Count
        {
            get
            {
                return QuestionTable.Rows.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public QuestionEntry this[int index]
        {
            get
            {
                return QuestionEntry.GetQuestion(QuestionTable.Rows[index]);
            }
            set
            {
                database.Update(value);
            }
        }

        public void Add(QuestionEntry entry)
        {
            if (!Contains(entry))
            {
                database.Add(entry);
            }
        }

        public void Clear()
        {
            throw new NotSupportedException("This operation doesn't apply!!!");
        }

        public bool Contains(QuestionEntry entry)
        {
            foreach (QuestionEntry item in this)
            {
                if (item.Equals(entry))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(QuestionEntry[] collection, int index)
        {
            throw new NotSupportedException("This operation doesn't apply!!!");
        }

        public int IndexOf(QuestionEntry entry)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Equals(entry))
                {
                    return i;
                }
            }
            throw new DataException("Entry not found!!!");
        }

        public bool Remove(QuestionEntry entry)
        {
            return false;
        }

        public IEnumerator<QuestionEntry> GetEnumerator()
        {
            return new QuestionEnumerator(QuestionTable);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class QuestionEnumerator : IEnumerator<QuestionEntry>
        {
            private readonly DataTable table;
            private int index;

            public QuestionEnumerator(DataTable table)
            {
                this.table = table;
                index = 0;
            }

            public QuestionEntry Current
            {
                get
                {
                    return QuestionEntry.GetQuestion(table.Rows[index++]);
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