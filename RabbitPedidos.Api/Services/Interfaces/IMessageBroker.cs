namespace RabbitPedidos.Api.Services.Interfaces;

public interface IMessageBroker
{
    Task PublishMessage<T>(string queueName, T message) where T : class;
    Task SubscribeMessage<T>(string queueName, Func<T, Task> handler) where T : class;
}
