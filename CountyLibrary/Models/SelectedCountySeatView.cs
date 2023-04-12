using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountyLibrary.Models
{
    public class SelectedCountySeatView
    {
        public SelectedCountySeatView(string countySeatName, int indexLocation = -1)
        {
            CountySeatName = countySeatName;
            IndexLocation = indexLocation;
        }

        public string CountySeatName
        {
            get;
            private set;
        }

        public int IndexLocation
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
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return CountySeatName;
        }
    }
}
