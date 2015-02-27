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
            AutomaticMigrationsEnabled = true;
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


            var users = new List<Users>()
            {
                new Users(){Username="admin",Password="1234"}
            };

            users.ForEach(s => context.Users.AddOrUpdate(p=>p.Username,s));
            context.SaveChanges();

            var persons = new List<PersonalInfo>()
            {
                new PersonalInfo(){Name="Mark Joseph Cabuquit",UserID=users.Single(s=>s.Username=="admin").UsersID}
            };

            foreach(PersonalInfo p in persons){
                var personalInfoInDatabase = context.PersonalInfo.Where(s => s.Users.UsersID == p.UserID).SingleOrDefault();
                if(personalInfoInDatabase==null){
                    context.PersonalInfo.Add(p);
                }
            }
            context.SaveChanges();


            var board = new List<Board>()
            {
                new Board(){BoardName="Android Project",BoardCreated=DateTime.Now}
            };

            board.ForEach(b => context.Board.Add(b));
            context.SaveChanges();

            var member = new List<BoardMember>(){
                new BoardMember(){
                    Users=users[0],Board=board[0]
                }
            };
            foreach (BoardMember bm in member)
            {
                var boardmemberInDatabase = context.BoardMember.Where(s => s.Users.UsersID == bm.Users.UsersID).SingleOrDefault();
                if (boardmemberInDatabase == null)
                {
                    context.BoardMember.Add(bm);
                }
            }
            context.SaveChanges();
           
        }
    }
}
