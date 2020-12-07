using System;
using System.Collections.Generic;
using System.Text;

namespace ExternalAPI
{
    public class Logger
    {
       public static int loggNumber = 0;

        public static void log(Exception e) { Console.WriteLine($"{data()} ERROR({e.GetHashCode()}): {e.Message}"); }
        public static string data()
        {
            return $"{DateTime.Now} {((loggNumber==0) ?  "" : $"{loggNumber}")}";
        }

        public static void cw(string message)
        {
            Console.WriteLine(message);
        }

        #region EMAIL
        public static void emailStart() { cw($"{data()} Generating an e-mail address"); }
        public static void emailClassic() { cw($"{data()} Generating a classic e-mail address"); }
        public static void emailFirst() { cw($"{data()} Generating a firstLetter e-mail address"); }
        public static void emailName() { cw($"{data()} Generating a name e-mail address"); }
        public static void emailDifferent() { cw($"{data()} Generating a different e-mail address"); }
        public static void emailDiacritics() { cw($"{data()} Removing diacritics"); }
        public static void emailDomain() { cw($"{data()} Getting the domain address"); }
        #endregion

        #region HOUSE_NUMBER
        public static void houseStart() { cw($"{data()} Getting a house number"); }
        #endregion

        #region PERSON
        public static void personStart() { cw($"{data()} Generating a person"); }
        #endregion

        #region API
        public static void clearPersonStart() { cw($"{data()} Generating a clearPerson"); }
        public static void clearPersonNameNull() { cw($"{data()} Person name is null"); }
        public static void clearGeoStart() { cw($"{data()} Generating a clearGeoAPI"); }
        public static void jsonGeoStart() { cw($"{data()} Get GEO data from JSON"); }
        public static void jsonPersonStart() { cw($"{data()} Get Person data from JSON"); }
        #endregion

        #region TELEPHONE
        public static void telephoneStart() { cw($"{data()} Generating a phone number"); }
        #endregion


     
        #region ENTITYGENERATOR
        public static void generatorPersonToPerson() { cw($"{data()} Casting person to person"); }
        public static void generatorSetAddress() { cw($"{data()} Setting address"); }
        public static void generatorMergePA() { cw($"{data()} Merging personAddress"); }
        public static void generatorExistsPA() { cw($"{data()} ERROR (PersonAddress): The person already lives at the address -> duplcate value"); }
        public static void generatorMergePC() { cw($"{data()} Merging personContact"); }
        public static void generatorExistsPC() { cw($"{data()} ERROR (PersonContact): Person already contains contact -> duplicat value"); }
        public static void generatorSetContact() { cw($"{data()} Setting contact"); }
        public static void generatorOneMoreContact() { cw($"{data()} Setting one more contact"); }
        public static void generatorMain() { cw($"{data()} Generating mainPerson"); }///////
        public static void start() { cw($"\n{DateTime.Now}\t--- {++loggNumber} NEW PERSON --- "); }
        public static void generatorSetAddressError() { cw($"{data()} ERROR (Setting address): city is null"); }
        public static void generatorSetAddressTheSameError() { cw($"{data()} ERROR (Setting address): city and adress are equal"); }
        public static void generatorContactDbUpdateError() { cw($"{data()} ERROR (save contact): Contact exists in the database"); }
        public static void generatorAddressDbUpdateError() { cw($"{data()} ERROR (save address): Address exists in the database"); }


        #endregion

        #region DATE
        public static void dateStart() { cw($"{data()} Generating date"); }
        public static void birthDateStart() { cw($"{data()} Generating date of birth"); }
        public static void deathDateStart() { cw($"{data()} Generating date of death"); }
        public static void dateDayStart() { cw($"{data()} Generating day"); }
        public static void dateMonthStart() { cw($"{data()} Generating month"); }
        public static void dateYearStart() { cw($"{data()} Generating year"); }

        #endregion

        #region PESEL
        public static void peselStart() { cw($"{data()} Generating PESEL"); }
        #endregion

        #region SEX
        public static void sexStart() { cw($"{data()} Generating sex"); }
        #endregion
    }

}
