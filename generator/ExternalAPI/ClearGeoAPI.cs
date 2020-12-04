using System;

namespace ExternalAPI
{
    public class ClearGeoAPI : DisposableElement.Disposable
    {
        string _city;
        string _street;
        string _voivodeship;
        string _country;
        string _longitude;
        string _latiude;

        public ClearGeoAPI(string city, string street, string voivodeship, string country, string longitude, string latiude)
        {
            Logger.clearGeoStart();
            City = city;
            Street = street;
            Voivodeship = voivodeship;
            Country = country;
            Longitude = longitude;
            Latiude = latiude;
     
        }

        public string City { get => _city; set => _city = value; }
        public string Street { get => _street; set => _street = value; }
        public string Voivodeship
        {
            get => _voivodeship;
            set
            {
                if (value == "Lesser Poland Voivodeship")
                    _voivodeship = "Małopolskie";
                else if (value == "Łódź Voivodeship")
                    _voivodeship = "Łódzkie";
                else if (value == "Greater Poland")
                    _voivodeship = "Wielkopolskie";
                else if (value == "Silesian Voivodeship")
                    _voivodeship = "Śląskie";
                else _voivodeship = value;
               
            }
        }
        public string Longitude { get => _longitude; set => _longitude = value; }
        public string Latiude { get => _latiude; set => _latiude = value; }
        public string Country { get => _country; set => _country = value; }

        ~ClearGeoAPI()
        {
            Dispose(false);
        }
    }
}
