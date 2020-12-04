using System;
using System.Collections.Generic;
using System.Text;

namespace ExternalAPI
{
    public class Logger
    {
        //public static void () {  Console.WriteLine($"{data()}  ");}
       public static int loggNumber = 0;

        public static void log(Exception e) { Console.WriteLine($"{data()} ERROR({e.GetHashCode()}): {e.Message}"); }
        public static string data()
        {
            return $"{DateTime.Now} {loggNumber}";
        }

        #region EMAIL
        public static void emailStart() { Console.WriteLine($"{data()} Generating an e-mail address"); }
        public static void emailClassic() { Console.WriteLine($"{data()} Generating a classic e-mail address"); }
        public static void emailFirst() { Console.WriteLine($"{data()} Generating a firstLetter e-mail address"); }
        public static void emailName() { Console.WriteLine($"{data()} Generating a name e-mail address"); }
        public static void emailDifferent() { Console.WriteLine($"{data()} Generating a different e-mail address"); }
        public static void emailDiacritics() { Console.WriteLine($"{data()} Removing diacritics"); }
        public static void emailDomain() { Console.WriteLine($"{data()} Getting the domain address"); }
        #endregion

        #region HOUSE_NUMBER
        public static void houseStart() { Console.WriteLine($"{data()} Getting a house number"); }
        #endregion

        #region PERSON
        public static void personStart() { Console.WriteLine($"{data()} Generating a person"); }
        #endregion

        #region API
        public static void clearPersonStart() { Console.WriteLine($"{data()} Generating a clearPerson"); }
        public static void clearGeoStart() { Console.WriteLine($"{data()} Generating a clearGeoAPI"); }
        public static void jsonGeoStart() { Console.WriteLine($"{data()} Get GEO data from JSON"); }
        public static void jsonPersonStart() { Console.WriteLine($"{data()} Get Person data from JSON"); }
        #endregion

        #region TELEPHONE
        public static void telephoneStart() { Console.WriteLine($"{data()} Generating a phone number"); }
        #endregion


        public static void cw() { Console.WriteLine($"{data()} "); }
        #region ENTITYGENERATOR
        public static void generatorPersonToPerson() { Console.WriteLine($"{data()} Casting person to person"); }
        public static void generatorSetAddress() { Console.WriteLine($"{data()} Setting address"); }
        public static void generatorMergePA() { Console.WriteLine($"{data()} Merging personAddress"); }
        public static void generatorMergePC() { Console.WriteLine($"{data()} Merging personContact"); }
        public static void generatorSetContact() { Console.WriteLine($"{data()} Setting contact"); }
        public static void generatorMain() { Console.WriteLine($"{data()} Generating mainPerson"); }///////
        public static void start() { Console.WriteLine($"\n{DateTime.Now}\t--- {++loggNumber} NEW PERSON --- "); }
        public static void generatorSetAddressError() { Console.WriteLine($"{data()} Setting address error: city is null"); }
        public static void generatorSetAddressTheSameError() { Console.WriteLine($"{data()} Setting address error: city and adress are equal "); }


        #endregion

        #region DATE
        public static void dateStart() { Console.WriteLine($"{data()} Generating date"); }
        public static void birthDateStart() { Console.WriteLine($"{data()} Generating date of birth"); }
        public static void deathDateStart() { Console.WriteLine($"{data()} Generating date of death"); }
        public static void dateDayStart() { Console.WriteLine($"{data()} Generating day"); }
        public static void dateMonthStart() { Console.WriteLine($"{data()} Generating month"); }
        public static void dateYearStart() { Console.WriteLine($"{data()} Generating year"); }

        #endregion

        #region PESEL
        public static void peselStart() { Console.WriteLine($"{data()} Generating PESEL"); }
        #endregion

        #region SEX
        public static void sexStart() { Console.WriteLine($"{data()} Generating sex"); }
        #endregion
    }

}
