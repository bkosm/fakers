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
        public bool IsDead { get; set; }

        public DateTime BirthDate { get; set; }

        public Person()
        {
            Sex = GeneratorsClass.Sex.getSex();
            BirthDate = GeneratorsClass.BirthDate.getBirthDate();
            Pesel = new String(GeneratorsClass.Pesel.getPesel(BirthDate, Sex));
            SetName(GetDataFromJson.getClearPerson(Sex));
            if (RandomNumber.Draw(0, 115) < DateTime.Now.Year - BirthDate.Year)
            {
                if (DateTime.Now.Year - BirthDate.Year > 75)
                    IsDead = true;
                else if (RandomNumber.Draw(1, 3) == 2)
                    IsDead = true;
            }
            else
                IsDead = false;
        }

        void SetName(ClearDataPerson person)
        {
            FirstName = person.FirstName;
            SecondName = person.SecondName;
            LastName = person.LastName;
            Street = person.Street;
        }

        public override string ToString()
        {
            return $"{FirstName} {SecondName} {LastName} {Sex} {Pesel} {BirthDate.ToShortDateString()}";
        }
    }
}