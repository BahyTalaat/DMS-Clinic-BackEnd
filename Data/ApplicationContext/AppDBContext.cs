using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Data.ApplicationContext
{
    public class AppDBContext:DbContext
    {
        private readonly IConfiguration _configuration;

        public AppDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("CS"));


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            SeedInitialization.InsertRole(modelBuilder);
            SeedInitialization.InsertUsers(modelBuilder);
            SeedInitialization.AddRolesToUser(modelBuilder);
        }

        public virtual DbSet<Clinic> Clinics { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<WorkingDay> WorkingDays{ get; set; }
        public virtual DbSet<DaySlots> DaySlots {get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles {get; set; }
        //public virtual DbSet<DoctorWorkingDays> DoctorWorkingDays { get; set; }
    }
}
