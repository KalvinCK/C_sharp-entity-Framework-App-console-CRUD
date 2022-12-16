using Microsoft.EntityFrameworkCore;

namespace SQLiteConsole
{
    public class GameContext : DbContext
    {
        public DbSet<Game> ?Games { get; set; }

        public string DbPath = "DB/Game.db";

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    }
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Developer { get; set; } = string.Empty;

    }
    
}
