namespace CountyApplication
{
    using System;
    using System.Data;
    public class CountySeatEntry : IEquatable<CountySeatEntry>
    {
        public CountySeatEntry(CountyEntry county, StateEntry state, string countySeatName)
        {
            County = county;
            State = state;
            CountySeatName = countySeatName;
        }

        public CountyEntry County
        {
            get;
        }

        public StateEntry State
        {
            get;
        }

        public string CountySeatName
        {
            get;
        }

        public bool Equals(CountySeatEntry entry)
        {
            return County.Equals(entry.County) && State.Equals(entry.State) && 
                CountySeatName == entry.CountySeatName;
        }

        public static CountySeatEntry GetCountySeat(DataRow entry)
        {
            int countyID = Convert.ToInt32(entry["CountyID"]);
            CountyEntry county = CountyEntry.GetCounty(countyID);
            int stateID = Convert.ToInt32(entry["StateID"]);
            StateEntry state = StateEntry.GetState(stateID);
            string countySeatName = entry["CountySeatName"].ToString();
            return new CountySeatEntry(county, state, countySeatName);
        }
    }
}