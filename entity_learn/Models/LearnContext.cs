using Microsoft.EntityFrameworkCore;

namespace entity_learn.Models
{
    public class LearnContext : DbContext
    {
        // base() calls the parent class' consturctor passing the "options" parameter along
        // inheritance!!!!
        public LearnContext(DbContextOptions<LearnContext> options) :base(options) { }
        
        // put your DbSets in here!
        // RULES:
        // DbSet<Model> NAME_THAT_MATCHES_THE_DB_TABLE_NAME {get;set;}
        public DbSet<User> Users {get; set;}
    }
}