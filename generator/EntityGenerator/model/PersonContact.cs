using System;

#nullable disable

namespace EntityGenerator.model
{
    public partial class PersonContact
    {
        public long PersonId { get; set; }
        public long ContactId { get; set; }
        public DateTime Assigned { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Person Person { get; set; }
        
        public override string ToString() => $"{PersonId} {ContactId} {Assigned}";
    }
}
