using System.Collections.Generic;

#nullable disable

namespace EntityGenerator.model
{
    public partial class Contact
    {
        public Contact()
        {
            PersonContacts = new HashSet<PersonContact>();
        }

        public long Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<PersonContact> PersonContacts { get; set; }
        
        public override string ToString() => $"{Id} {Email} {PhoneNumber}";
    }
}
