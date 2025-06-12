using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AutismEducationPlatform.Web.Models;

namespace AutismEducationPlatform.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }
        public DbSet<Progress> Progress { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Information> Information { get; set; }
        public DbSet<AnimalProgress> AnimalProgress { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<Announcement> Announcements { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            // Configure AspNetUsers table
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(u => u.Name).HasMaxLength(100);
                entity.Property(u => u.ChildName).HasMaxLength(100);
                entity.Property(u => u.Specialization).HasMaxLength(200);
            });

            // Configure Courses table
            builder.Entity<Course>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.Category).HasMaxLength(50);
                entity.Property(e => e.DifficultyLevel).IsRequired();
                entity.Property(e => e.ImageUrl).HasMaxLength(200);
            });

            // Configure Activities table
            builder.Entity<Activity>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.Category).HasMaxLength(50);
                entity.Property(e => e.Difficulty).HasMaxLength(50);
            });

            // Configure Progress table
            builder.Entity<Progress>(entity =>
            {
                entity.HasOne(p => p.Course)
                    .WithMany()
                    .HasForeignKey(p => p.CourseId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            // Configure Children table
            builder.Entity<Child>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Diagnosis).HasMaxLength(500);
                entity.Property(e => e.Interests).HasMaxLength(500);
                entity.Property(e => e.SpecialNeeds).HasMaxLength(1000);
            });

            // Configure News table
            builder.Entity<News>(entity =>
            {
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Content).IsRequired();
                entity.Property(e => e.Summary).IsRequired().HasMaxLength(500);
            });

            builder.Entity<ActivityLog>(entity =>
            {
                entity.HasOne(e => e.Activity)
                    .WithMany()
                    .HasForeignKey(e => e.ActivityId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.Child)
                    .WithMany()
                    .HasForeignKey(e => e.ChildId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<AnimalProgress>(entity =>
            {
                entity.HasOne(e => e.User)
                    .WithMany()
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(e => new { e.UserId, e.AnimalId })
                    .IsUnique();
            });

            // Announcement için ilişki konfigürasyonu
            builder.Entity<Announcement>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
} 