using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CountyProject
{
    public class Time : IEquatable<Time>
    {
        private readonly int month;
        private readonly int day;
        private readonly int year;
        private readonly int hour;
        private readonly int minute;
        private readonly int second;
        private Time(DateTime currentTime)
        {
            month = currentTime.Month;
            day = currentTime.Day;
            year = currentTime.Year;
            hour = currentTime.Hour;
            minute = currentTime.Minute;
            second = currentTime.Second;
        }

        public static bool operator== (Time a, Time b)
        {
            return a.month == b.month && a.day == b.day && a.year == b.year && a.hour == b.hour &&
                a.minute == b.minute && a.second == b.second;
        }

        public static bool operator!= (Time a, Time b)
        {
            return !(a == b);
        }

        public bool Equals(Time other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            return Equals(ToTime(obj));
        }

        public override int GetHashCode()
        {
            return new DateTime(year, month, day, hour, minute, second).GetHashCode();
        }

        public override string ToString()
        {
            return new DateTime(year, month, day, hour, minute, second).ToString();
        }

        public static Time ToTime(DateTime value)
        {
            return new Time(value);
        }

        public static Time ToTime(object value)
        {
            return new Time(Convert.ToDateTime(value));
        }
    }
}