using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitPedidos.Api.Services.Interfaces;
using RabbitPedidos.Shared.Commons;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;

namespace RabbitPedidos.Api.Services;

public class MessageBroker : IMessageBroker
{
    private readonly IConnection _connection;
    private readonly IChannel _channel;

    public MessageBroker()
    {
        var factory = new ConnectionFactory()
        {
            HostName = Configurations.RABBITMQ_HOSTNAME,
            UserName = Configurations.RABBITMQ_USERNAME,
            Password = Configurations.RABBITMQ_PASSWORD,
            
        };
        _connection = factory.CreateConnectionAsync().GetAwaiter().GetResult();
        _channel = _connection.CreateChannelAsync().GetAwaiter().GetResult();
    }

    private async Task  CreateQueue(string queueName)
    {
        await _channel.QueueDeclareAsync(
            queue: queueName,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null);
    }

    public async Task PublishMessage<T>(string queueName, T message) where T : class
    {
        await CreateQueue(queueName);

        var json = JsonSerializer.Serialize(message);
        var body = Encoding.UTF8.GetBytes(json);

        var basicProperties = new BasicProperties
        {
            Persistent = true
        };

        await _channel.BasicPublishAsync(
            exchange: "",
            routingKey: queueName,
            mandatory: false,
            basicProperties: basicProperties,
            body: body);
    }

    public async Task SubscribeMessage<T>(string queueName, Func<T, Task> handler) where T : class
    {
        await CreateQueue(queueName);

        await _channel.BasicQosAsync(prefetchSize: 0, prefetchCount: 1, global: false);

        var consumer = new AsyncEventingBasicConsumer(_channel);
        consumer.ReceivedAsync += async (model, ea) =>
        {
            try
            {
                var body = ea.Body.ToArray();
                var json = Encoding.UTF8.GetString(body);
                var message = JsonSerializer.Deserialize<T>(json);

                if (message == null)
                {
                    // Discard malformed message
                    await _channel.BasicNackAsync(ea.DeliveryTag, multiple: false, requeue: false);
                    return;
                }

                await handler(message);
                await _channel.BasicAckAsync(ea.DeliveryTag, false);
            }
            catch (Exception)
            {
                await _channel.BasicNackAsync(ea.DeliveryTag, false, true);
            }
        };

        await _channel.BasicConsumeAsync(
            queue: queueName,
            autoAck: false,
            consumer: consumer);
    }
}
