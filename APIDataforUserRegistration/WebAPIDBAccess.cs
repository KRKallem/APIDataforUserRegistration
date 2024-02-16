using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace APIDataforUserRegistration
{
    public partial class WebAPIDBAccess : DbContext
    {
        public WebAPIDBAccess()
            : base("name=WebAPIDBAccess")
        {
        }

        public virtual DbSet<StudentDepartment> StudentDepartments { get; set; }
        public virtual DbSet<studentinfo> studentinfoes { get; set; }
        public virtual DbSet<UserInfo> UserInfoes { get; set; }
        public virtual DbSet<Hyderabad_student> Hyderabad_students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentDepartment>()
                .Property(e => e.DepartmentName)
                .IsUnicode(false);

            modelBuilder.Entity<studentinfo>()
                .Property(e => e.StudentName)
                .IsUnicode(false);

            modelBuilder.Entity<studentinfo>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<studentinfo>()
                .Property(e => e.DepartmentName)
                .IsUnicode(false);

            modelBuilder.Entity<studentinfo>()
                .Property(e => e.gender)
                .IsUnicode(false);

            modelBuilder.Entity<studentinfo>()
                .HasMany(e => e.StudentDepartments)
                .WithRequired(e => e.studentinfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.Skillset)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.Hobby)
                .IsUnicode(false);

            modelBuilder.Entity<Hyderabad_student>()
                .Property(e => e.studentname)
                .IsUnicode(false);
        }
    }
}
