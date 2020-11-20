using System;
using System.Collections.Generic;
using System.Text;
using GeneratorsClass;
using ExternalAPI;

namespace GetPersonality
{
   public  class Person
    {
        string _firstName; //
        string _secondName; //
        string _lastName; //
        char[] _PESEL; //
        DateTime _birthDate; // 
        char _sex; //

        #region CONTACT
        string _email; //
        int _phoneNumber; //

        #endregion

        #region DEAD
        bool _isDead;
        DateTime _deathDate;
        #endregion



        #region PLACE
        string _street; //
        string _city; //
        string _voivodeship; //
        string _longitude; //
        string _latiude; //
        #endregion

        public Person()
        {
            _sex = new Sex().getSex;
            _birthDate = new BirthDate().getBirthDate;
            _PESEL = new Pesel( _birthDate, _sex).getPesel;
            _setName (GetDataFromJson.getClearPerson(_sex)); //!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            _email = Email.getMail(_firstName, _lastName);
            //_phoneNumber = Telephone._getMultipleNumbers(1)[0];
            _setAddres(GetDataFromJson.getGeo("", _street));
            
            while(_city == null)
            {
                _setAddres(GetDataFromJson.getGeo("", GetDataFromJson.getClearPerson(_sex).Street));
            }
        }
        void _setName (ClearDataPerson person)
        {
            _firstName = person.FirstName;
            _secondName = person.SecondName;
            _lastName = person.LastName;
            _street = person.Street;
        }

        void _setAddres(ClearGeoAPI geo)
        {
            _city = geo.City;
            _voivodeship = geo.State;
            _longitude = geo.Longitude;
            _latiude = geo.Latiude;
        }






    }
}
