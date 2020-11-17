using System;
using System.Collections.Generic;
using System.Text;

namespace GeneratorsClass
{
    public class Sex
    {
        char _sex;

        public Sex()
        {
            if (RandomNumber.Draw(0, 1) == 0)
                _sex = 'M';
            else
                _sex = 'F';
        }

        public Sex(Pesel pesel)
        {
            int sexNumber = (int)Char.GetNumericValue(pesel.getPesel[9]);
            if (sexNumber % 2 == 1)
                _sex = 'M';
            else
                _sex = 'F';
        }

        public char getSex { get => _sex; }
    }
}
