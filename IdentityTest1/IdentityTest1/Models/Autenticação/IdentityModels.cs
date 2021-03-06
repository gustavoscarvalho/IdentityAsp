﻿using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace IdentityTest1.Models.Autenticação
{
   
        public class ApplicationUser : IdentityUser
        {
            public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
            {
                var userIdentity =
                    await manager.CreateIdentityAsync(this,
                        DefaultAuthenticationTypes.ApplicationCookie);

                return userIdentity;
            }
        }

        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public ApplicationDbContext()
                : base("DatabaseConnection", throwIfV1Schema: false)
            {

            }

            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }
        }


    
}
