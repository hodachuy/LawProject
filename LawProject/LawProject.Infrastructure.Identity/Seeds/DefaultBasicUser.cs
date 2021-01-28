using LawProject.Application.Enums;
using LawProject.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawProject.Infrastructure.Identity.Seeds
{
    public static class DefaultBasicUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "hdhuy",
                Email = "hdhuy1991@gmail.com",
                FirstName = "Huy",
                LastName = "Ho",
                FullName = "HuyHo",
                Gender = true,
                Birthday = DateTime.Now,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Lv@123");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
                }

            }
        }
    }
}
