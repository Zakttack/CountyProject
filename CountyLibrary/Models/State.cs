using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountyLibrary.Models
{
    public class State : BaseModel<State>
    {
        public State(string stateName)
        {
            StateName = stateName;
        }

        public string StateName
        {
            get;
            private set;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return StateName.GetHashCode();
        }

        public override string ToString()
        {
            return StateName;
        }

        public static bool operator== (State a, State b)
        {
            if (IsNull(a))
            {
                return IsNull(b);
            }
            return a.Equals(b);
        }

        public static bool operator!= (State a, State b)
        {
            if (IsNull(a))
            {
                return !IsNull(b);
            }
            return !a.Equals(b);
        }
    }
}