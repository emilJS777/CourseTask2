using System;
using CourseTask.Src.Models;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using CourseTask.Src;
using AutoMapper;

namespace CourseTask.Src
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<CourseModel> Courses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
                .HasMany(c => c.Courses)
                .WithMany(s => s.Users).UsingEntity(j => j.ToTable("Lessons"));



            // SEED DATA
            modelBuilder.Entity<ProfileModel>().HasData(
                new ProfileModel
                {
                    Id = 1,
                    LastName = "Lastnaame",
                    FirstName = "Firstname",
                    DateOfBirth = "01/01/1999",
                    PhoneNumber = "(999) 999-9999",
                    Address = "859 ADAMS AVE 7",
                    Email = "example@mail.com"
                });

            modelBuilder.Entity<UserModel>().HasData(
                new UserModel
                {
                    Id = 1,
                    UserName = "seeduser",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("seedpassword"),
                    ProfileId = 1,
                });

            modelBuilder.Entity<CourseModel>().HasData(
                new List<CourseModel>
                    {
                        new CourseModel
                        {
                            Id = 1,
                            Title = "Course 1",
                            Description = "",
                        },
                        new CourseModel
                        {
                            Id = 2,
                            Title = "Course 2",
                            Description = "",
                        }
                    }
                );
        }
    }
}
