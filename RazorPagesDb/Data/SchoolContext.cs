using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesDb.Core;

namespace RazorPagesDb.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext (DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Homework> Homeworks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("VIPOLZOVStudents");
            modelBuilder.Entity<Student>().Property(w=>w.Id).HasColumnName("VIPId").IsRequired();
            modelBuilder.Entity<Student>().Property(w=>w.EnrollmentDate).HasColumnName("VIPEnrollmentDate");
            modelBuilder.Entity<Student>().Property(w=>w.FirstName).HasColumnName("VIPFirstName");
            modelBuilder.Entity<Student>().Property(w=>w.LastName).HasColumnName("VIPLastName");
            modelBuilder.Entity<Student>().HasMany(s => s.Homeworks).WithOne(a => a.Student);
            
            modelBuilder.Entity<Homework>().ToTable("VIPOLZOVHomework");
            modelBuilder.Entity<Homework>().Property(w=>w.Id).HasColumnName("VIPId").IsRequired();
            modelBuilder.Entity<Homework>().Property(w=>w.Name).HasColumnName("VIPNameHomework").IsRequired();
            modelBuilder.Entity<Homework>().Property(w=>w.StudentId).HasColumnName("VIPstdIDWORKALALAL").IsRequired();
            modelBuilder.Entity<Homework>().HasOne(a => a.Student).WithMany(w=>w.Homeworks).HasForeignKey(x=>x.StudentId);
            
            
        }
    }
}
