using System;
using System.Collections.Generic;

#nullable disable

namespace EntityGenerator.model
{
    public partial class Person
    {
        public Person()
        {
            PersonAddresses = new HashSet<PersonAddress>();
            PersonContacts = new HashSet<PersonContact>();
        }

        public long Id { get; set; }
        public string Pesel { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public char Sex { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual DeceasedPerson DeceasedPerson { get; set; }
        public virtual ICollection<PersonAddress> PersonAddresses { get; set; }
        public virtual ICollection<PersonContact> PersonContacts { get; set; }
        
        public override string ToString() => $"{Id} {Pesel} {FirstName} {SecondName} {LastName} {Sex} {BirthDate}";
    }
}
