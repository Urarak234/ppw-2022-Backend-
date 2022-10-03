using Microsoft.EntityFrameworkCore;
using Backend.API._2.Entities;


namespace Backend.API._2.Data
{
    public partial class GameStoreContext : DbContext
    {
        public GameStoreContext(DbContextOptions<GameStoreContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().Ignore(p => p.tags);
                /*.Property(b => b.tags)
                .IsRequired();*/
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Publishers> Publisher { get; set; }
        public DbSet<Types> Type { get; set; }
    }
}
