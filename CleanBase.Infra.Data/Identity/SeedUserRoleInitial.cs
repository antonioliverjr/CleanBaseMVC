using CleanBase.Domain.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanBase.Infra.Data.Identity
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public SeedUserRoleInitial(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async void SeedRoles()
        {
            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                };
                await _roleManager.CreateAsync(role);
            }
            if (!_roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                };
                await _roleManager.CreateAsync(role);
            }
        }

        public void SeedUsers()
        {
            if (_userManager.FindByEmailAsync("user@localhost").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "user@localhost",
                    Email = "user@localhost",
                    NormalizedUserName = "USER@LOCALHOST",
                    NormalizedEmail = "USER@LOCALHOST",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                var result = _userManager.CreateAsync(user, "Admjr#2021");
                if (result.Result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "User").Wait();
                }
            }

            if (_userManager.FindByEmailAsync("admin@localhost").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "admin@localhost",
                    Email = "admin@localhost",
                    NormalizedUserName = "ADMIN@LOCALHOST",
                    NormalizedEmail = "ADMIN@LOCALHOST",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                var result = _userManager.CreateAsync(user, "Admjr#2021").Result;
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}
