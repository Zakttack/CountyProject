namespace CountyApplication
{
    using System;
    using System.Data;
    public class StateEntry: IEquatable<StateEntry>
    {
        private const string ERROR_MESSAGE = "State entry doesn't exist!!!";
        public StateEntry(string stateName)
        {
            StateName = stateName;
        }

        public int StateID
        {
            get
            {
                foreach (DataRow entry in Site1.StateEntries.StateTable.Rows)
                {
                    if (entry["StateName"].ToString() == StateName)
                    {
                        return Convert.ToInt32(entry["StateID"]);
                    }
                }
                throw new DataException(ERROR_MESSAGE);
            }
        }

        public string StateName
        {
            get;
        }

        public bool Equals(StateEntry entry)
        {
            try
            {
                return StateID == entry.StateID && StateName == entry.StateName;
            }
            catch (DataException)
            {
                return false;
            }
        }

        public static StateEntry GetState(DataRow entry)
        {
            return new StateEntry((string)entry["StateName"]);
        }

        public static StateEntry GetState(int id)
        {
            foreach (DataRow entry in Site1.StateEntries.StateTable.Rows)
            {
                int stateID = Convert.ToInt32(entry["StateID"]);
                if (stateID == id)
                {
                    return GetState(entry);
                }
            }
            throw new DataException(ERROR_MESSAGE);
        }
    }
}