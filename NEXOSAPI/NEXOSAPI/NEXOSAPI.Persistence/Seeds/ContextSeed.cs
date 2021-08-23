using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NEXOSAPI.Domain.Auth;
using NEXOSAPI.Domain.Entities;
using System.Collections.Generic;

namespace NEXOSAPI.Persistence.Seeds
{
    public static class ContextSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            CreateRoles(modelBuilder);

            CreateBasicUsers(modelBuilder);

            MapUserRole(modelBuilder);

            //CreateBasicMaximusBooks(modelBuilder);
        }

        private static void CreateRoles(ModelBuilder modelBuilder)
        {
            List<IdentityRole> roles = DefaultRoles.IdentityRoleList();
            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }

        private static void CreateBasicUsers(ModelBuilder modelBuilder)
        {
            List<ApplicationUser> users = DefaultUser.IdentityBasicUserList();
            modelBuilder.Entity<ApplicationUser>().HasData(users);
        }

        private static void MapUserRole(ModelBuilder modelBuilder)
        {
            var identityUserRoles = MappingUserRole.IdentityUserRoleList();
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(identityUserRoles);
        }

        private static void CreateBasicMaximusBooks(ModelBuilder modelBuilder)
        {
            List<MaximumBooks> max = DefaultMaximusBook.MaximumBooksList();
            modelBuilder.Entity<MaximumBooks>().HasData(max);
        }
    }
}
