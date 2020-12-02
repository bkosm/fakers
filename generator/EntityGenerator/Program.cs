using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GeneratorsClass;
using ExternalAPI;
using System.Threading;

namespace EntityGenerator
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            await ArgumentParser.RunWithParsedAsync(args, async parsed =>
            {
                await using var context = new PeopleContext(parsed.GetConnectionString());

                    generate(context, 10 );

               //await context.Addresses.ForEachAsync(Console.WriteLine);
            });

            model.Person personToPerson(GeneratorsClass.Person temp)
            {
                model.Person newOne = new model.Person();
               

                newOne.Sex = temp.Sex;
                newOne.BirthDate = temp.BirthDate;
                newOne.Pesel = temp.Pesel;
                newOne.FirstName = temp.FirstName;
                newOne.SecondName = temp.SecondName;
                newOne.LastName = temp.LastName;
                return newOne;
            }

            model.Address setAddress(string street) 
            {
                ClearGeoAPI geo = GetDataFromJson.getGeo("", street);          
                model.Address adr = new model.Address();
                adr.City = geo.City;
                adr.Street = street +  HouseNumber.GetHouseNumber();
                adr.Voivodeship = geo.Voivodeship;
                
                adr.Location = new String ($"{geo.Latiude}, {geo.Longitude}");

                return adr;
            }

            void generate(PeopleContext context, int loop)
            {
                int i = 0;
               while(i < loop)
                {
                    Thread.Sleep(1000);
                    GeneratorsClass.Person perosonL = new GeneratorsClass.Person();
                    
                    

                    var person = personToPerson(perosonL);
                    context.People.Add(person);


                    var address = setAddress(perosonL.Street);
                    if (address.City != null)
                        context.Addresses.Add(address);
                    else
                        continue;


                    context.SaveChanges();

                    var personAddress = new model.PersonAddress();
                    if(address.City != null)
                    {
                        personAddress.Person= person;
                        personAddress.Address= address;
                    }
                    context.PersonAddresses.Add(personAddress);
                    Console.WriteLine(++i);
                    context.SaveChanges();
                }

               
            }
        }
    }
}