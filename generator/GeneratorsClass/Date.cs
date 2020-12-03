using System;
using System.Collections.Generic;
using System.Text;
using ExternalAPI;

namespace GeneratorsClass
{
    public static class Date
    {
        private static int _day;
        private static int _month;
        private static int _year;

        public static DateTime getDate()
        {
            _year = generateYear(1800);
            _month = generateMonth(1);
            _day = generateDay(1);
            return new DateTime(_year, _month, _day);
        }

        public static DateTime getDate(DateTime date)
        {
            _year = generateYear(date.Year);
            _month = generateMonth(date.Month);
            _day = generateDay(date.Day);
            return new DateTime(_year, _month, _day);
        }

        static int generateMonth(int month)
        {
            if (_year == DateTime.Now.Year)
                return RandomNumber.Draw(month, DateTime.Now.Month);
            else
                return RandomNumber.Draw(1, 12);
        }

        static int generateYear(int year)
        {
            return RandomNumber.Draw(year, System.DateTime.Now.Year);
        }

        static int generateDay(int day)
        {
            if (_year == System.DateTime.Now.Year && _month == System.DateTime.Now.Month)
                return RandomNumber.Draw(day, System.DateTime.Now.Day);

            if (_month == 1 || _month == 3 || _month == 5 || _month == 7 || _month == 8 || _month == 10 || _month == 12)
                return RandomNumber.Draw(1, 31);
            else if (_month == 2 && (_year % 4 == 0 && _year % 100 != 0))
                return RandomNumber.Draw(1, 29);
            else if (_month == 2)
                return RandomNumber.Draw(1, 28);
            else
                return RandomNumber.Draw(1, 30);

        }
    }
}