using System;
using System.Collections.Generic;
using System.Text;

namespace ExternalAPI
{
    public  class ClearGeoAPI : DisposableElement.Disposable
    {
        string _city;
        string _street;
        string _postcode;
        string _state;
        string _country;
        string _longitude;
        string _latiude;


        public ClearGeoAPI(string city, string street, string postcode, string state, string country, string longitude, string latiude )
        {
            City = city;
            Street = street;
            Postcode = postcode;
            State = state;
            Country = country;
            Longitude= longitude;
            Latiude = latiude;
        }

        public string City { get => _city; set => _city = value; }
        public string Street { get => _street; set => _street = value; }
        public string Postcode { get => _postcode; set => _postcode = value; }
        public string State { get => _state; set => _state = value; }
        public string Longitude { get => _longitude; set => _longitude = value; }
        public string Latiude { get => _latiude; set => _latiude = value; }
        public string Country { get => _country; set => _country = value; }

        ~ClearGeoAPI()
        {
            Dispose(false);
        }
    }
}
