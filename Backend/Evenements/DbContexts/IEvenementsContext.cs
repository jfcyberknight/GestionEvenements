using Backend.Evenements.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Evenements.DbContexts
{
    public interface IEvenementsContext
    {
        DbSet<Evenement> Evenements { get; }

        Task SaveChangesAsync();
    }
}
