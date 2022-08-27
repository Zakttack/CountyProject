using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace CountyApplication
{
    public class Users : ICollection<User>
    {
        private readonly Database database;

        public Users()
        {
            database = new Database("Login");
        }

        public DataTable UserTable
        {
            get
            {
                return database.GetTable("User");
            }
        }

        public int Count
        {
            get
            {
                return UserTable.Rows.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public User this[int index]
        {
            get
            {
                return User.GetUser(UserTable.Rows[index]);
            }
        }

        public IEnumerator<User> GetEnumerator()
        {
            return new UserEnumerator(UserTable);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(User item)
        {
            if (!Contains(item))
            {
                database.Add(item);
            }
        }

        public void Clear()
        {
            throw new NotSupportedException("The clear opperation doesn't apply!!!");
        }

        public bool Contains(User item)
        {
            foreach (DataRow entry in UserTable.Rows)
            {
                if (User.GetUser(entry).Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(User[] array, int arrayIndex)
        {
            throw new NotSupportedException("The copy to operation is not supported!!!");
        }

        public bool Remove(User item)
        {
            database.Remove(item);
            return true;
        }

        private class UserEnumerator : IEnumerator<User>
        {
            private int index;
            private readonly DataTable table;

            public UserEnumerator(DataTable table)
            {
                this.table = table;
                index = 0;
            }

            public User Current
            {
                get
                {
                    return User.GetUser(table.Rows[index++]);
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