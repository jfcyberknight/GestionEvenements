using Backend.Evenements.DbContexts;
using Backend.Evenements.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Evenements.Repository
{
    public class EvenementsRepository: IRepository<Evenement>
    {
        private readonly IEvenementsContext _context;
        public EvenementsRepository(IEvenementsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Evenement>> GetAll()
        {
            if (_context.Evenements == null)
            {
                throw new Exception("Not found");
            }
            return await _context.Evenements.ToListAsync();
        }

        public async Task<Evenement> Post(Evenement entity)
        {
            _context.Evenements.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Evenement> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Evenement> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Evenement> UpdateById(Evenement entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Evenement> DeleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
