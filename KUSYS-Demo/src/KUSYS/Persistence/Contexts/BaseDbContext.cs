using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.Linq;
using Core.Security.Entities;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {

        public BaseDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseMatch> CourseMatches { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<User> User { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //tüm tablolarda delete yapılınca cascade yapılmamasını sağlar:
            //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    relationship.DeleteBehavior = DeleteBehavior.NoAction;
            //}

            modelBuilder.Entity<Course>(course =>
            {
                course.ToTable("Courses").HasKey(k => k.Id);
                course.Property(p => p.Id).HasColumnName("Id");
                course.Property(p => p.CourseId).HasColumnName("CourseId");
                course.Property(p => p.CourseName).HasColumnName("CourseName");
            });

            modelBuilder.Entity<Student>(student =>
            {
                student.ToTable("Students").HasKey(k => k.Id);
                student.Property(p => p.Id).HasColumnName("Id");
                student.Property(p => p.FirstName).HasColumnName("FirstName");
                student.Property(p => p.LastName).HasColumnName("LastName");
                student.Property(p => p.BirthDate).HasColumnName("BirthDate");

            });

            modelBuilder.Entity<CourseMatch>(courseMatch =>
            {
                courseMatch.ToTable("CourseMatches").HasKey(k => k.Id);
                courseMatch.Property(c => c.Id).HasColumnName("Id");
                courseMatch.Property(c => c.StudentId).HasColumnName("StudentId");
                courseMatch.Property(c => c.CourseId).HasColumnName("CourseId");



            });

            modelBuilder.Entity<UserOperationClaim>(userOperationClaim =>
            {
                userOperationClaim.ToTable("UserOperationClaims").HasKey(u => u.Id);
                userOperationClaim.Property(u => u.Id).HasColumnName("Id");
                userOperationClaim.Property(u => u.UserId).HasColumnName("UserId");
                userOperationClaim.Property(u => u.OperationClaimId).HasColumnName("OperationClaimId");

                userOperationClaim.HasOne(u => u.User);
                userOperationClaim.HasOne(u => u.OperationClaim);
            });


            // Seed OperationClaim
            modelBuilder.Entity<OperationClaim>().HasData(new OperationClaim(1, "admin"));
            modelBuilder.Entity<OperationClaim>().HasData(new OperationClaim(2, "member"));
        }
    }
}
