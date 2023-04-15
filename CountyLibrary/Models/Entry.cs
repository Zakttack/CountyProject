using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountyLibrary.Models
{
    public class Entry : BaseModel<Entry>
    {
        public Entry(County county, string countySeatName, State state)
        {
            County = county;
            CountySeatName = countySeatName;
            State = state;
        }

        public County County
        {
            get;
            private set;
        }

        public State State
        {
            get;
            private set;
        }

        public string CountySeatName
        {
            get;
            private set;
        }

        public override int GetHashCode()
        {
            return County.GetHashCode() + State.GetHashCode() + CountySeatName.GetHashCode();
        }

        public override string ToString()
        {
            return $"{County.ToString()}: {CountySeatName}, {State.ToString()}";
        }
    }
}