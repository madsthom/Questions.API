using System;
using Microsoft.EntityFrameworkCore;

namespace Questions.API.Models
{
    public class QaDbContext : DbContext
    {

        public QaDbContext(DbContextOptions<QaDbContext> options)
            : base(options)
        {

        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
                .HasMany<Answer>(q => q.Answers)
                .WithOne(a => a.Question)
                .HasForeignKey(an => an.QuestionId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
