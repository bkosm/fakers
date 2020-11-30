using System;
using System.Collections.Generic;
using System.Text;
using GeneratorsClass;
using ExternalAPI;
using RandomClass;


namespace GetPersonality
{
    public class Person
    {
        public string FirstName { get; set; } //
        public string SecondName { get; set; } //
        public string LastName { get; set; } //
        public char[] PESEL { get; set; } //
        public DateTime BirthDate { get; set; } // 
        public char Sex { get; set; } //

        #region CONTACT

        public string Email { get; set; } //
        public int PhoneNumber { get; set; } //

        #endregion

        #region DEAD

        public bool IsDead { get; set; }
        public DateTime DeathDate { get; set; }

        #endregion


        #region PLACE

        public string Street { get; set; } //
        public string City { get; set; } //
        public string Voivodeship { get; set; } //
        public string Longitude { get; set; } //
        public string Latiude { get; set; } //

        #endregion

        public Person()
        {
            Sex = new Sex().getSex;
            BirthDate = new BirthDate().getBirthDate;
            PESEL = new Pesel(BirthDate, Sex).getPesel;
            _setName(GetDataFromJson.getClearPerson(Sex)); //!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Email = GeneratorsClass.Email.getMail(FirstName, LastName);
            PhoneNumber = Telephone.getPhoneNumber(1);
            _setAddres(GetDataFromJson.getGeo("", Street));

            if (BirthDate.Year < 1900) IsDead = true;
            else if (RandomNumber.Draw(0, 99) > 90) IsDead = true;
            else IsDead = false;

            if (IsDead)
                DeathDate = new DeathDate(BirthDate).getDeathDate;
            else DeathDate = default;

            while (City == null)
            {
                _setAddres(GetDataFromJson.getGeo("", GetDataFromJson.getClearPerson(Sex).Street));
            }
        }

        void _setName(ClearDataPerson person)
        {
            FirstName = person.FirstName;
            SecondName = person.SecondName;
            LastName = person.LastName;
            Street = person.Street;
        }

        void _setAddres(ClearGeoAPI geo)
        {
            City = geo.City;
            Voivodeship = geo.State;
            Longitude = geo.Longitude;
            Latiude = geo.Latiude;
        }

        public override string ToString() =>
            $"{FirstName} {SecondName} {LastName} {PESEL} {BirthDate} {Sex} {Email} {PhoneNumber} {IsDead} {DeathDate} {Street} {Voivodeship} {Longitude} {Latiude}";
    }
}