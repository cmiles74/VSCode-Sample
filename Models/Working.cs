using Microsoft.EntityFrameworkCore;

namespace Working.Models
{
    public class WorkingContext : DbContext
    {
        public DbSet<Friend> Friends {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlite("Filename=./Friends.db");
        }
    }

    public class Friend 
    {
        public int Id {get; set;}
        public string Name { get; set;}
    }
}
