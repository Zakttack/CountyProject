﻿using CountyLibrary;
using CountyLibrary.Models;
namespace CountyApplication
{
    public class Service
    {
        public static IEnumerable<string> CountySeats
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

        public static TestEntry CurrentEntry
        {
            get;
            set;
        }

        public static State SelectedState
        {
            get;
            set;
        }

        public static IEnumerable<TestEntry> TestEntries
        {
            get
            {
                return CountyService.GetTest(SelectedState);
            }
        }

        public static void LoadEntries()
        {
            CountyService = new CountyService();
            Console.WriteLine("Entries Loaded");
        }
    }
}
