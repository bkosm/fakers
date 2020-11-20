using System;
using System.Collections.Generic;
using System.Text;
using RandomClass;

namespace GeneratorsClass
{
    public class Date
    {
        int _day;
        int _month;
        int _year;
        DateTime _date;

        public Date()
        {
            _year = generateYear(1800);
            _month = generateMonth(1);
            _day = generateDay(1);
            _date = new DateTime(_year, _month, _day);
        }

        public Date(DateTime date)
        {
            _year = generateYear(date.Year);
            _month = generateMonth(date.Month);
            _day = generateDay(date.Day);
            _date = new DateTime(_year, _month, _day);
        }

        int generateMonth(int month)
        {
            if (_year == DateTime.Now.Year)
                return RandomNumber.Draw(month, DateTime.Now.Month);
            else
                return RandomNumber.Draw(1, 12);
        }

        int generateYear(int year)
        {
            return RandomNumber.Draw(year, System.DateTime.Now.Year);
        }

        int generateDay(int day)
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

        public DateTime getDate { get => _date; }
    }
}