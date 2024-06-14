using SuperLoja.Api.Domain.Entidades;
using SuperLoja.Api.Domain.Specs;

public interface IVoucherRepository 
{
    IQueryable<Voucher> AsQueryable();
    IQueryable<Voucher> ObterPorSpecification(ISpecification<Voucher> specification);
}