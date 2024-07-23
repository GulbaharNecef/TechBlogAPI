using Microsoft.EntityFrameworkCore;
using TechBlogAPI.Entities;

namespace TechBlogAPI.IRepositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }

        IQueryable<T> GetAll();
        Task<T> GetByID(string id);
        Task<bool> AddAsync(T data);
        bool Remove(T data);
        Task<T> RemoveById(string id);
        bool Update(T data);
    }
}
