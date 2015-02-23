namespace ProjectSD.Migrations
{
    using ProjectSD.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjectSD.DAL.MyDatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProjectSD.DAL.MyDatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            var users = new List<Users>
            {
                new Users{Username="markjoseph",Password="1234"},
                new Users{Username="rosemar",Password="1234"}
            };

            users.ForEach(u => context.Users.AddOrUpdate(p => p.Username, u));
            context.SaveChanges();


            var persons = new List<PersonalInfo> 
            { 
                new PersonalInfo{Name="Mark Joseph Cabuquit",UserID=users.Single(s=>s.Username=="markjoseph").UsersID},
                new PersonalInfo{Name="Rosemar Magalay",UserID=users.Single(s=>s.Username=="rosemar").UsersID}
            };


            foreach (PersonalInfo p in persons) {
                var personalInfoDatabase = context.PersonalInfo.Where(
                    u=>u.Users.UsersID==p.UserID
                    ).SingleOrDefault();
                if(personalInfoDatabase==null){
                    context.PersonalInfo.Add(p);
                }
            }
            context.SaveChanges();
        }
    }
}
