using System;
using System.Collections.Generic;
using System.Text;
using ExternalAPI;

namespace GeneratorsClass
{
    public static class BirthDate
    {
        public static DateTime getBirthDate()
        {
            try
            {
                Logger.birthDateStart();
                DateTime now = DateTime.Now;

                if (RandomNumber.Draw(1, 10) != 3)
                    return Date.getDate(new DateTime(now.Year - 70, now.Month, now.Day));
                return Date.getDate(new DateTime(now.Year - 200, now.Month, now.Day));
            }
            catch (Exception e)
            {
                Logger.log(e);
                return getBirthDate();
            }

        }

        public static DateTime getBirthDate(char[] pesel)
        {
            var day = 10 * (int)Char.GetNumericValue(pesel[4]) + (int)Char.GetNumericValue(pesel[5]);
            var month = 10 * (int)Char.GetNumericValue(pesel[2]) + (int)Char.GetNumericValue(pesel[3]);
            var year = 10 * (int)Char.GetNumericValue(pesel[0]) + (int)Char.GetNumericValue(pesel[1]);

            if (month >= 80)
            {
                month -= 80;
                year += 1800;
            }
            else if (month > 20 && month < 33)
            {
                month -= 20;
                year += 2000;
            }
            else if (month > 40 && month < 53)
            {
                month -= 40;
                year += 2100;
            }
            else
            {
                year += 1900;
            }
            return new DateTime(year, month, day);
        }
    }
}
