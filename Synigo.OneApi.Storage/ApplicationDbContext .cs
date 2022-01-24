using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Synigo.OneApi.Common.Extensions;
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
        public ApplicationDbContext(DbContextOptions options) :base(options) {}
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

            MapPrimaryKeys(modelBuilder);

            Console.WriteLine($"Database will generate primary keys : {Configuration.StorageConfiguration.PrimaryKeyGeneratedByDatabase}");


            modelBuilder.Entity<CourseOffering>()
              .Property(c => c.ModeOfStudy)
              .HasColumnName("ModeOfStudy");
            modelBuilder.Entity<ProgramOffering>()
                .Property(c => c.ModeOfStudy)
                .HasColumnName("ModeOfStudy");

            modelBuilder.Entity<ComponentOffering>()
                .Property(c => c.StartDate)
                .HasColumnName("StartDate");
            modelBuilder.Entity<ComponentOffering>()
                .Property(c => c.EndDate)
                .HasColumnName("EndDate");

            modelBuilder.Entity<CourseOffering>()
                .Property(c => c.StartDate)
                .HasColumnName("StartDate");
            modelBuilder.Entity<CourseOffering>()
                .Property(c => c.EndDate)
                .HasColumnName("EndDate");

            modelBuilder.Entity<ProgramOffering>()
                .Property(c => c.StartDate)
                .HasColumnName("StartDate");
            modelBuilder.Entity<ProgramOffering>()
                .Property(c => c.EndDate)
                .HasColumnName("EndDate");


            if (Configuration.StorageConfiguration.PrimaryKeyGeneratedByDatabase)
            {
                AddValueGeneratedOnAddToProperties(modelBuilder);
            }
            else
            {
                SkipValueGeneratedOnAdd(modelBuilder);
            }

            MapDictionaries(modelBuilder);

            #region Lists

            modelBuilder.Entity<Course>()
                .Property(p => p.LearningOutcomes)
                .IsRequired(false)
                .HasConversion(
                v => v.Serialize(), 
                v => v.Deserialize<List<string>>());

            modelBuilder.Entity<Course>()
                .Property(p => p.Resources)
                .IsRequired(false)
                .HasConversion(
                v => v.Serialize(),
                v => v.Deserialize<List<string>>());

            modelBuilder.Entity<Person>()
                .Property(p => p.LanguageOfChoice)
                .HasConversion(
                v => v.Serialize(),
                v => v.Deserialize<List<string>>());

            modelBuilder.Entity<Program>()
             .Property(p => p.LearningOutcomes)
             .IsRequired(false)
             .HasConversion(
             v => v.Serialize(),
             v => v.Deserialize<List<string>>());
            #endregion

            MapEnums(modelBuilder);
            
            FluentMappings(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Method where we map primary keys
        /// </summary>
        /// <param name="modelBuilder"></param>
        private void MapPrimaryKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasKey(c => c.AddressId);
            modelBuilder.Entity<AcademicSession>().HasKey(c => c.AcademicSessionId);
            modelBuilder.Entity<Association<Result>>().HasKey(c => c.AssociationId);
            modelBuilder.Entity<Building>().HasKey(c => c.BuildingId);
            modelBuilder.Entity<Component>().HasKey(c => c.ComponentId);
            modelBuilder.Entity<Course>().HasKey(c => c.CourseId);
            modelBuilder.Entity<NewsFeed>().HasKey(c => c.NewsFeedId);
            modelBuilder.Entity<Offering>().HasKey(c => c.OfferingId);
            modelBuilder.Entity<NewsItem>().HasKey(c => c.NewsItemId);
            modelBuilder.Entity<Organization>().HasKey(c => c.OrganizationId);
            modelBuilder.Entity<Person>().HasKey(c => c.PersonId);
            modelBuilder.Entity<Program>().HasKey(c => c.ProgramId);
            modelBuilder.Entity<Result>().HasKey(c => c.ResultId);
            modelBuilder.Entity<Room>().HasKey(c => c.RoomId);
            modelBuilder.Entity<Service>().HasKey(c => c.ServiceId);
            modelBuilder.Entity<Geolocation>().HasKey(c => c.GeoLocationId);
            modelBuilder.Entity<Result>().HasKey(c => c.ResultId);
        }

        /// <summary>
        /// This method is place where we add ValueGeneratedOnAdd to all pk properties or other ones if decided that way
        /// </summary>
        /// <param name="modelBuilder"></param>
        private void AddValueGeneratedOnAddToProperties(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Component>().Property(p => p.ComponentId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Building>().Property(p => p.BuildingId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Association<Result>>().Property(p => p.AssociationId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Course>().Property(p => p.CourseId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Address>().Property(p => p.AddressId).ValueGeneratedOnAdd();
            modelBuilder.Entity<AcademicSession>().Property(p => p.AcademicSessionId).ValueGeneratedOnAdd();
            modelBuilder.Entity<NewsFeed>().Property(p => p.NewsFeedId).ValueGeneratedOnAdd();
            modelBuilder.Entity<NewsItem>().Property(p => p.NewsItemId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Offering>().Property(p => p.OfferingId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Organization>().Property(p => p.OrganizationId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Person>().Property(p => p.PersonId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Program>().Property(p => p.ProgramId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Result>().Property(p => p.ResultId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Room>().Property(p => p.RoomId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Service>().Property(p => p.ServiceId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Geolocation>().Property(p => p.GeoLocationId).ValueGeneratedOnAdd();
        }

        /// <summary>
        /// This method is place where we skip generating values by db
        /// </summary>
        /// <param name="modelBuilder"></param>
        private void SkipValueGeneratedOnAdd(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Component>().Property(p => p.ComponentId).ValueGeneratedNever();
            modelBuilder.Entity<Building>().Property(p => p.BuildingId).ValueGeneratedNever();
            modelBuilder.Entity<Association<Result>>().Property(p => p.AssociationId).ValueGeneratedNever();
            modelBuilder.Entity<Course>().Property(p => p.CourseId).ValueGeneratedNever();
            modelBuilder.Entity<Address>().Property(p => p.AddressId).ValueGeneratedNever();
            modelBuilder.Entity<AcademicSession>().Property(p => p.AcademicSessionId).ValueGeneratedNever();
            modelBuilder.Entity<NewsFeed>().Property(p => p.NewsFeedId).ValueGeneratedNever();
            modelBuilder.Entity<NewsItem>().Property(p => p.NewsItemId).ValueGeneratedNever();
            modelBuilder.Entity<Offering>().Property(p => p.OfferingId).ValueGeneratedNever();
            modelBuilder.Entity<Organization>().Property(p => p.OrganizationId).ValueGeneratedNever();
            modelBuilder.Entity<Person>().Property(p => p.PersonId).ValueGeneratedNever();
            modelBuilder.Entity<Program>().Property(p => p.ProgramId).ValueGeneratedNever();
            modelBuilder.Entity<Result>().Property(p => p.ResultId).ValueGeneratedNever();
            modelBuilder.Entity<Room>().Property(p => p.RoomId).ValueGeneratedNever();
            modelBuilder.Entity<Service>().Property(p => p.ServiceId).ValueGeneratedNever();
            modelBuilder.Entity<Geolocation>().Property(p => p.GeoLocationId).ValueGeneratedNever();
        }

        /// <summary>
        /// Method where mappings of enums are 
        /// </summary>
        /// <param name="modelBuilder"></param>
        private void MapEnums(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
               .Property(p => p.Type)
               .HasConversion(
               v => v.EnumToEnumMemberValue(),
               v => v.EnumMemberValueToEnum<PostalType>());

            modelBuilder.Entity<Association<Result>>()
                .Property(p => p.Type)
                .HasConversion(
                v => v.EnumToEnumMemberValue(),
                v => v.EnumMemberValueToEnum<AssociationType>());

            modelBuilder.Entity<Association<Result>>()
                .Property(p => p.Role)
                .HasConversion(
                v => v.EnumToEnumMemberValue(),
                v => v.EnumMemberValueToEnum<AssociationRole>());

            modelBuilder.Entity<Association<Result>>()
                .Property(p => p.State)
                .HasConversion(
                v => v.EnumToEnumMemberValue(),
                V => V.EnumMemberValueToEnum<AssociationState>());

            modelBuilder.Entity<Component>()
                .Property(p => p.Type)
                .HasConversion(
                v => v.EnumToEnumMemberValue(),
                v => v.EnumMemberValueToEnum<ComponentType>());

            modelBuilder.Entity<Course>()
                .Property(p => p.Level)
                .HasConversion(
                v => v.EnumToEnumMemberValue(),
                v => v.EnumMemberValueToEnum<Level>());

            modelBuilder.Entity<Course>()
                .Property(p => p.ModesOfDelivery)
                .HasConversion(
                v => v.EnumToEnumMemberValue(),
                v => v.EnumMemberValueToEnum<ModesOfDelivery>());

            modelBuilder.Entity<CourseOffering>()
                .Property(p => p.ModeOfStudy)
                .HasConversion(
                v => v.EnumToEnumMemberValue(),
                v => v.EnumMemberValueToEnum<ModeOfStudy>());

            modelBuilder.Entity<NewsFeed>()
                .Property(p => p.Type)
                .HasConversion(
                v => v.EnumToEnumMemberValue(),
                v => v.EnumMemberValueToEnum<NewsFeedType>());

            modelBuilder.Entity<NewsItem>()
                .Property(p => p.Type)
                .HasConversion(
                v => v.EnumToEnumMemberValue(),
                v => v.EnumMemberValueToEnum<NewsItemType>());

            modelBuilder.Entity<Offering>()
                .Property(p => p.Type)
                .HasConversion(
                v => v.EnumToEnumMemberValue(),
                v => v.EnumMemberValueToEnum<OfferingType>());

            modelBuilder.Entity<Offering>()
                .Property(p => p.ResultValueType)
                .HasConversion(
                v => v.EnumToEnumMemberValue(),
                v => v.EnumMemberValueToEnum<ResultValueType>());

            modelBuilder.Entity<Organization>()
                .Property(p => p.Type)
                .HasConversion(
                v => v.EnumToEnumMemberValue(),
                v => v.EnumMemberValueToEnum<OrganizationType>());

            modelBuilder.Entity<Person>()
                .Property(p => p.Affiliations)
                .HasConversion(
                v => v.SerializeEnumeration(),
                v => v.DeserializeEnumCollection<PersonAffiliations>());

            modelBuilder.Entity<Person>()
                .Property(p => p.Gender)
                .HasConversion(
                v => v.HasValue ? v.Value.EnumToEnumMemberValue() : null,
                v => !string.IsNullOrEmpty(v) ? v.EnumMemberValueToEnum<Gender>() : null);

            modelBuilder.Entity<Program>()
                .Property(p => p.Type)
                .HasConversion(
                v => v.EnumToEnumMemberValue(),
                v => v.EnumMemberValueToEnum<ProgramType>());

            modelBuilder.Entity<Program>()
                .Property(p => p.LevelOfQualification)
                .HasConversion(
                v => v.EnumToEnumMemberValue(),
                v => v.EnumMemberValueToEnum<LevelOfQualification>());

            modelBuilder.Entity<Program>()
                .Property(p => p.Sector)
                .HasConversion(
                v => v.EnumToEnumMemberValue(),
                v => v.EnumMemberValueToEnum<Sector>());

            modelBuilder.Entity<Program>()
                .Property(p => p. QualificationAwarded)
                .HasConversion(
                v => v.EnumToEnumMemberValue(),
                v => v.EnumMemberValueToEnum<QualificationAwarded>());

            modelBuilder.Entity<ProgramOffering>()
                .Property(p => p.ModeOfStudy)
                .HasConversion(
                v => v.EnumToEnumMemberValue(),
                v => v.EnumMemberValueToEnum<ModeOfStudy>());

            modelBuilder.Entity<Result>()
                .Property(p => p.State)
                .HasConversion(
                v => v.EnumToEnumMemberValue(),
                v => v.EnumMemberValueToEnum<ResultState>());

            modelBuilder.Entity<Room>()
                .Property(p => p.Type)
                .HasConversion(
                v => v.EnumToEnumMemberValue(),
                v => v.EnumMemberValueToEnum<RoomType>());
        }

        /// <summary>
        /// Method where dictionaries are mapped to columns
        /// </summary>
        /// <param name="modelBuilder"></param>
        private void MapDictionaries(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
               .Property(p => p.Ext)
               .IsRequired(false)
               .HasConversion(
               v => v.Serialize(),
               v => v.Deserialize<Dictionary<string, object>>());

            modelBuilder.Entity<AcademicSession>()
                .Property(p => p.Ext)
                .IsRequired(false)
                .HasConversion(
                v => v.Serialize(),
                v => v.Deserialize<Dictionary<string, object>>());

            modelBuilder.Entity<Association<Result>>()
                .Property(p => p.Ext)
                .IsRequired(false)
                .HasConversion(
                v => v.Serialize(),
                v => v.Deserialize<Dictionary<string, object>>());

            modelBuilder.Entity<Building>()
                .Property(p => p.Ext)
                .IsRequired(false)
                .HasConversion(
                 v => v.Serialize(),
                v => v.Deserialize<Dictionary<string, object>>());

            modelBuilder.Entity<Component>()
                .Property(p => p.Ext)
                .IsRequired(false)
                .HasConversion(
                v => v.Serialize(),
                v => v.Deserialize<Dictionary<string, object>>());

            modelBuilder.Entity<Course>()
                .Property(p => p.Ext)
                .IsRequired(false)
                .HasConversion(
                 v => v.Serialize(),
                v => v.Deserialize<Dictionary<string, object>>());

            modelBuilder.Entity<NewsFeed>()
                .Property(p => p.Ext)
                .IsRequired(false)
                .HasConversion(
                v => v.Serialize(),
                v => v.Deserialize<Dictionary<string, object>>());

            modelBuilder.Entity<NewsItem>()
                .Property(p => p.Ext)
                .IsRequired(false)
                .HasConversion(
                 v => v.Serialize(),
                v => v.Deserialize<Dictionary<string, object>>());

            modelBuilder.Entity<Offering>()
                .Property(p => p.Ext)
                .IsRequired(false)
                .HasConversion(
                 v => v.Serialize(),
                v => v.Deserialize<Dictionary<string, object>>());

            modelBuilder.Entity<Organization>()
                .Property(p => p.Ext)
                .IsRequired(false)
                .HasConversion(
                 v => v.Serialize(),
                v => v.Deserialize<Dictionary<string, object>>());

            modelBuilder.Entity<Person>()
                .Property(p => p.Ext)
                .IsRequired(false)
                .HasConversion(
                v => v.Serialize(),
                v => v.Deserialize<Dictionary<string, object>>());

            modelBuilder.Entity<Program>()
                .Property(p => p.Ext)
                .IsRequired(false)
                .HasConversion(
                 v => v.Serialize(),
                 v => v.Deserialize<Dictionary<string, object>>());

            modelBuilder.Entity<Room>()
                .Property(p => p.Ext)
                .IsRequired(false)
                .HasConversion(
                 v => v.Serialize(),
                v => v.Deserialize<Dictionary<string, object>>());

            modelBuilder.Entity<Result>()
                .Property(p => p.Ext)
                .IsRequired(false)
                .HasConversion(
                v => v.Serialize(),
                v => v.Deserialize<Dictionary<string, object>>());

            modelBuilder.Entity<ProgramOfferingAssociation<ProgramResult>>()
                .Property(p => p.Ext)
                .IsRequired(false)
                .HasConversion(
                v => v.Serialize(),
                v => v.Deserialize<Dictionary<string, object>>());

            modelBuilder.Entity<Service>()
                .Property(p => p.Ext)
                .IsRequired(false)
                .HasConversion(
                v => v.Serialize(),
                v => v.Deserialize<Dictionary<string, object>>());

            modelBuilder.Entity<CourseOfferingAssociation<CourseResult>>()
                .Property(p => p.Ext)
                .IsRequired(false)
                .HasConversion(
                v => v.Serialize(),
                v => v.Deserialize<Dictionary<string, object>>());

            modelBuilder.Entity<ComponentOfferingAssociation<ComponentResult>>()
                .Property(p => p.Ext)
                .IsRequired(false)
                .HasConversion(
                v => v.Serialize(),
                v => v.Deserialize<Dictionary<string, object>>());
        }
    }
}
