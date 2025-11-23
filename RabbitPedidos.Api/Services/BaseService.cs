using RabbitPedidos.Api.Repository.Interfaces;
using RabbitPedidos.Api.Services.Interfaces;
using System.Linq.Expressions;

namespace RabbitPedidos.Api.Services;

public abstract class BaseService<T>(IBaseRepository<T> repository) : IBaseService<T> where T : class
{
    public async Task Insert(T entity)
        => await repository.Insert(entity);

    public async Task Update(T entity)
        => await repository.Update(entity);

    public async Task Delete(T entity)
        => await repository.Delete(entity);

    public async Task<IEnumerable<T>> GetAll()
        => await repository.GetAll();

    public async Task<T?> Get(Expression<Func<T, bool>> predicate)
        => await repository.Get(predicate);
}
