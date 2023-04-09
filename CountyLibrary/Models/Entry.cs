using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountyLibrary.Models
{
    public class Entry : IEquatable<Entry>
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

        public bool Equals(Entry other)
        {
            return ToString() == other.ToString();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Entry))
            {
                return false;
            }
            return Equals((Entry)obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"{County.ToString()}: {CountySeatName}, {State.ToString()}";
        }
    }
}