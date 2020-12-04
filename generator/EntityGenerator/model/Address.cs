using System.Collections.Generic;

#nullable disable

namespace EntityGenerator.model
{
    public partial class Address
    {
        public Address()
        {
            PersonAddresses = new HashSet<PersonAddress>();
        }

        public long Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Voivodeship { get; set; }
        public string Location { get; set; }

        public virtual ICollection<PersonAddress> PersonAddresses { get; set; }

        public override string ToString() => $"{Id} {Street} {City} {Voivodeship} {Location}";
    }
}
