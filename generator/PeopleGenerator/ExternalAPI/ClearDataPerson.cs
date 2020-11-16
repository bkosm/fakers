using System;
using System.Collections.Generic;
using System.Text;

namespace ExternalAPI
{
    public class ClearDataPerson
    {
        string _name;
        string _address;

        public ClearDataPerson(string name, string address)
        {
            _name = name;
            _address = address;
        }

        public string Name { get => _name; set => _name = value; }
        public string Address { get => _address;}
    }
}
