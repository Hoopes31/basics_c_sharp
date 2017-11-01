using Microsoft.EntityFrameworkCore;

namespace restEntity.Models
{
    public class EntityContext: DbContext
    {
        public EntityContext(DbContextOptions<EntityContext> options) : base (options) { }
        public DbSet<Restaurant> Restaurants {get;set;}
    }
}