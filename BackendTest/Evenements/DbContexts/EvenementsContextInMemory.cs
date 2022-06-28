using Backend.Evenements.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Evenements.DbContexts
{
    public partial class EvenementsContextInMemory : DbContext, IEvenementsContext
    {
        public EvenementsContextInMemory()
        {
        }

        public EvenementsContextInMemory(DbContextOptions<EvenementsContextInMemory> options)
            : base(options)
        {
        }

        public  DbSet<Evenement> Evenements { get; set; }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("Evenements");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Evenement>(entity =>
            {
                entity.ToTable("evenements");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Datedebut)
                    .HasColumnType("datetime")
                    .HasColumnName("datedebut");

                entity.Property(e => e.Datefin)
                    .HasColumnType("datetime")
                    .HasColumnName("datefin");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.Nom)
                    .HasMaxLength(32)
                    .HasColumnName("nom");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
