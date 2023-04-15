using CountyLibrary;
using CountyLibrary.Models;
namespace CountyApplication
{
    public class Service
    {
        public static IEnumerable<SelectedCountySeatView> CountySeats
        {
            get
            {
                return CountyService.GetCountySeatsByState(SelectedState);
            }
        }
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

        public static IReadOnlyList<TestEntry> TestEntries
        {
            get;
            private set;
        }

        public static IEnumerable<ResultEntry> TestResults
        {
            get
            {
                return CountyService.GetResults(TestEntries);
            }
        }

        public static void LoadEntries()
        {
            CountyService = new CountyService();
            Console.WriteLine("Entries Loaded");
        }

        public static void LoadTest()
        {
            TestEntries = CountyService.GetTest(SelectedState);
        }
    }
}
