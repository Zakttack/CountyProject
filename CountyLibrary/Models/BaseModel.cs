using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountyLibrary.Models
{
    public abstract class BaseModel<M> : IComparable<M>, IEquatable<M>
    {
        public int CompareTo(M other)
        {
            if (IsNull(other))
            {
                return 1;
            }
            return ToString().CompareTo(other.ToString());
        }

        public bool Equals(M other)
        {
            if (IsNull(other))
            {
                return false;
            }
            return ToString() == other.ToString();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is M))
            {
                return false;
            }
            return Equals((M) obj);
        }

        public abstract override int GetHashCode();

        public static bool IsNull(M value)
        {
            try
            {
                value.ToString();
                return false;
            }
            catch (NullReferenceException)
            {
                return true;
            }
        }

        public abstract override string ToString();
    }
}