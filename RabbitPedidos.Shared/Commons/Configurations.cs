namespace RabbitPedidos.Shared.Commons;

public static class Configurations
{
    public static string RABBITMQ_HOSTNAME { get; set; } = string.Empty;
    public static string RABBITMQ_USERNAME { get; set; } = string.Empty;
    public static string RABBITMQ_PASSWORD { get; set; } = string.Empty;
    public static string RABBITMQ_QUEUE_PEDIDOS { get; set; } = "pedido.criado";
    public static string ConnectionString { get; set; } = string.Empty;
}
