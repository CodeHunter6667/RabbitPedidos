using System.Linq.Expressions;

namespace RabbitPedidos.Api.Repository.Interfaces;

public interface IBaseRepository<T> where T : class
{
    Task Delete(T entity);
    Task<IEnumerable<T>> GetAll();
    Task<T?> Get(Expression<Func<T, bool>> predicate);
    Task Insert(T entity);
    Task Update(T entity);
}