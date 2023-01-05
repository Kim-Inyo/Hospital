using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Models;
using Microsoft.EntityFrameworkCore;


namespace Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<DUser> Users { get; set; }
        public DbSet<DAppointment> Appointments { get; set; }
        public DbSet<DDoctor> Doctors { get; set; }
        public DbSet<DSchedule> Schedules { get; set; }
        public DbSet<DSpec> Specs { get; set; }

        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DUser>().HasIndex(model => model.UserName);
        }
    }
}