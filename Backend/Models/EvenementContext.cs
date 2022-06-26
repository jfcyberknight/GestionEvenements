using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    public class EvenementContext : DbContext
    {
        public EvenementContext(DbContextOptions<EvenementContext> options)
            : base(options)
        {
        }

        public DbSet<Evenement> Evenements { get; set; } = null!;
    }
}
