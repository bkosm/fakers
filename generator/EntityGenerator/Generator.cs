using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ExternalAPI;
using GeneratorsClass;

namespace EntityGenerator
{
    public static class Generator
    {
        static model.Person PersonToPerson(GeneratorsClass.Person temp)
        {
            model.Person person = new model.Person
            {
                Sex = temp.Sex,
                BirthDate = temp.BirthDate,
                Pesel = temp.Pesel,
                FirstName = temp.FirstName,
                SecondName = temp.SecondName,
                LastName = temp.LastName
            };

            return person;
        }

        static model.Address SetAddress(string street)
        {
            ClearGeoAPI geo = GetDataFromJson.getGeo("", street);

            if (geo.City == null)
                return null;

            model.Address address = new model.Address
            {
                City = geo.City,
                Street = street + HouseNumber.GetHouseNumber(),
                Voivodeship = geo.Voivodeship,
                Location = new String($"{geo.Latiude}, {geo.Longitude}")
            };

            return address;
        }


        static model.PersonAddress MergePersonAddress(model.Person person, model.Address address, DateTime date)
        {
            var personAddress = new model.PersonAddress();

            if (address.City != null)
            {
                personAddress.Person = person;
                personAddress.Address = address;
                personAddress.Assigned = date;
            }

            return personAddress;

        }

        static model.PersonContact MergePersonContact(model.Person person, model.Contact contact, DateTime date)
        {
            var personContact = new model.PersonContact
            {
                Person = person,
                Contact = contact,
                Assigned = date
            };
            return personContact;
        }

        static model.Contact SetContact(string firstName, string lastName)
        {
            var contact = new model.Contact
            {
                Email = Email.getMail(firstName, lastName)
            };
            if (RandomNumber.Draw(0, 2) < 2)
                contact.PhoneNumber = Telephone.getPhoneNumber();
            return contact;
        }

        public static void Generate(PeopleContext context, int? amount = null)
        {
            int i = 0;
            try
            {

                while (true)
                {
                    DateTime startTime = new DateTime(2020, 10, 1);
                    var date = Date.getDate(startTime);

                    Thread.Sleep(1000);
                    GeneratorsClass.Person localPeroson = new GeneratorsClass.Person();

                    var person = PersonToPerson(localPeroson);
                    context.People.Add(person);

                    if (localPeroson.IsDead == true)
                    {
                        var deceasedPerson = new model.DeceasedPerson
                        {
                            Person = person,
                            DateOfDeath = DeathDate.getDeathDate(localPeroson.BirthDate)
                        };
                        context.DeceasedPeople.Add(deceasedPerson);
                        context.SaveChanges();
                        continue;
                    }

                    if (DateTime.Today.Year - person.BirthDate.Year < 65)
                    {
                        var contact = SetContact(person.FirstName, person.LastName);
                        context.Contacts.Add(contact);

                        var personContact = MergePersonContact(person, contact, date);
                        contact.PersonContacts.Add(personContact);
                        if (RandomNumber.Draw(1, 5) == 5 && context.Contacts.Count() - 2 > 0)
                            context.PersonContacts.Add(MergePersonContact(person, context.Contacts.Skip(RandomNumber.Draw(0, context.Contacts.Count() - 2)).First(), date));
                    }
                    else
                    {
                        if (RandomNumber.Draw(1, 10) == 5 && context.Contacts.Count() - 2 > 0)
                        {
                            context.PersonContacts.Add(MergePersonContact(person, context.Contacts.Skip(RandomNumber.Draw(0, context.Contacts.Count() - 2)).First(), date));
                        }
                    }


                    var address = SetAddress(localPeroson.Street);

                    model.PersonAddress personAddress = new model.PersonAddress();
                    if (address != null)
                    {
                        context.Addresses.Add(address);
                        personAddress = MergePersonAddress(person, address, date);
                    }
                    else
                    {
                        if (context.Addresses.Count() > 2)
                            personAddress = MergePersonAddress(person, context.Addresses.Skip(RandomNumber.Draw(0, context.Addresses.Count() - 2)).First(), date);
                    }
                    context.PersonAddresses.Add(personAddress);


                    if (RandomNumber.Draw(1, 5) == 5 && context.Contacts.Count() - 2 > 0)
                        context.PersonAddresses.Add(MergePersonAddress(person, context.Addresses.Skip(RandomNumber.Draw(0, context.Addresses.Count() - 2)).First(), date));


                    if (i % 1000 == 0)
                        context.SaveChanges();
                    if (amount != null && amount == i)
                        break;
                }

                context.SaveChanges();



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}
