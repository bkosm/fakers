using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using ExternalAPI;
using System.Threading;
using System.Diagnostics;
using System.ServiceModel;

namespace PeopleGenerator
{

    /* używamy camelCase
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
;
            TerytWs1Client client = new TerytWs1Client();



            //Stopwatch stopWatch = new Stopwatch();
            //stopWatch.Start();
            //List<ClearDataPerson> persons = new List<ClearDataPerson>();
            //for (int i = 0; i < 10; i++)
            //{
            //    persons.Add(GetDataFromJson.GetClearPerson(Gender.RANDOM));
            //    Thread.Sleep(10);

            //}

            //TimeSpan ts = stopWatch.Elapsed;
            //string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //ts.Hours, ts.Minutes, ts.Seconds,
            //ts.Milliseconds / 10);
            //Console.WriteLine("RunTime " + elapsedTime);

            //foreach (var person in persons )
            //{
            //    Console.WriteLine($"name: {person.Name},\t\t\taddress: {person.Address}");
            //}

            //var url = @"https://api.namefake.com/polish-poland/male/";
            //var person = Rootobject._download_serialized_json_data<Rootobject>(url);
            Console.ReadLine();
        }
    }
}
