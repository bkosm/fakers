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
                DateTime date = new DateTime(1800, 1, 1);
                Logger.dateStart();
                _year = generateYear(1800);
                _month = generateMonth(date);
                _day = generateDay(date);
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
                _month = generateMonth(date);
                _day = generateDay(date);
                return new DateTime(_year, _month, _day);
            }
            catch (Exception e)
            {
                Logger.log(e);
                return getDate(date);
            }

        }

        public static DateTime getDeathDate(DateTime initDate)
        {
            try
            {
                Logger.dateStart();
                _year = generateYear(initDate.Year);
                if (initDate.Year < DateTime.Now.Year - 115)
                    _year = (RandomNumber.Draw(initDate.Year, initDate.Year + 115));
                _month = generateMonth(initDate);
                _day = generateDay(initDate);
                return new DateTime(_year, _month, _day);
            }
            catch (Exception e)
            {
                Logger.log(e);
                return getDate(initDate);
            }

        }

        static int generateMonth(DateTime date)
        {
            try
            {
                Logger.dateMonthStart();
                if (_year == DateTime.Now.Year && _year == date.Year)
                    return RandomNumber.Draw(date.Month, DateTime.Now.Month);
                if (_year == DateTime.Now.Year)
                    return RandomNumber.Draw(1, DateTime.Now.Month);
                if (_year == date.Year)
                    return RandomNumber.Draw(date.Month, 12);

                return RandomNumber.Draw(1, 12);
            }
            catch (Exception e)
            {
                Logger.log(e);
                return generateMonth(date);
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

        static int generateDay(DateTime date)
        {
            try
            {
                Logger.dateDayStart();
                if (_year == DateTime.Now.Year && _month == DateTime.Now.Month && _year == date.Year &&
                    _month == date.Month)
                    return RandomNumber.Draw(date.Day, DateTime.Now.Day);
                if (_year == DateTime.Now.Year && _month == DateTime.Now.Month)
                    return RandomNumber.Draw(1, DateTime.Now.Day);
                if ((_year == date.Year && _month == date.Month) && (_month == 1 || _month == 3 || _month == 5 ||
                                                                     _month == 7 || _month == 8 || _month == 10 ||
                                                                     _month == 12))
                    return RandomNumber.Draw(date.Day, 31);
                if ((_year == date.Year && _month == date.Month) &&
                    (_month == 2 && (_year % 4 == 0 && _year % 100 != 0)))
                    return RandomNumber.Draw(date.Day, 29);
                if (_year == date.Year && _month == date.Month && _month == 2)
                    return RandomNumber.Draw(date.Day, 28);


                if (_month == 1 || _month == 3 || _month == 5 || _month == 7 || _month == 8 || _month == 10 ||
                    _month == 12)
                    return RandomNumber.Draw(1, 31);
                if (_month == 2 && (_year % 4 == 0 && _year % 100 != 0))
                    return RandomNumber.Draw(1, 29);
                if (_month == 2)
                    return RandomNumber.Draw(1, 28);

                return RandomNumber.Draw(1, 30);
            }
            catch (Exception e)
            {
                Logger.log(e);
                return generateDay(date);
            }
        }
    }
}