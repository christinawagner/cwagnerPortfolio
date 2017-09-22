namespace cwagnerPortfolio.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using cwagnerPortfolio.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<cwagnerPortfolio.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(cwagnerPortfolio.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }
            if (!context.Users.Any(u => u.Email == "cwagner0604@gmail.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "cwagner0604@gmail.com",
                    Email = "cwagner0604@gmail.com",
                    FirstName = "Christina",
                    LastName = "Wagner",
                }, "Password1!");
            }
            var adminUserId = userManager.FindByEmail("cwagner0604@gmail.com").Id;
            userManager.AddToRole(adminUserId, "Admin");

            if (!context.Roles.Any(r => r.Name == "Moderator"))
            {
                roleManager.Create(new IdentityRole { Name = "Moderator" });
            }
            if (!context.Users.Any(u => u.Email == "mjaang@coderfoundry.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "mjaang@coderfoundry.com",
                    Email = "mjaang@coderfoundry.com",
                    FirstName = "Mark",
                    LastName = "Jaang",
                    ForcePasswordReset = true,
                }, "Password1!");
            }
            var moderatorUserId1 = userManager.FindByEmail("mjaang@coderfoundry.com").Id;
            userManager.AddToRole(moderatorUserId1, "Moderator");

            if (!context.Users.Any(u => u.Email == "rchapman@coderfoundry.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "rchapman@coderfoundry.com",
                    Email = "rchapman@coderfoundry.com",
                    FirstName = "Ryan",
                    LastName = "Chapman",
                    ForcePasswordReset = true,
                }, "Password1!");
            }
            var moderatorUserId2 = userManager.FindByEmail("rchapman@coderfoundry.com").Id;
            userManager.AddToRole(moderatorUserId2, "Moderator");
        }
    }
}
