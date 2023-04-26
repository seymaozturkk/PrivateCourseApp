using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrivateClassApp.Data.Config;
using PrivateClassApp.Data.Extensions;
using PrivateClassApp.Entity.Concrete;
using PrivateClassApp.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Data.Context
{
    public class PrivateClassAppContext : IdentityDbContext<User, Role, string>
    {
        public PrivateClassAppContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonCategory> LessonCategories { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<LikedItem> LikedItems { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherAvailability> TeacherAvailabilities { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<UniversityEducation> UniversityEducations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfig).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
