using ApplicationCore.Contracts.Repositories;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly MovieShopDbContext _dbContext;
        public Repository(MovieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async virtual Task<T> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async virtual Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async virtual Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async virtual Task<T> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
