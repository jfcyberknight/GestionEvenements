using Backend.Evenements.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Evenements.DbContexts
{
    public partial class EvenementsContext : DbContext , IEvenementsContext
    {
        public EvenementsContext()
        {
        }

        public EvenementsContext(DbContextOptions<EvenementsContext> options)
            : base(options)
        {
        }

        public DbSet<Evenement> Evenements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=test;database=evenements", ServerVersion.Parse("10.7.3-mariadb"));
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
