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
        public override Cast GetById(int id)
        {

            var cast = _dbContext.Cast.Include(c => c.CastMovies).ThenInclude(c => c.Movie).FirstOrDefault(c => c.Id == id);
            return cast;
        }
    }
}
