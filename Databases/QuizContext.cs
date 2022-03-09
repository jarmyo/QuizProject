global using System.ComponentModel.DataAnnotations;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
namespace QuizProject.Databases
{
    public class QuizContext : DbContext
    {
        public DbSet<Teams> Teams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = @"Databases\QuizData.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);
            optionsBuilder.UseSqlite(connection);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teams>(entity =>
            {
                entity.HasKey(o => o.Id);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(o => o.Id);

                entity.HasOne(d => d.IdCategoryNavigation)
                .WithMany(p => p.Questions)
                .HasForeignKey(d => d.IdCategory);
            });

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.HasKey(o => o.Id);

                entity.HasOne(d => d.IdQuestionNavigation)
                .WithMany(p => p.Answers)
                .HasForeignKey(d => d.IdQuestion);
            });

        }
    }
}