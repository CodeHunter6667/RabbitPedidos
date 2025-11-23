using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RabbitPedidos.Shared.Models;

namespace RabbitPedidos.Api.Data.Mapping;

public class PedidoMapping : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.ToTable("Pedidos");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.NomeCliente)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Descricao)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(p => p.Valor)
            .IsRequired()
            .HasColumnType("DECIMAL(18,2)");

        builder.Property(p => p.Status)
            .IsRequired()
            .HasColumnType("SMALLINT");
    }
}
