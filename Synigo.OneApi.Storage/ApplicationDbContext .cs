﻿using System.Collections.Generic;
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

            modelBuilder.Entity<Address>().HasKey(c => c.AddressId);
            modelBuilder.Entity<Address>().Property(p => p.AddressId).ValueGeneratedOnAdd();

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

            modelBuilder.Entity<Organization>().HasKey(c => c.OrganizationId);
            modelBuilder.Entity<Organization>().Property(p => p.OrganizationId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Person>().HasKey(c => c.PersonId);
            modelBuilder.Entity<Person>().Property(p => p.PersonId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Program>().HasKey(c => c.ProgramId);
            modelBuilder.Entity<Program>().Property(p => p.ProgramId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Result>().HasKey(c => c.ResultId);
            modelBuilder.Entity<Result>().Property(p => p.ResultId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Room>().HasKey(c => c.RoomId);
            modelBuilder.Entity<Room>().Property(p => p.RoomId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Service>().HasKey(c => c.ServiceId);
            modelBuilder.Entity<Service>().Property(p => p.ServiceId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Geolocation>().HasKey(c => c.GeoLocationId);
            modelBuilder.Entity<Geolocation>().Property(p => p.GeoLocationId).ValueGeneratedOnAdd();

            modelBuilder.Entity<CourseOfferingAssociation<CourseResult>>().HasNoKey();
            modelBuilder.Entity<ComponentOfferingAssociation<ComponentResult>>().HasNoKey();
            modelBuilder.Entity<ProgramOfferingAssociation<ProgramResult>>().HasNoKey();
            #endregion

            #region Ext

            modelBuilder.Entity<Address>()
                .Property(p => p.Ext)
                .IsRequired(false)
                .HasConversion(
                v => v.Serialize(),
                v => v.Deserialize<Dictionary<string,object>>());

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
                .Property(p=>p.Ext)
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

            #endregion

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

            #region Enums

            modelBuilder.Entity<Address>()
                .Property(p => p.Type)
                .HasConversion(
                v => v.SerializeEnum(),
                v => v.DeserializeEnum<PostalType>());

            modelBuilder.Entity<Association<Result>>()
                .Property(p => p.Type)
                .HasConversion(
                v => v.SerializeEnum(),
                v => v.DeserializeEnum<AssociationType>());

            modelBuilder.Entity<Association<Result>>()
                .Property(p => p.Role)
                .HasConversion(
                v => v.SerializeEnum(),
                v => v.DeserializeEnum<AssociationRole>());

            modelBuilder.Entity<Association<Result>>()
                .Property(p => p.State)
                .HasConversion(
                v => v.SerializeEnum(),
                V => V.DeserializeEnum<AssociationState>());

            modelBuilder.Entity<Component>()
                .Property(p => p.Type)
                .HasConversion(
                v => v.SerializeEnum(),
                v => v.DeserializeEnum<ComponentType>());

            modelBuilder.Entity<Course>()
                .Property(p => p.Level)
                .HasConversion(
                v => v.SerializeEnum(),
                v => v.DeserializeEnum<Level>());

            modelBuilder.Entity<Course>()
                .Property(p => p.ModesOfDelivery)
                .HasConversion(
                v => v.SerializeEnum(),
                v => v.DeserializeEnum<ModesOfDelivery>());

            modelBuilder.Entity<CourseOffering>()
                .Property(p => p.ModeOfStudy)
                .HasConversion(
                v => v.SerializeEnum(),
                v => v.DeserializeEnum<ModeOfStudy>());

            modelBuilder.Entity<NewsFeed>()
                .Property(p => p.Type)
                .HasConversion(
                v => v.SerializeEnum(),
                v => v.DeserializeEnum<NewsFeedType>());

            modelBuilder.Entity<NewsItem>()
                .Property(p => p.Type)
                .HasConversion(
                v => v.SerializeEnum(),
                v => v.DeserializeEnum<NewsItemType>());

            modelBuilder.Entity<Offering>()
                .Property(p => p.Type)
                .HasConversion(
                v => v.SerializeEnum(),
                v => v.DeserializeEnum<OfferingType>());

            modelBuilder.Entity<Offering>()
                .Property(p => p.ResultValueType)
                .HasConversion(
                v => v.SerializeEnum(),
                v => v.DeserializeEnum<ResultValueType>());

            modelBuilder.Entity<Organization>()
                .Property(p => p.Type)
                .HasConversion(
                v => v.SerializeEnum(),
                v => v.DeserializeEnum<OrganizationType>());

            modelBuilder.Entity<Person>()
                .Property(p => p.Affiliations)
                .HasConversion(
                v => v.SerializeEnumeration(),
                v => v.DeserializeEnumCollection<PersonAffiliations>());

            modelBuilder.Entity<Person>()
                .Property(p => p.Gender)
                .HasConversion(
                v => v.HasValue ? v.Value.SerializeEnum() : null,
                v => !string.IsNullOrEmpty(v) ? v.DeserializeEnum<Gender>() : null);

            modelBuilder.Entity<Program>()
                .Property(p => p.Type)
                .HasConversion(
                v => v.SerializeEnum(),
                v => v.DeserializeEnum<ProgramType>());

            modelBuilder.Entity<Program>()
                .Property(p => p.LevelOfQualification)
                .HasConversion(
                v => v.SerializeEnum(),
                v => v.DeserializeEnum<LevelOfQualification>());

            modelBuilder.Entity<Program>()
                .Property(p => p.Sector)
                .HasConversion(
                v => v.SerializeEnum(),
                v => v.DeserializeEnum<Sector>());

            modelBuilder.Entity<ProgramOffering>()
                .Property(p => p.ModeOfStudy)
                .HasConversion(
                v => v.SerializeEnum(),
                v => v.DeserializeEnum<ModeOfStudy>());

            modelBuilder.Entity<Result>()
                .Property(p => p.State)
                .HasConversion(
                v => v.SerializeEnum(),
                v => v.DeserializeEnum<ResultState>());

            modelBuilder.Entity<Room>()
                .Property(p => p.Type)
                .HasConversion(
                v => v.SerializeEnum(),
                v => v.DeserializeEnum<RoomType>());
            #endregion

            FluentMappings(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
