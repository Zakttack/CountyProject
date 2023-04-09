namespace CountyLibrary.Models
{
    public class County : IComparable<County>, IEquatable<County>
    {
        public County(string countyName)
        {
            string[] parts = countyName.Split();
            for (int i = 0; i < parts.Length - 1; i++)
            {
                CountyName += parts[i];
            }
        }

        public string CountyName
        {
            get;
            private set;
        }

        public int CompareTo(County other)
        {
            return CountyName.CompareTo(other.CountyName);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is County))
            {
                return false;
            }
            return Equals((County)obj);
        }

        public bool Equals(County other)
        {
            return CompareTo(other) == 0;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return CountyName;
        }

        public static bool operator== (County a, County b)
        {
            return a.Equals(b);
        }

        public static bool operator!= (County a, County b)
        {
            return !a.Equals(b);
        }
    }
}