using RabbitPedidos.Api.Repository.Interfaces;
using RabbitPedidos.Api.Services.Interfaces;
using System.Linq.Expressions;

namespace RabbitPedidos.Api.Services;

public class BaseService<T>(IBaseRepository<T> repository) : IBaseService<T> where T : class
{
    public void Insert(T entity)
        => repository.Insert(entity);

    public void Update(T entity)
        => repository.Update(entity);

    public void Delete(T entity)
        => repository.Delete(entity);

    public IEnumerable<T> GetAll()
        => repository.GetAll();

    public T? GetById(Expression<Func<T, bool>> predicate)
        => repository.GetById(predicate);
}
