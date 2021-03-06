using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CastRepository : Repository<Cast>, ICastRepository
    {
        public CastRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<Cast> GetById(int id)
        {
            
            var cast = await _dbContext.Cast.Include(c => c.CastMovies).ThenInclude(c => c.Movie).FirstOrDefaultAsync(c => c.Id == id);
            return cast;
        }

        public async Task<List<Cast>> GetAllCasts()
        {
            var casts = await _dbContext.Cast.ToListAsync();
            return casts;
        }
    }
}
