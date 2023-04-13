using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountyLibrary.Models
{
    public class TestEntry : IEquatable<TestEntry>
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

        public bool Equals(TestEntry other)
        {
            return entry.State == other.entry.State && entry.County == other.entry.County;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is TestEntry))
            {
                return false;
            }
            return Equals((TestEntry)obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"{entry.County.CountyName}: {SelectedCountySeat}";
        }

        public static bool operator== (TestEntry a, TestEntry b)
        {
            return a.Equals(b);
        }

        public static bool operator!= (TestEntry a, TestEntry b)
        {
            return !a.Equals(b);
        }
    }
}