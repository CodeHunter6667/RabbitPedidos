namespace RabbitPedidos.Shared.Commons;

public static class Configurations
{
    public const string RABBITMQ_HOSTNAME = "localhost";
    public const string RABBITMQ_USERNAME = "guest";
    public const string RABBITMQ_PASSWORD = "guest";
    public const string RABBITMQ_QUEUE_PEDIDOS = "pedido.criado";
    public static string ConnectionString { get; set; } = string.Empty;
}
