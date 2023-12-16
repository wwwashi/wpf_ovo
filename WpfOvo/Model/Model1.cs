using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WpfOvo.Model
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }

        public virtual DbSet<Acts> Acts { get; set; }
        public virtual DbSet<Alarms> Alarms { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Patrols> Patrols { get; set; }
        public virtual DbSet<PatrolsComposition> PatrolsComposition { get; set; }
        public virtual DbSet<SecurityContracts> SecurityContracts { get; set; }
        public virtual DbSet<SecurityObjects> SecurityObjects { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acts>()
                .Property(e => e.ReasonForDeparture)
                .IsUnicode(false);

            modelBuilder.Entity<Acts>()
                .Property(e => e.ResultsInspection)
                .IsUnicode(false);

            modelBuilder.Entity<Alarms>()
                .Property(e => e.ManufacturerNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Alarms>()
                .Property(e => e.SerialNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Alarms>()
                .HasMany(e => e.SecurityObjects)
                .WithRequired(e => e.Alarms)
                .HasForeignKey(e => e.AlarmsID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Gender>()
                .Property(e => e.NameGender)
                .IsUnicode(false);

            modelBuilder.Entity<Gender>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.Gender)
                .HasForeignKey(e => e.GenderID);

            modelBuilder.Entity<Patrols>()
                .Property(e => e.NamePatrols)
                .IsUnicode(false);

            modelBuilder.Entity<Patrols>()
                .HasMany(e => e.Acts)
                .WithRequired(e => e.Patrols)
                .HasForeignKey(e => e.PatrolsID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Patrols>()
                .HasMany(e => e.PatrolsComposition)
                .WithRequired(e => e.Patrols)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SecurityContracts>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SecurityObjects>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<SecurityObjects>()
                .HasMany(e => e.Acts)
                .WithRequired(e => e.SecurityObjects)
                .HasForeignKey(e => e.ObjectID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SecurityObjects>()
                .HasMany(e => e.SecurityContracts)
                .WithRequired(e => e.SecurityObjects)
                .HasForeignKey(e => e.ObjectsID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserRole>()
                .Property(e => e.NameRole)
                .IsUnicode(false);

            modelBuilder.Entity<UserRole>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.UserRole)
                .HasForeignKey(e => e.RoleID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Midname)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.PatrolsComposition)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.SecurityObjects)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.SecurityObjects1)
                .WithRequired(e => e.Users1)
                .HasForeignKey(e => e.ClientPersonID)
                .WillCascadeOnDelete(false);
        }
    }
}
