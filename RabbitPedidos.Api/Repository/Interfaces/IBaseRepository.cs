using System.Linq.Expressions;

namespace RabbitPedidos.Api.Repository.Interfaces;

public interface IBaseRepository<T> where T : class
{
    void Delete(T entity);
    IEnumerable<T> GetAll();
    T? GetById(Expression<Func<T, bool>> predicate);
    void Insert(T entity);
    void Update(T entity);
}