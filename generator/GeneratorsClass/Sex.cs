using System;
using System.Collections.Generic;
using System.Text;
using ExternalAPI;

namespace GeneratorsClass
{
    public class Sex
    {
        char _sex;

        public Sex()
        {
            if (RandomNumber.Draw(0, 1) == 0)
                _sex = 'm';
            else
                _sex = 'f';
        }

        public Sex(Pesel pesel)
        {
            int sexNumber = (int)Char.GetNumericValue(pesel.getPesel[9]);
            if (sexNumber % 2 == 1)
                _sex = 'm';
            else
                _sex = 'f';
        }

        public char getSex { get => _sex; }
    }
}
