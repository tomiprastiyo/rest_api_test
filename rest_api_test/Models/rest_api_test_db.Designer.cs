﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 9/8/2022 1:56:02 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace rest_api_test
{

    public partial class rest_api_test_db : DbContext
    {

        public rest_api_test_db() :
            base()
        {
            OnCreated();
        }

        public rest_api_test_db(DbContextOptions<rest_api_test_db> options) :
            base(options)
        {
            OnCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured ||
                (!optionsBuilder.Options.Extensions.OfType<RelationalOptionsExtension>().Any(ext => !string.IsNullOrEmpty(ext.ConnectionString) || ext.Connection != null) &&
                 !optionsBuilder.Options.Extensions.Any(ext => !(ext is RelationalOptionsExtension) && !(ext is CoreOptionsExtension))))
            {
            }
            CustomizeConfiguration(ref optionsBuilder);
            base.OnConfiguring(optionsBuilder);
        }

        partial void CustomizeConfiguration(ref DbContextOptionsBuilder optionsBuilder);

        public virtual DbSet<user> user
        {
            get;
            set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            this.userMapping(modelBuilder);
            this.CustomizeuserMapping(modelBuilder);

            RelationshipsMapping(modelBuilder);
            CustomizeMapping(ref modelBuilder);
        }

        #region user Mapping

        private void userMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<user>().ToTable(@"user");
            modelBuilder.Entity<user>().Property(x => x.id).HasColumnName(@"id").IsRequired().ValueGeneratedOnAdd().HasMaxLength(4);
            modelBuilder.Entity<user>().Property(x => x.nama).HasColumnName(@"nama").IsRequired().ValueGeneratedNever().HasMaxLength(50);
            modelBuilder.Entity<user>().Property(x => x.jenis_identitas).HasColumnName(@"jenis_identitas").IsRequired().ValueGeneratedNever().HasMaxLength(20);
            modelBuilder.Entity<user>().Property(x => x.no_identitas).HasColumnName(@"no_identitas").IsRequired().ValueGeneratedNever().HasMaxLength(20);
            modelBuilder.Entity<user>().Property(x => x.tempat).HasColumnName(@"tempat").IsRequired().ValueGeneratedNever().HasMaxLength(50);
            modelBuilder.Entity<user>().Property(x => x.tgl_lahir).HasColumnName(@"tgl_lahir").IsRequired().ValueGeneratedNever().HasMaxLength(3);
            modelBuilder.Entity<user>().Property(x => x.jenis_kelamin).HasColumnName(@"jenis_kelamin").IsRequired().ValueGeneratedNever().HasMaxLength(50);
            modelBuilder.Entity<user>().Property(x => x.alamat).HasColumnName(@"alamat").IsRequired().ValueGeneratedNever().HasMaxLength(900);
            modelBuilder.Entity<user>().Property(x => x.input_by).HasColumnName(@"input_by").IsRequired().ValueGeneratedNever().HasMaxLength(50);
            modelBuilder.Entity<user>().Property(x => x.input_date).HasColumnName(@"input_date").IsRequired().ValueGeneratedNever().HasMaxLength(8);
            modelBuilder.Entity<user>().HasKey(@"id");
        }

        partial void CustomizeuserMapping(ModelBuilder modelBuilder);

        #endregion

        private void RelationshipsMapping(ModelBuilder modelBuilder)
        {
        }

        partial void CustomizeMapping(ref ModelBuilder modelBuilder);

        public bool HasChanges()
        {
            return ChangeTracker.Entries().Any(e => e.State == Microsoft.EntityFrameworkCore.EntityState.Added || e.State == Microsoft.EntityFrameworkCore.EntityState.Modified || e.State == Microsoft.EntityFrameworkCore.EntityState.Deleted);
        }

        partial void OnCreated();
    }
}

namespace rest_api_test
{
    public partial class user {

        public user()
        {
            OnCreated();
        }

        public virtual int id { get; set; }

        public virtual string nama { get; set; }

        public virtual string jenis_identitas { get; set; }

        public virtual string no_identitas { get; set; }

        public virtual string tempat { get; set; }

        public virtual DateTime tgl_lahir { get; set; }

        public virtual string jenis_kelamin { get; set; }

        public virtual string alamat { get; set; }

        public virtual string input_by { get; set; }

        public virtual DateTime input_date { get; set; }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
