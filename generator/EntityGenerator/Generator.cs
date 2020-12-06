using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ExternalAPI;
using GeneratorsClass;
using Microsoft.EntityFrameworkCore;

namespace EntityGenerator
{
    public static class Generator
    {
        #region PERSON
        static model.Person PersonToPerson(GeneratorsClass.Person temp)
        {

            try
            {
                Logger.generatorPersonToPerson();
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
            catch (Exception e)
            {
                Logger.log(e);
                return null;
            }
        }
        #endregion

        #region ADDRESS
        static model.Address SetAddress(string street)
        {
            try
            {
                Logger.generatorSetAddress();

                ClearGeoAPI geo = GetDataFromJson.getGeo("", street);
                try
                {
                    if (geo == null)
                        throw new NullReferenceException();
                }
                catch (NullReferenceException e)
                {
                    Logger.log(e);
                    return new model.Address();
                }


                if (geo.City == null)
                {
                    Logger.generatorSetAddressError();
                    return new model.Address { City = "null", Street = "null" };
                }

                if (geo.City == street)
                {
                    Logger.generatorSetAddressTheSameError();
                    return new model.Address { City = "null", Street = "null" };
                }

                model.Address address = new model.Address
                {
                    City = geo.City,
                    Street = street + HouseNumber.GetHouseNumber(),
                    Voivodeship = geo.Voivodeship,
                    Location = new String($"{geo.Latiude}, {geo.Longitude}")
                };

                return address;
            }
            catch (Exception e)
            {
                Logger.log(e);
                return null;
            }

        }


        static model.PersonAddress MergePersonAddress(model.Person person, model.Address address, DateTime date)
        {
            Logger.generatorMergePA();
            try
            {
                var personAddress = new model.PersonAddress();

                if (address.City != null)
                {
                    
                    personAddress.Person = person;
                    personAddress.Address = address;

                    if (RandomNumber.Draw(1, 10) < 8)
                        personAddress.Assigned = person.BirthDate;
                    else
                        personAddress.Assigned = Date.getDate(person.BirthDate);
                }

                return personAddress;
            }
            catch (Exception e)
            {
                Logger.log(e);
                return null;
            }
        }
        #endregion

        #region CONTACT
        static model.Contact SetContact(string firstName, string lastName)
        {
            Logger.generatorSetContact();
            try
            {
                var contact = new model.Contact
                {
                    Email = Email.getMail(firstName, lastName)//"m_aleks@o2.pl"
                };
                if (RandomNumber.Draw(0, 2) < 3)
                    contact.PhoneNumber = Telephone.getPhoneNumber(); //"0048721686274"; 
                return contact;
            }
            catch (Exception e)
            {
                Logger.log(e);
                return null;
            }
        }

        static model.PersonContact MergePersonContact(model.Person person, model.Contact contact)
        {
            Logger.generatorMergePC();
            var date = Date.getDate(person.BirthDate);

            try
            {
                var personContact = new model.PersonContact
                {
                    Person = person,
                    Contact = contact,
                    Assigned = date
                };
                return personContact;
            }
            catch (Exception e)
            {
                Logger.log(e);
                return null;
            }
        }
        #endregion


        public static void Generate(PeopleContext context, int? amount = null)
        {
            bool existsFlag = false;

            Logger.generatorMain();
            int i = 0;
            try
            {

                while (true)
                {
                    i++;
                    Logger.start();
                    DateTime startTime = new DateTime(2020, 10, 1);
                    var date = Date.getDate(startTime);

                    Thread.Sleep(2000);
                    
                    #region PERSON
                    GeneratorsClass.Person localPeroson = new GeneratorsClass.Person();

                    var person = PersonToPerson(localPeroson);
                    context.People.Add(person);
                    context.SaveChanges();
                    #endregion

                    #region IS_DEAD
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
                    #endregion

                    #region CONCTACT
                    int inc = 1;
                    while(true)
                    {
                        if (DateTime.Today.Year - person.BirthDate.Year < 65)
                        {
                            existsFlag = false;
                            var contact = SetContact(person.FirstName, person.LastName);
                            try
                            {

                                var test = context.Contacts.Where(e => e.Email == contact.Email).Where(p => p.PhoneNumber == contact.PhoneNumber).Count();
                                if (test > 0)
                                {
                                    existsFlag = true;
                                    throw new DbUpdateException();
                                }

                                context.Contacts.Add(contact);
                                context.SaveChanges();
                                var personContact = MergePersonContact(person, contact);
                                contact.PersonContacts.Add(personContact);
                            }
                            catch (DbUpdateException)
                            {
                                Logger.generatorContactDbUpdateError();
                                break;
                            }

                            if ((existsFlag || RandomNumber.Draw(1, (int)Math.Pow(100,inc)) == 5) && context.Contacts.Count() > 2)
                                context.PersonContacts.Add(MergePersonContact(person, context.Contacts.Skip(RandomNumber.Draw(0, context.Contacts.Count() - 2)).First()));
                        }
                        else
                        {
                            if (RandomNumber.Draw(1, 10) == 5 && context.Contacts.Count() > 2)
                            {
                                context.PersonContacts.Add(MergePersonContact(person, context.Contacts.Skip(RandomNumber.Draw(0, context.Contacts.Count() - 2)).First()));
                            }
                        }

                        context.SaveChanges();

                        if (RandomNumber.Draw(1, (int)Math.Pow(2,inc)) > 1)
                            break;
                        else
                        {
                            inc++;
                            Logger.generatorOneMoreContact();
                        }
                    }
                    #endregion

                    #region ADDRESS
                    var address = SetAddress(localPeroson.Street);

                    model.PersonAddress personAddress = new model.PersonAddress();
                                      

                    if (address.Street != "null" && address.City != "null")
                    {
                        context.SaveChanges();
                        try
                        {
                            existsFlag = false;
                            var test = context.Addresses.Where(s => s.Street == address.Street).Where(c => c.City == address.City).Count();
                            if (test > 0)
                            {
                                existsFlag = true;
                                throw new DbUpdateException();
                            }
                            context.Addresses.Add(address);
                            context.SaveChanges();
                            personAddress = MergePersonAddress(person, address, date);

                        }catch(DbUpdateException)
                        {   
                            Logger.generatorAddressDbUpdateError();
                        }
                    }
                    else
                    {
                        existsFlag = false;
                        if (context.Addresses.Count() > 2)
                            personAddress = MergePersonAddress(person, context.Addresses.Skip(RandomNumber.Draw(0, context.Addresses.Count() - 2)).First(), date);
                        if (context.PersonAddresses.Where(x => x.AddressId == personAddress.AddressId).Where(x => x.PersonId == personAddress.PersonId).Any())
                            existsFlag = true;
                    }
                    
                    if(!existsFlag)
                    {
                        context.PersonAddresses.Add(personAddress);
                        context.SaveChanges();
                    }


                    if (RandomNumber.Draw(1, 5) == 5 && context.Addresses.Count() > 2)
                        context.PersonAddresses.Add(MergePersonAddress(person, context.Addresses.Skip(RandomNumber.Draw(0, context.Addresses.Count() - 2)).First(), date));


                    #endregion

                    #region END
                    if (amount != null && amount <= i)
                        break;
                    #endregion


                    context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            context.SaveChanges();
        }
    }
}
