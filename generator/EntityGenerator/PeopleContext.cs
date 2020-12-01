using EntityGenerator.model;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EntityGenerator
{
    public partial class PeopleContext : DbContext
    {
        private static string _connString;

        public PeopleContext(string connectionString)
        {
            _connString = connectionString;
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<DeceasedPerson> DeceasedPeople { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PersonAddress> PersonAddresses { get; set; }
        public virtual DbSet<PersonContact> PersonContacts { get; set; }

        #region ScaffoldedConfig
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_connString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("address");

                entity.HasIndex(e => new {e.Street, e.City, e.Voivodeship, e.Location},
                        "address_street_city_voivodeship_location_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("city");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("location");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("street");

                entity.Property(e => e.Voivodeship)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("voivodeship");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("contact");

                entity.HasIndex(e => new {e.Email, e.PhoneNumber}, "contact_email_phone_number_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(320)
                    .HasColumnName("email");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(13)
                    .HasColumnName("phone_number");
            });

            modelBuilder.Entity<DeceasedPerson>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .HasName("deceased_person_pkey");

                entity.ToTable("deceased_person");

                entity.HasIndex(e => e.DateOfDeath, "dp_dod");

                entity.Property(e => e.PersonId)
                    .ValueGeneratedNever()
                    .HasColumnName("person_id");

                entity.Property(e => e.DateOfDeath)
                    .HasColumnType("date")
                    .HasColumnName("date_of_death")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Person)
                    .WithOne(p => p.DeceasedPerson)
                    .HasForeignKey<DeceasedPerson>(d => d.PersonId)
                    .HasConstraintName("deceased_person_person_id_fkey");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.HasIndex(e => e.BirthDate, "p_bd");

                entity.HasIndex(e => e.LastName, "p_ln");

                entity.HasIndex(e => e.Pesel, "p_p");

                entity.HasIndex(e => e.Pesel, "person_pesel_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birth_date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("last_name");

                entity.Property(e => e.Pesel)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnName("pesel")
                    .IsFixedLength(true);

                entity.Property(e => e.SecondName)
                    .HasColumnType("character varying")
                    .HasColumnName("second_name");

                entity.Property(e => e.Sex)
                    .HasMaxLength(1)
                    .HasColumnName("sex");
            });

            modelBuilder.Entity<PersonAddress>(entity =>
            {
                entity.HasKey(e => new {e.PersonId, e.AddressId})
                    .HasName("person_address_pkey");

                entity.ToTable("person_address");

                entity.HasIndex(e => e.Assigned, "pa_a");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.Assigned)
                    .HasColumnType("date")
                    .HasColumnName("assigned")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.PersonAddresses)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("person_address_address_id_fkey");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonAddresses)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("person_address_person_id_fkey");
            });

            modelBuilder.Entity<PersonContact>(entity =>
            {
                entity.HasKey(e => new {e.PersonId, e.ContactId})
                    .HasName("person_contact_pkey");

                entity.ToTable("person_contact");

                entity.HasIndex(e => e.Assigned, "pc_a");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.Assigned)
                    .HasColumnType("date")
                    .HasColumnName("assigned")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.PersonContacts)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("person_contact_contact_id_fkey");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonContacts)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("person_contact_person_id_fkey");
            });
            
            #endregion        
        }
    }
}