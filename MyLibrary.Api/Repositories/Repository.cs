using Microsoft.EntityFrameworkCore;

namespace MyLibrary.Api.Repositories;
public class Repository<T>: IRepository<T> where T: class
    {
        protected DbContext Context;
        public Repository(DbContext context)
        {
            Context = context;
        }

        public async Task<bool> Add(T tEntity)
        {
            await Context.Set<T>().AddAsync(tEntity);
            return true;
        }
    }
