namespace CountyProject
{
    using System;
    using System.Data;
    public class CountyEntry : IEquatable<CountyEntry>
    {
        private const string ERROR_MESSAGE = "County entry doesn't exist!!!";
        public CountyEntry(string countyName)
        {
            CountyName = countyName;
        }

        public int CountyID
        {
            get
            {
                foreach (DataRow entry in Site1.CountyEntries.CountyTable.Rows)
                {
                    if (entry["CountyName"].ToString() == CountyName)
                    {
                        return Convert.ToInt32(entry["CountyID"]);
                    }
                }
                throw new DataException(ERROR_MESSAGE);
            }
        }

        public string CountyName
        {
            get;
        }

        public bool Equals(CountyEntry entry)
        {
            try
            {
                return CountyID == entry.CountyID && CountyName == entry.CountyName;
            }
            catch (DataException)
            {
                return false;
            }
        }

        public static CountyEntry GetCounty(DataRow entry)
        {
            return new CountyEntry((string)entry["CountyName"]);
        }

        public static CountyEntry GetCounty(int id)
        {
            foreach (DataRow entry in Site1.CountyEntries.CountyTable.Rows)
            {
                if (Convert.ToInt32(entry["CountyID"]) == id)
                {
                    return GetCounty(entry);
                }
            }
            throw new DataException(ERROR_MESSAGE);
        }
    }
}