using System;
using System.Collections.Generic;
using System.Text;

namespace NOCA_Framework.NocaFramework.CoreFramework.DateTime
{
    public class Time
    {
        internal static bool called = false;

        public static int Year = Cosmos.HAL.RTC.Year;
        public static int Century = Cosmos.HAL.RTC.Century;
        public static int Month = Cosmos.HAL.RTC.Month;
        public static int Day = Cosmos.HAL.RTC.DayOfTheMonth;
        public static int Hour = Cosmos.HAL.RTC.Hour;
        public static int Seconds = Cosmos.HAL.RTC.Second;
        //Wrote by: Henry, for the PearOs team.
        public static string TwentyFourHourToString()
        {
            return Cosmos.HAL.RTC.Hour.ToString() + ":" + GetCorrectMinute(); ;
        }
        private static int time;
        private static string minute;
        private static int afternoonhour;
        public static string GetCorrectMinute()
        {
            time = Cosmos.HAL.RTC.Minute;
            minute = "";
            if (time == 0 || time == 1 || time == 2 || time == 3 || time == 4 || time == 5 || time == 6 || time == 7 || time == 8 || time == 9)
            {
                minute = "0" + time.ToString();
                return minute;
            }
            else
            {
                minute = time.ToString();
                return minute;
            }
        }
        public static string TwelveHourToString()
        {
            // Declare the new string
            string time;
            // Determine if it is the afternoon
            if (Cosmos.HAL.RTC.Hour > 12)
            {
                // Work out the hour of the afternoon
                afternoonhour = (int)Cosmos.HAL.RTC.Hour - 12;
                // Construct the string with the afternoon hour and 'pm'
                time = afternoonhour.ToString() + ":" + GetCorrectMinute() + "pm";
            }
            // If it's the morning
            else
            {
                // Construct the string with 'am'
                time = Cosmos.HAL.RTC.Hour.ToString() + ":" + GetCorrectMinute() + "am";
            }
            // Return the 12 Hour time as a string
            return time;
        }



        public static void Wait(int seconds)
        {
            int g = Cosmos.HAL.RTC.Second;
            while (Cosmos.HAL.RTC.Second != g + seconds) ;

        }

        public static void WaitMS(uint milliseconds)
        {
            Audio.PIT.SleepMilliseconds(milliseconds);
        }

        public static Int64 TimeStamp
        {
            get
            {
                return GetTimeStamp(Year, Month, Day, Hour, Int32.Parse(GetCorrectMinute()), Seconds, 0);
            }
        }

        public static Int64 GetTimeStamp(
                        int year, int month, int day,
                        int hour, int minute, int second, int milliseconds)
        {
            Int64 timestamp = DateToTicks(year, month, day)
                + TimeToTicks(hour, minute, second);

            return timestamp + milliseconds * TicksInMillisecond;
        }

        static readonly int[] DaysToMonth365 =
            new int[] { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365 };
        static readonly int[] DaysToMonth366 =
            new int[] { 0, 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335, 366 };
        const long TicksInSecond = TicksInMillisecond * 1000L;
        const long TicksInMillisecond = 10000L;

        public static bool IsLeapYear(int year)
        {
            if ((year < 1) || (year > 9999))
                throw new ArgumentOutOfRangeException("year", "Bad year.");

            if ((year % 4) != 0)
                return false;

            if ((year % 100) == 0)
                return ((year % 400) == 0);

            return true;
        }

        private static long DateToTicks(int year, int month, int day)
        {
            if (((year >= 1) && (year <= 9999)) && ((month >= 1) && (month <= 12)))
            {
                int[] daysToMonth = IsLeapYear(year) ? DaysToMonth366 : DaysToMonth365;
                if ((day >= 1) && (day <= (daysToMonth[month] - daysToMonth[month - 1])))
                {
                    int previousYear = year - 1;
                    int daysInPreviousYears = ((((previousYear * 365) + (previousYear / 4)) - (previousYear / 100)) + (previousYear / 400));

                    int totalDays = ((daysInPreviousYears + daysToMonth[month - 1]) + day) - 1;
                    return (totalDays * 0xc92a69c000L);
                }
            }
            throw new ArgumentOutOfRangeException();
        }

        private static long TimeToTicks(int hour, int minute, int second)
        {
            long totalSeconds = ((hour * 3600L) + (minute * 60L)) + second;
            if ((totalSeconds > 0xd6bf94d5e5L) || (totalSeconds < -922337203685L))
                throw new ArgumentOutOfRangeException();

            return (totalSeconds * TicksInSecond);
        }
    }
}
