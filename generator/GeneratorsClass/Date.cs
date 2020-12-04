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
            try
            {
                Logger.dateStart();
                _year = generateYear(1800);
                _month = generateMonth(1);
                _day = generateDay(1);
                return new DateTime(_year, _month, _day);
            }
            catch (Exception e)
            {
                Logger.log(e);
                return getDate();
            }

        }

        public static DateTime getDate(DateTime date)
        {
            try
            {
                Logger.dateStart();
                _year = generateYear(date.Year);
                _month = generateMonth(date.Month);
                _day = generateDay(date.Day);
                return new DateTime(_year, _month, _day);
            }
            catch (Exception e)
            {
                Logger.log(e);
                return getDate(date);
            }

        }

        static int generateMonth(int month)
        {
            try
            {
                Logger.dateMonthStart();
                if (_year == DateTime.Now.Year)
                    return RandomNumber.Draw(month, DateTime.Now.Month);
                else
                    return RandomNumber.Draw(1, 12);
            }
            catch (Exception e)
            {
                Logger.log(e);
                return generateMonth(month);
            }

        }

        static int generateYear(int year)
        {
            try
            {
                Logger.dateYearStart();
                return RandomNumber.Draw(year, System.DateTime.Now.Year);
            }
            catch (Exception e)
            {
                Logger.log(e);
                return generateYear(year);
            }

        }

        static int generateDay(int day)
        {
            try
            {
                Logger.dateDayStart();
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
            catch (Exception e)
            {
                Logger.log(e);
                return generateDay(day);
            }


        }
    }
}