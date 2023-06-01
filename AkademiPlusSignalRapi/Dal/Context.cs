using Microsoft.EntityFrameworkCore;

namespace AkademiPlusSignalRapi.Dal
{
    public class Context :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-L7LL5EMD;initial catalog=SignalRDb;integrated security=true");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }

    }
}
