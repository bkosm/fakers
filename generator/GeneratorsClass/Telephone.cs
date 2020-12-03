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

        public static string getPhoneNumber()
        {
            Logger.telephoneStart();
            try
            {
                StringBuilder number = new StringBuilder();
                int nr = 0;

                if (RandomNumber.Draw(1, 10) < 9)
                {
                    number.Append("0048");
                }
                else
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
            catch (Exception e)
            {
                Logger.log(e);
                return null;
            }


        }




    }
}