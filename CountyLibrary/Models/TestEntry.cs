using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountyLibrary.Models
{
    public class TestEntry : BaseModel<TestEntry>
    {
        private readonly Entry entry;
        public TestEntry(Entry entry)
        {
            this.entry = entry;
            SelectedCountySeat = "";
        }

        public County County
        {
            get
            {
                return entry.County;
            }
        }

        public bool IsCorrect
        {
            get
            {
                return entry.CountySeatName == SelectedCountySeat;
            }
        }

        internal string CorrectCountySeat
        {
            get
            {
                return entry.CountySeatName;
            }
        }

        public string SelectedCountySeat
        {
            get;
            set;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return County.GetHashCode() + IsCorrect.GetHashCode() + CorrectCountySeat.GetHashCode() + SelectedCountySeat.GetHashCode();
        }

        public override string ToString()
        {
            return $"{entry.County.CountyName}: {SelectedCountySeat}";
        }

        public static bool operator== (TestEntry a, TestEntry b)
        {
            if (IsNull(a))
            {
                return IsNull(b);
            }
            return a.Equals(b);
        }

        public static bool operator!= (TestEntry a, TestEntry b)
        {
            if (IsNull(a))
            {
                return !IsNull(b);
            }
            return !a.Equals(b);
        }
    }
}