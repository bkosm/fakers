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

                generate(context);

                //await context.Addresses.ForEachAsync(Console.WriteLine);
            });

            model.Person personToPerson(GeneratorsClass.Person temp)
            {
                model.Person person = new model.Person();

                person.Sex = temp.Sex;
                person.BirthDate = temp.BirthDate;
                person.Pesel = temp.Pesel;
                person.FirstName = temp.FirstName;
                person.SecondName = temp.SecondName;
                person.LastName = temp.LastName;


                return person;
            }

            model.Address setAddress(string street)
            {
                ClearGeoAPI geo = GetDataFromJson.getGeo("", street);

                if (geo.City == null)
                    return null;

                model.Address address = new model.Address();
                address.City = geo.City;
                address.Street = street + HouseNumber.GetHouseNumber();
                address.Voivodeship = geo.Voivodeship;
                address.Location = new String($"{geo.Latiude}, {geo.Longitude}");

                return address;
            }


            model.PersonAddress mergePersonAddress(model.Person person, model.Address address, Date date)
            {
                var personAddress = new model.PersonAddress();
               
                if (address.City != null)
                {
                    personAddress.Person = person;
                    personAddress.Address = address;
                    personAddress.Assigned = date.getDate;
                }

                return personAddress;

            }

            model.PersonContact mergePersonContact(model.Person person, model.Contact contact, Date date)
            {
                var personContact = new model.PersonContact();
                personContact.Person = person;
                personContact.Contact = contact;
                personContact.Assigned = date.getDate;
                return personContact;
            }

            model.Contact setContact(string firstName, string lastName)
            {
                var contact = new model.Contact();
                contact.Email = Email.getMail(firstName, lastName);
                if (RandomNumber.Draw(0, 2) < 2)
                    contact.PhoneNumber = Telephone.getPhoneNumber();
                return contact;
            }

            void generate(PeopleContext context)
            {
                try
                {
                    int i = 0;
                    while (context.People.Count() < 100)
                    {
                        DateTime startTime = new DateTime(2020, 10, 1);
                        var date = new GeneratorsClass.Date(startTime);

                        Thread.Sleep(1000);
                        GeneratorsClass.Person localPeroson = new GeneratorsClass.Person();

                        var person = personToPerson(localPeroson);
                        context.People.Add(person);

                        if(localPeroson.IsDead == true)
                        {
                            var deceasedPerson = new model.DeceasedPerson();
                            deceasedPerson.Person = person;
                            deceasedPerson.DateOfDeath = new GeneratorsClass.DeathDate(localPeroson.BirthDate).getDeathDate;
                            context.DeceasedPeople.Add(deceasedPerson);
                            context.SaveChanges();
                            continue;
                        }                            

                        if (DateTime.Today.Year - person.BirthDate.Year < 65)
                        {
                            var contact = setContact(person.FirstName, person.LastName);
                            context.Contacts.Add(contact);

                            var personContact = mergePersonContact(person, contact, date);
                            contact.PersonContacts.Add(personContact);
                            if (RandomNumber.Draw(1, 5) == 5 && context.Contacts.Count() - 2 > 0)
                                context.PersonContacts.Add(mergePersonContact(person, context.Contacts.Skip(RandomNumber.Draw(0, context.Contacts.Count() - 2)).First(), date));
                        }
                        else
                        {
                            if (RandomNumber.Draw(1, 10) == 5 && context.Contacts.Count() - 2 > 0)
                            {
                                context.PersonContacts.Add(mergePersonContact(person, context.Contacts.Skip(RandomNumber.Draw(0, context.Contacts.Count() - 2)).First(), date));
                            }
                        }


                        var address = setAddress(localPeroson.Street);

                        model.PersonAddress personAddress = new model.PersonAddress();
                        if (address != null)
                        {
                            context.Addresses.Add(address);
                            personAddress = mergePersonAddress(person, address, date);
                        }
                        else
                        {
                            if (context.Addresses.Count() > 2)
                                personAddress = mergePersonAddress(person, context.Addresses.Skip(RandomNumber.Draw(0, context.Addresses.Count() - 2)).First(), date);
                        }
                        context.PersonAddresses.Add(personAddress);


                        if (RandomNumber.Draw(1, 5) == 5 && context.Contacts.Count() - 2 > 0)
                            context.PersonAddresses.Add(mergePersonAddress(person, context.Addresses.Skip(RandomNumber.Draw(0, context.Addresses.Count() - 2)).First(), date));


                        Console.WriteLine(context.People.Count());
                        context.SaveChanges();
                    }
                   

                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
 

            }
        }
    }
}