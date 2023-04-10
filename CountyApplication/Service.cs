using CountyLibrary;
using CountyLibrary.Models;

namespace CountyApplication
{
    public class Service
    {
        public static CountyService CountyService
        {
            get;
            private set;
        }

        public static State SelectedState
        {
            get;
            set;
        }

        public static void LoadEntries()
        {
            CountyService = new CountyService();
        }
    }
}