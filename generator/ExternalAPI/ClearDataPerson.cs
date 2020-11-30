using System;

namespace ExternalAPI
{
    public class ClearDataPerson
    {
        string _firstName;
        string _secondName;
        string _lastName;
        string _street;

        public string FirstName { get => _firstName; }
        public string SecondName { get => _secondName;}
        public string LastName { get => _lastName; }
        public string Street { get => _street; }

        string[] splitString(string name)
        { 
            return name.Split(" ", StringSplitOptions.None);
        }

        string _skipTitle(string name)
        {
            if (name != null)
                name = name.Replace("inż. ", "").Replace("doc. ", "").Replace("mgr ", "").Replace("dr ", "");
            return name;
        }

        public ClearDataPerson(string name, string secondName, string address)
        {
            name = _skipTitle(name);
            secondName = _skipTitle(secondName);

            var nameTab = splitString(name);
            _firstName = nameTab[0];
            if(secondName!=null)
                _secondName = splitString(secondName)[0];
            _lastName = nameTab[1];    
            _street = splitString(address)[0];
        }




    }
}
