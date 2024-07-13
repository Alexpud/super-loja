using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperLoja.Api.Domain.Entidades;

namespace SuperLoja.Api.Infrastructure.Entities;

public class VoucherEntityConfiguration : IEntityTypeConfiguration<Voucher>
{
    public void Configure(EntityTypeBuilder<Voucher> builder)
    {
        builder.ToTable("Vouchers");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Codigo).HasMaxLength(50).IsRequired();
        builder.Property(p => p.DataExpiracao).IsRequired();
        builder.Property(p => p.Taxa).IsRequired();
    }
}
