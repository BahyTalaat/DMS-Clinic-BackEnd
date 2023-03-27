using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ApplicationContext
{
    public static class SeedInitialization
    {
        public static void InsertRole(ModelBuilder modelBuilder)
        {
            var RoleList = new List<Role>()
            {
                new Role {Id=1, Name="Admin"},
                 new Role {Id=2,Name="Doctor"},
                 new Role {Id=3,Name="Secretary"},
            };
            modelBuilder.Entity<Role>().HasData(RoleList);

        }

        public static void InsertUsers(ModelBuilder modelBuilder)
        {
            var UserList = new List<User>()
            {
                new User {Id=1, Email="Bahy@gmail.com",Password="Bahy@123",UserName="Bahy Talaat"},
                new User {Id = 2, Email="Mena@gmail.com",Password="Mena@123",UserName="Mena Nageh"},
                new User {Id = 3, Email="Bassam@gmail.com",Password="Bassam@123",UserName="Bassam Nageh"},
                
            };
            modelBuilder.Entity<User>().HasData(UserList);

        }

        public static void AddRolesToUser(ModelBuilder modelBuilder)
        {
            var _List = new List<UserRole>()
            {
                new UserRole {ID=1,RoleID=1,UserID=1},
                new UserRole {ID=2,RoleID=2,UserID=2},
                new UserRole {ID=3,RoleID=3,UserID=3},
                
            };
            modelBuilder.Entity<UserRole>().HasData(_List);

        }
    }
}
