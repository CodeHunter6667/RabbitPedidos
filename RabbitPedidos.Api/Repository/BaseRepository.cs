using Microsoft.EntityFrameworkCore;
using RabbitPedidos.Api.Data;
using RabbitPedidos.Api.Repository.Interfaces;
using System.Linq.Expressions;

namespace RabbitPedidos.Api.Repository;

public abstract class BaseRepository<T>(PedidosDbContext context) : IBaseRepository<T> where T : class
{
    public async Task<IEnumerable<T>> GetAll()
        => await context.Set<T>().AsNoTracking().ToListAsync();

    public async Task<T?> Get(Expression<Func<T, bool>> predicate)
        => await context.Set<T>().FirstOrDefaultAsync(predicate);

    public async Task Insert(T entity)
    {
        context.Set<T>().Add(entity);
        await context.SaveChangesAsync();
    }

    public async Task Update(T entity)
    {
        context.Set<T>().Entry(entity).State = EntityState.Modified;
        context.Set<T>().Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task Delete(T entity)
    {
        context.Set<T>().Remove(entity);
        await context.SaveChangesAsync();
    }
}
