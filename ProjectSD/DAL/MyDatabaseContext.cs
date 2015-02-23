using ProjectSD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ProjectSD.DAL
{
    public class MyDatabaseContext :DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<PersonalInfo> PersonalInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}