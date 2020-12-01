
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel;
using GeneratorsClass;
using GetPersonality;

namespace PeopleGenerator
{

    /*
     * używamy camelCase
     * zmienne prywatne w klasach z podłogą
     * co się da to prywanie
     * każdy generator w innej klasie 
     * korzystajmy z regionów jeśli się da
     * można robić locków
     */


    //https://api.namefake.com/polish-poland
    class Program
    {
        public static void Main(string[] args)
        {



            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            //var place = ExternalAPI.GetDataFromJson.getGeo("poznan","mielzyńskiego");
            //var person = ExternalAPI.GetDataFromJson.getClearPerson(ExternalAPI.Gender.RANDOM);
            //var place = ExternalAPI.GetDataFromJson.getGeo("64-130", "Wolności");
            //Console.WriteLine(place.query.parsed.city);
            //Console.WriteLine(place.query.parsed.street);
            //Console.WriteLine(place.features[0].properties.lon);
            //Console.WriteLine(place.features[0].properties.lat);
            //Console.WriteLine(place.features[0].properties.postcode);



            //HashSet<Person> person = new HashSet<Person>();

            //while(person.Count!=10)
            //{
            //    var p = new Person();
            //    person.Add(p);
            //    Console.WriteLine(p);
            //}

            //stopWatch.Stop();
            //TimeSpan ts = stopWatch.Elapsed;
            //string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //ts.Hours, ts.Minutes, ts.Seconds,
            //ts.Milliseconds / 10);
            //Console.WriteLine("RunTime " + elapsedTime);
            ////Console.WriteLine($"Rozmiar: {tab2.Length}" );


             Console.ReadLine();
        }

    }
}
