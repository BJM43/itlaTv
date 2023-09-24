using Database.Contexts;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public class GenderRepository
    {
        private readonly ApplicationContext _dbcontext;

        public GenderRepository(ApplicationContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddAsync(Gender gender)
        {
            await _dbcontext.Genders.AddAsync(gender);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Gender gender)
        {
            _dbcontext.Entry(gender).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Gender gender)
        {
            _dbcontext.Set<Gender>().Remove(gender);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<List<Gender>> GetAllAsync()
        {
            return await _dbcontext.Set<Gender>().ToListAsync();
        }

        public async Task<Gender> GetByIdAsync(int id)
        {
            return await _dbcontext.Set<Gender>().FindAsync(id);
        }
    }
}
