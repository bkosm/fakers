using System;
using System.Collections.Generic;
using System.Text;

namespace GeneratorsClass
{
    public static class DeathDate
    {
        public static DateTime getDeathDate(DateTime birthDate)
        {
            return Date.getDate(birthDate);
        }
    }
}
