using System;
using System.Collections.Generic;
using System.Text;

namespace GeneratorsClass
{
    public class DeathDate
    {
        DateTime _date;

        public DeathDate(DateTime birthDate){ _date = new Date(birthDate).getDate; }

        public DateTime getDeathDate { get => _date; }
    }
}
