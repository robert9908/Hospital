using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TestTask.Models.Domain;

namespace Hospital.API.Data
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Cabinet> Cabinets { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Specialization> Specializations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var Specializations = new List<Specialization>()
            {
                new Specialization()
                {
                    Id = int.Parse("1"),
                    Name = "Surgeon"
                },
                new Specialization()
                {
                    Id = int.Parse("2"),
                    Name = "Psychologist"
                },
                new Specialization()
                {
                    Id = int.Parse("3"),
                    Name = "Dentist"
                }
            };


            modelBuilder.Entity<Specialization>().HasData(Specializations);


            var Cabinets = new List<Cabinet>()
            {
                new Cabinet()
                {
                    Id = int.Parse("1"),
                    Number = "100"
                },
                new Cabinet()
                {
                    Id = int.Parse("2"),
                    Number = "200"
                },
                new Cabinet()
                {
                    Id = int.Parse("3"),
                    Number = "300"
                }
            };

            modelBuilder.Entity<Cabinet>().HasData(Cabinets);


            var Areas = new List<Area>()
            {
                new Area()
                {
                    Id = int.Parse("1"),
                    Number = "1"
                },
                new Area()
                {
                    Id = int.Parse("2"),
                    Number = "2"
                },
                new Area()
                {
                    Id = int.Parse("3"),
                    Number = "3"
                }
            };

            modelBuilder.Entity<Area>().HasData(Areas);
        }
    }
}
