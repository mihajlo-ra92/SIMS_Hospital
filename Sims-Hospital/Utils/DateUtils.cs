using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sims_Hospital.Utils
{
    public class DateUtils
    {
        public static string DateToString(DateTime date)
        {
            string dayStr = MakeDoubleDigitString(date.Day);
            string monthStr = MakeDoubleDigitString(date.Month);
            string hourStr = MakeDoubleDigitString(date.Hour);
            string minuteStr = MakeDoubleDigitString(date.Minute);
            string secondStr = MakeDoubleDigitString(date.Minute);
            string yearStr = MakeFourDigitString(date.Year);
            return dayStr + "/" + monthStr + "/" + yearStr + " " + hourStr + ":" + minuteStr + ":" + secondStr;
        }
        private static string MakeDoubleDigitString(int num)
        {
            if (num < 10)
            {
                return "0" + num.ToString();
            }
            return num.ToString();
        }
        private static string MakeFourDigitString(int num)
        {
            if (num < 10)
            {
                return "000" + num.ToString();
            }
            else if (num < 100)
            {
                return "00" + num.ToString();
            }
            else if (num < 1000)
            {
                return "0" + num.ToString();
            }
            return num.ToString();
        }
        public static bool DateIsAfterTwoDays(DateTime date)
        {
            return ((date - DateTime.Now).TotalDays > 1);
        }
        public static DateTime CreateTime(DateTime dateTime, int hours,
            int minutes, int seconds = 0, int milliseconds = 0)
        {
            return new DateTime(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                hours,
                minutes,
                seconds,
                milliseconds,
                dateTime.Kind);
        }
        public static DateTime CreateEndTime(DateTime StartDate, int lenghtMinute)
        {
            TimeSpan AppointmentLenght = new TimeSpan(lenghtMinute / 60, lenghtMinute % 60, 0);
            return StartDate.Add(AppointmentLenght);
        }
        public static bool DateTimeStarted(DateTime dateTime)
        {
            if (dateTime.Date < DateTime.Now.Date)
            {
                return true;
            }
            if (dateTime.Date == DateTime.Now.Date)
            {
                if (dateTime.TimeOfDay < DateTime.Now.TimeOfDay)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool TimespansOverlap(DateTime start1, DateTime end1, DateTime start2, DateTime end2)
        {
            if (start1.Date < end2.Date &&
                       start2.Date < end1.Date)
            {
                return true;
            }
            if (start1.Date == end2.Date &&
                start1.TimeOfDay < end2.TimeOfDay &&
               start2.Date < end1.Date)
            {
                return true;
            }
            if (start1.Date < end2.Date &&
               end1.Date == start2.Date &&
               start2.TimeOfDay < end1.TimeOfDay)
            {
                return true;
            }
            if (start1.Date == start2.Date &&
            end1.Date == end2.Date)
            {
                if (start1.TimeOfDay < end2.TimeOfDay &&
                start2.TimeOfDay < end1.TimeOfDay)
                    return true;
            }
            return false;
        }
    }
}
