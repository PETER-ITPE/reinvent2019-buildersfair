using BuildersFair_API.Models;
using Microsoft.EntityFrameworkCore;

namespace BuildersFair_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}

        public DbSet<StageLog> StageLog { get; set; }
        public DbSet<Object> Object { get; set; }
        public DbSet<StageObject> StageObject { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<GameResult> GameResult { get; set; }
        public DbSet<TestPicture> TestPicture { get; set; }
        public DbSet<TestPictureLabel> TestPictureLabel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // To support composite key
            modelBuilder.Entity<StageLog>()
                .HasKey(c => new {c.game_id, c.stage_id});
            modelBuilder.Entity<TestPictureLabel>()
                .HasKey(c => new {c.picture_id, c.label_name});
            modelBuilder.Entity<StageObject>()
                .HasKey(c => new {c.game_id, c.stage_id, c.object_name});    
        }
    }
}