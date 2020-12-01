using System;
using System.Collections.Generic;
using System.Text;
using RandomClass;

namespace GeneratorsClass
{
    public static class HouseNumber
    {
        
        static string[] hauseLib = new String[]{"a","b","c","d","e","f"};

        static string GetNumber()
        {
            return RandomNumber.Draw(1, 20).ToString();
        }

        static bool Draw()
        {
            if (RandomNumber.Draw(0, 1) == 1)
                return true;
            else
                return false;
        }

        public static string GetHauseNumber()
        {
            StringBuilder str = new StringBuilder();

            str.Append(GetNumber());
            if (Draw())
                str.Append(hauseLib[RandomNumber.Draw(0, hauseLib.Length-1 )]);
            if (Draw())
                str.Append($"\\{GetNumber()}");
            return str.ToString();
        }

    }
}
