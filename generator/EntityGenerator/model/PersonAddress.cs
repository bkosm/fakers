using System;

#nullable disable

namespace EntityGenerator.model
{
    public partial class PersonAddress
    {
        public long PersonId { get; set; }
        public long AddressId { get; set; }
        public DateTime Assigned { get; set; }

        public virtual Address Address { get; set; }
        public virtual Person Person { get; set; }
        
        public override string ToString() => $"{PersonId} {AddressId} {Assigned}";
    }
}