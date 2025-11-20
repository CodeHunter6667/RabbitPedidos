using Microsoft.EntityFrameworkCore;
using RabbitPedidos.Api.Data;
using RabbitPedidos.Api.Repository.Interfaces;
using System.Linq.Expressions;

namespace RabbitPedidos.Api.Repository;

public class BaseRepository<T>(PedidosDbContext context) : IBaseRepository<T> where T : class
{
    public IEnumerable<T> GetAll()
        => context.Set<T>().AsEnumerable();

    public T? GetById(Expression<Func<T, bool>> predicate)
        => context.Set<T>().FirstOrDefault(predicate);

    public void Insert(T entity)
    {
        context.Set<T>().Add(entity);
        context.SaveChanges();
    }

    public void Update(T entity)
    {
        context.Set<T>().Entry(entity).State = EntityState.Modified;
        context.Set<T>().Update(entity);
        context.SaveChanges();
    }

    public void Delete(T entity)
    {
        context.Set<T>().Remove(entity);
        context.SaveChanges();
    }
}
