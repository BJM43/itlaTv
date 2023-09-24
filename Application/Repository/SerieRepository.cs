using Database.Contexts;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class SerieRepository
    {
        private readonly ApplicationContext _dbcontext;

        public SerieRepository(ApplicationContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddAsync(TvSerie serie)
        {
            await _dbcontext.TvSeries.AddAsync(serie);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TvSerie serie) 
        {
            _dbcontext.Entry(serie).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TvSerie serie) 
        {
            _dbcontext.Set<TvSerie>().Remove(serie);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<List<TvSerie>> GetAllAsync()
        {
            return await _dbcontext.Set<TvSerie>().ToListAsync();
        }

        public async Task<TvSerie> GetByIdAsync( int id)
        {
            return await _dbcontext.Set<TvSerie>().FindAsync(id);
        }
    }
}
