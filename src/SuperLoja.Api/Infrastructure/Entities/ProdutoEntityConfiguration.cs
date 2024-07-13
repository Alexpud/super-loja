using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperLoja.Api.Domain.Entidades;

namespace SuperLoja.Api.Infrastructure.Entities;

public class ProdutoEntityConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produtos");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Nome).IsRequired().HasMaxLength(150);
        builder.Property(p => p.Codigo).IsRequired().HasMaxLength(150);
        builder.Property(p => p.Marca).HasMaxLength(50);
        builder.Property(p => p.Quantidade).IsRequired();

        builder.HasIndex(["Nome", "Marca"]);
    }
}
