using System;

#nullable disable

namespace EntityGenerator.model
{
    public partial class DeceasedPerson
    {
        public long PersonId { get; set; }
        public DateTime DateOfDeath { get; set; }

        public virtual Person Person { get; set; }
        
        public override string ToString() => $"{PersonId} {DateOfDeath}";
    }
}
