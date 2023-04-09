using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountyLibrary.Models
{
    public class State : IComparable<State>, IEquatable<State>
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

        public int CompareTo(State other)
        {
            return StateName.CompareTo(other.StateName);
        }

        public bool Equals(State other)
        {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is State))
            {
                return false;
            }
            return Equals((State)obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return StateName;
        }

        public static bool operator== (State a, State b)
        {
            return a.Equals(b);
        }

        public static bool operator!= (State a, State b)
        {
            return !a.Equals(b);
        }
    }
}