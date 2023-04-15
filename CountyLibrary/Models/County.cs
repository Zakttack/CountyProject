using System.Security.Cryptography.X509Certificates;

namespace CountyLibrary.Models
{
    public class County : BaseModel<County>
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

        public override bool Equals(object obj)
        {
            if (!(obj is County))
            {
                return false;
            }
            return Equals((County)obj);
        }

        public override int GetHashCode()
        {
            return CountyName.GetHashCode();
        }

        public override string ToString()
        {
            return CountyName;
        }

        public static bool operator== (County a, County b)
        {
            if (IsNull(a))
            {
                return IsNull(b);
            }
            return a.Equals(b);
        }

        public static bool operator!= (County a, County b)
        {
            if (IsNull(a))
            {
                return !IsNull(b);
            }
            return !a.Equals(b);
        }
    }
}