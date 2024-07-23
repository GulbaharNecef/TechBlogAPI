using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TechBlogAPI.Entities;
using TechBlogAPI.Exceptions;
using TechBlogAPI.IRepositories;

namespace TechBlogAPI.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        public Repository(ApplicationDbContext context)
        {
            _context = context; 
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T data)
        {
           var info = _context.Add(data);
           await _context.SaveChangesAsync();
           return info.State == EntityState.Added;
        }

        public IQueryable<T> GetAll()
        {
           return Table.AsQueryable();
        }

        public async Task<T> GetByID(string id)
        {
            bool checkIdFormat = Guid.TryParse(id, out Guid result);
            if (checkIdFormat)
            {
                var query = Table.AsQueryable();
                return await query.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
            }
            else
                throw new InvalidIdFormatException(id);

        }
        
        public bool Remove(T data)
        {
           EntityEntry entityEntry = Table.Remove(data);
            _context.SaveChanges();
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<T> RemoveById(string id)
        {
            T model = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
            Table.Remove(model);
           await _context.SaveChangesAsync();
            return model;
        }

        public bool Update(T data)
        {
            EntityEntry entityEntry = Table.Update(data);
            _context.SaveChanges();
            return entityEntry.State == EntityState.Modified;
        }
    }
}
