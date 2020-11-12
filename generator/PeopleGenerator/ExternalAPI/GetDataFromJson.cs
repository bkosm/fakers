using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

/*url do poczytania = https://www.codeproject.com/Tips/397574/Use-Csharp-to-get-JSON-Data-from-the-Web-and-Map-i */

namespace ExternalAPI
{
    public enum Gender { MALE, FEMALE, RANDOM};
    public static class GetDataFromJson
    {
        private static string _url = @"https://api.namefake.com/polish-poland/";
        private static T _download_serialized_json_data<T>(string url) where T : new()
        {
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }

        }

        private static ClearDataPerson _skipTitle(ClearDataPerson person)
        { 
            if(person.Name != null )
                person.Name = person.Name.Replace("inż. ", "").Replace("doc. ", "").Replace("mgr ", "").Replace("dr ", "");
            return person;
        }

        public static ClearDataPerson GetClearPerson(Gender gender)
        {
            using (var person = _download_serialized_json_data<PersonFromAPI>(_url + ((gender == Gender.MALE) ? "male/" : ((gender == Gender.FEMALE) ? "female/" : ""))))
            {

                return _skipTitle(new ClearDataPerson(person.name, person.address));
            }
        }
    }
}
