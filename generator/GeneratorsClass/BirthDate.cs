using System;
using System.Collections.Generic;
using System.Text;
using ExternalAPI;

namespace GeneratorsClass
{
    public class BirthDate
    {
        int _day;
        int _month;
        int _year;
        DateTime _date;

        public BirthDate()
        {
            _date = new Date().getDate;
        }

        public BirthDate(Pesel Pesel)
        {
            char[] pesel = Pesel.getPesel;
            _day = 10 * (int)Char.GetNumericValue(pesel[4]) + (int)Char.GetNumericValue(pesel[5]);
            _month = 10 * (int)Char.GetNumericValue(pesel[2]) + (int)Char.GetNumericValue(pesel[3]);
            _year = 10 * (int)Char.GetNumericValue(pesel[0]) + (int)Char.GetNumericValue(pesel[1]);

            if (_month >= 80)
            {
                _month -= 80;
                _year += 1800;
            }
            else if (_month > 20 && _month < 33)
            {
                _month -= 20;
                _year += 2000;
            }
            else if (_month > 40 && _month < 53)
            {
                _month -= 40;
                _year += 2100;
            }
            else
            {
                _year += 1900;
            }
            _date = new DateTime(_year, _month, _day);
        }

        public DateTime getBirthDate { get => _date; }
    }
}
