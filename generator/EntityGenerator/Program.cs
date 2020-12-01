using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GeneratorsClass;
using ExternalAPI;

namespace EntityGenerator
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            await ArgumentParser.RunWithParsedAsync(args, async parsed =>
            {
                await using var context = new PeopleContext(parsed.GetConnectionString());

                int test = 0;
               
                for(int i = 0; i < 2; i++)
                {
                    GeneratorsClass.Person temp = new GeneratorsClass.Person();
                    
                    var person = personToPerson(temp);
                    context.People.Add(person);

                    var adr = setAddress(temp.Street);

                    if (adr.City != null)
                        context.Addresses.Add(adr);



                }

                context.SaveChanges();

                await context.Addresses.ForEachAsync(Console.WriteLine);
            });

            model.Person personToPerson(GeneratorsClass.Person temp)
            {
                EntityGenerator.model.Person newOne = new EntityGenerator.model.Person();
               

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
                adr.Street = street;
                adr.Voivodeship = geo.State;
                adr.Location = new String ($"{geo.Latiude}, {geo.Longitude}");

                return adr;
            }
        }
    }
}