using ExternalAPI;
using System;

namespace GeneratorsClass
{
    public class Person
    {
        public string Pesel { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public char Sex { get; set; }
        public string Street { get; set; }

        public DateTime BirthDate { get; set; }

        public Person()
        {
            Sex = new Sex().getSex;
            BirthDate = new BirthDate().getBirthDate;
            Pesel = new String(new Pesel(BirthDate, Sex).getPesel);
            SetName(GetDataFromJson.getClearPerson(Sex));
        }

        void SetName(ClearDataPerson person)
        {
            FirstName = person.FirstName;
            SecondName = person.SecondName;
            LastName = person.LastName;
            Street = person.Street;
        }
    }
}