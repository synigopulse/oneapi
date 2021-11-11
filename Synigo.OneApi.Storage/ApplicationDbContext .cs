using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Synigo.OpenEducationApi.Model.V4;
using Synigo.OpenEducationApi.Model.V4.Models;

namespace Synigo.OneApi.Storage
{
    public class ApplicationDbContext : DbContext
    {
        #region Properties
        public DbSet<AcademicSession> AcademicSessions { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Association<Result>> Associations { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<ComponentOffering> ComponentOfferings { get; set; }
        public DbSet<ComponentOfferingAssociation<ComponentResult>> ComponentOfferingAssociations { get; set; }
        public DbSet<ComponentResult> ComponentResults { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseOffering> CourseOfferings { get; set; }
        public DbSet<CourseOfferingAssociation<CourseResult>> CourseOfferingAssociations { get; set; }
        public DbSet<CourseResult> CourseResults { get; set; }
        public DbSet<Geolocation> Geolocations { get; set; }
        public DbSet<NewsFeed> NewsFeeds { get; set; }
        public DbSet<NewsItem> NewsItems { get; set; }
        public DbSet<Offering> Offerings { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<ProgramOffering> ProgramOfferings { get; set; }
        public DbSet<ProgramOfferingAssociation<ProgramResult>> ProgramOfferingAssociations { get; set; }
        public DbSet<ProgramResult> ProgramResults { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }
        #endregion

        #region ctr
        public ApplicationDbContext(DbContextOptions options) :base(options)
        {

        }
        #endregion

        /// <summary>
        ///  Override this method to further configure the model mappings
        /// </summary>
        /// <param name="modelBuilder">
        ///     The builder being used to construct the model for this context. Databases (and
        ///     other extensions) typically define extension methods on this object that allow
        ///     you to configure aspects of the model that are specific to a given database.
        /// </param>
        protected virtual void FluentMappings(ModelBuilder modelBuilder)
        {

        }

        protected override sealed void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region pK

            modelBuilder.Entity<AcademicSession>().HasKey(c => c.AcademicSessionId);
            modelBuilder.Entity<AcademicSession>().Property(p => p.AcademicSessionId).ValueGeneratedOnAdd();
            

            modelBuilder.Entity<Association<Result>>().HasKey(c => c.AssociationId);
            modelBuilder.Entity<Association<Result>>().Property(p => p.AssociationId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Building>().HasKey(c => c.BuildingId);
            modelBuilder.Entity<Building>().Property(p => p.BuildingId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Component>().HasKey(c => c.ComponentId);
            modelBuilder.Entity<Component>().Property(p => p.ComponentId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Course>().HasKey(c => c.CourseId);
            modelBuilder.Entity<Course>().Property(p => p.CourseId).ValueGeneratedOnAdd();

            modelBuilder.Entity<NewsFeed>().HasKey(c => c.NewsFeedId);
            modelBuilder.Entity<NewsFeed>().Property(p => p.NewsFeedId).ValueGeneratedOnAdd();

            modelBuilder.Entity<NewsItem>().HasKey(c => c.NewsItemId);
            modelBuilder.Entity<NewsItem>().Property(p => p.NewsItemId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Offering>().HasKey(c => c.OfferingId);
            modelBuilder.Entity<Offering>().Property(p => p.OfferingId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Organization>().Property(c => c.OrganizationId);
            modelBuilder.Entity<Organization>().Property(p => p.OrganizationId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Person>().Property(c => c.PersonId);
            modelBuilder.Entity<Person>().Property(p => p.PersonId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Program>().Property(c => c.ProgramId);
            modelBuilder.Entity<Program>().Property(p => p.ProgramId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Room>().Property(c => c.RoomId);
            modelBuilder.Entity<Room>().Property(p => p.RoomId).ValueGeneratedOnAdd();

            #endregion

            #region Ext

            modelBuilder.Entity<AcademicSession>().Property(p => p.Ext)
                .IsRequired(false)
                .HasConversion(
                v => Serialize(v),
                v => Deserialize(v));

            modelBuilder.Entity<Association<Result>>().Property(p => p.Ext)
                .IsRequired(false)
                .HasConversion(
                v => Serialize(v),
                v => Deserialize(v));

            modelBuilder.Entity<Building>().Property(p=>p.Ext)
                .IsRequired(false)
                .HasConversion(
                v => Serialize(v),
                v => Deserialize(v));

            modelBuilder.Entity<Component>().Property(p => p.Ext)
                .IsRequired(false)
                .HasConversion(
                v => Serialize(v),
                v => Deserialize(v));

            modelBuilder.Entity<Course>().Property(p => p.Ext)
                .IsRequired(false)
                .HasConversion(
                v => Serialize(v),
                v => Deserialize(v));

            modelBuilder.Entity<NewsFeed>().Property(p => p.Ext)
                .IsRequired(false)
                .HasConversion(
                v => Serialize(v),
                v => Deserialize(v));

            modelBuilder.Entity<NewsItem>().Property(p => p.Ext)
                .IsRequired(false)
                .HasConversion(
                v => Serialize(v),
                v => Deserialize(v));

            modelBuilder.Entity<Offering>().Property(p => p.Ext)
                .IsRequired(false)
                .HasConversion(
                v => Serialize(v),
                v => Deserialize(v));

            modelBuilder.Entity<Organization>().Property(p => p.Ext)
                .IsRequired(false)
                .HasConversion(
                v => Serialize(v),
                v => Deserialize(v));

            modelBuilder.Entity<Person>().Property(p => p.Ext)
                .IsRequired(false)
                .HasConversion(
                v => Serialize(v),
                v => Deserialize(v));

            modelBuilder.Entity<Program>().Property(p => p.Ext)
                .IsRequired(false)
                .HasConversion(
                v => Serialize(v),
                v => Deserialize(v));

            modelBuilder.Entity<Room>().Property(p => p.Ext)
                .IsRequired(false)
                .HasConversion(
                v => Serialize(v),
                v => Deserialize(v));

            #endregion

            #region Enums

            modelBuilder.Entity<Address>()
                .Property(p => p.PostalType)
                .HasConversion<string>();

            modelBuilder.Entity<Association<Result>>()
                .Property(p => p.Type)
                .HasConversion<string>();

            modelBuilder.Entity<Association<Result>>()
                .Property(p => p.Role)
                .HasConversion<string>();

            modelBuilder.Entity<Association<Result>>()
                .Property(p => p.State)
                .HasConversion<string>();

            modelBuilder.Entity<Component>()
                .Property(p => p.Type)
                .HasConversion<string>();

            modelBuilder.Entity<Course>()
                .Property(p => p.Level)
                .HasConversion<string>();

            modelBuilder.Entity<Course>()
                .Property(p => p.ModesOfDelivery)
                .HasConversion<string>();

            modelBuilder.Entity<CourseOffering>()
                .Property(p => p.ModeOfStudy)
                .HasConversion<string>();

            modelBuilder.Entity<NewsFeed>()
                .Property(p => p.Type)
                .HasConversion<string>();

            modelBuilder.Entity<NewsItem>()
                .Property(p => p.Type)
                .HasConversion<string>();

            modelBuilder.Entity<Offering>()
                .Property(p => p.Type)
                .HasConversion<string>();

            modelBuilder.Entity<Offering>()
                .Property(p => p.ResultValueType)
                .HasConversion<string>();

            modelBuilder.Entity<Organization>()
                .Property(p => p.Type)
                .HasConversion<string>();

            modelBuilder.Entity<Person>()
                .Property(p => p.Affiliations)
                .HasConversion(
                v => Serialize(v),
                v => Deserialize<PersonAffiliations>(v));

            modelBuilder.Entity<Person>()
                .Property(p => p.Gender)
                .HasConversion<string>();

            modelBuilder.Entity<Program>()
                .Property(p => p.Type)
                .HasConversion<string>();

            modelBuilder.Entity<Program>()
                .Property(p => p.LevelOfQualification)
                .HasConversion<string>();

            modelBuilder.Entity<Program>()
                .Property(p => p.Sector)
                .HasConversion<string>();

            modelBuilder.Entity<ProgramOffering>()
                .Property(p => p.ModeOfStudy)
                .HasConversion<string>();

            modelBuilder.Entity<Result>()
                .Property(p => p.State)
                .HasConversion<string>();

            modelBuilder.Entity<Room>()
                .Property(p => p.Type)
                .HasConversion<string>();
            #endregion

            FluentMappings(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private string Serialize(Dictionary<string, object> dict)
        {
            if (dict == null) return "";
            return JsonSerializer.Serialize(dict);
        }

        private Dictionary<string, object> Deserialize(string str)
        {
            return str == null
                ? new Dictionary<string, object>() // fallback
                : JsonSerializer.Deserialize<Dictionary<string, object>>(str);
        }

        private string Serialize<T> (ICollection<T> enumerations)
            where T : Enum
        {
            if (enumerations == null)
                return "";
            return JsonSerializer.Serialize(enumerations.Select(e => e.ToString()).ToList());
        }

        private List<T> Deserialize<T>(string str)
            where T : Enum
        {
            return str == null
                ? new List<T>()
                : JsonSerializer.Deserialize<ICollection<string>>(str).Select(e => (T)Enum.Parse(typeof(T), e)).ToList();
        }
           
    }
}
