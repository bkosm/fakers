using System;
using System.Collections.Generic;
using System.Text;
using ExternalAPI;

/* 
 * W tej konfiguracji generacja miliona numerów wynosi około 6 sek 
 *
 */

namespace GeneratorsClass
{
    public static class Telephone
    {
        static int[] _numberWST = {500000000, 510000000, 530000000, 570000000,
                                   600000000, 660000000, 690000000, 720000000,
                                   730000000, 780000000, 790000000, 880000000 };

        //https://pl.qaz.wiki/wiki/Telephone_numbers_in_Europe
        static string[] code9 = new string[] { "32", "359", "420", "33", "49", "36", "39", "31", "351", "40", "421", "34", "46" }; //numery z wystąpieniem 9 liczb 

                                              
        static int _endPointNumber = 9999999;
        static int[] _numberArray;

        /// <summary>
        /// Konstruktor statyczny, wywołuje się tylko raz
        /// </summary>
        //static Telephone()
        //{
        //    _numberArray = _generateNumber();
        //}

        /// <summary>
        /// Generuje wszystkie możliwe numery 
        /// </summary>
        /// <returns></returns>
        static int[] _generateNumber()
        {
            int wst = 0;
            int[] tab = new int[199999988];
            for (int i = 0; i < 199999988; i++)
            {
                tab[i] = i + _numberWST[wst];
                if (i % _endPointNumber == 0 && wst < 11)
                    wst++;
            }
            return tab;
        }

        /// <summary>
        /// Zamienia bieżący numer na miejsce[index końcowy - index bieżący]
        /// </summary>
        /// <param name="index"></param>
        /// <param name="increment"></param>
        static void _changeNumber(int index, int increment)
        {
            _numberArray[index] = _numberArray[_numberArray.Length - increment];
        }

        /// <summary>
        /// Zmniejsza wielkość tablicy numerów o ilość pobranych numerów
        /// </summary>
        /// <param name="howMuch"></param>
        static void _changeArraySize(int howMuch)
        {
            using(var myInt = new MyInt(_numberArray.Length - howMuch))
            {
                for (int i = 0; i < myInt.Tab.Length; i++)
                    myInt.Tab[i] = _numberArray[i];

                _numberArray = new int[myInt.Tab.Length];
                Array.Copy(myInt.Tab, _numberArray, myInt.Tab.Length);
            }
        }

        /// <summary>
        /// Generuje określoną liczbę numerów telefonu
        /// </summary>
        /// <param name="howMuch"></param>
        /// <returns></returns>
        public static int[] getMultipleNumbers(int howMuch)
        {
            using (var tab = new MyInt(howMuch))
            {
                int drawIndex;

                for (int i = 1; i <= howMuch; i++)
                {
                    drawIndex = RandomNumber.Draw(0, _numberArray.Length - i);
                    tab.Tab[i - 1] = _numberArray[drawIndex];
                    _changeNumber(drawIndex, i);
                }
                _changeArraySize(howMuch);
                return tab.Tab;
            }
        }

        public static string getPhoneNumber()
        {
            StringBuilder number = new StringBuilder();
            int nr = 0;

            if (RandomNumber.Draw(1,10)<9)
            {   
                number.Append("0048");
            }else
            {
                string code = code9[RandomNumber.Draw(0, code9.Length - 1)];
                for (int i = 0; i < 4 - code.Length; i++)
                    number.Append("0");
                number.Append(code);
            }

            nr = _numberWST[RandomNumber.Draw(0, _numberWST.Length - 1)];
            nr += RandomNumber.Draw(0, _endPointNumber);

            return number.Append(nr.ToString()).ToString();
        }




    }
}