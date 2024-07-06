using SuperLoja.Api.Domain.Entidades;
using SuperLoja.Api.Domain.Repository;
using SuperLoja.Api.Domain.Specs;

namespace SuperLoja.Api.Infrastructure.Repository;

public class VoucherRepository : IVoucherRepository
{
    public void Adicionar(Voucher entity)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Voucher> AsQueryable()
    {
        throw new NotImplementedException();
    }

    public void Atualizar(Voucher voucher)
    {
        throw new NotImplementedException();
    }


    public void Commit()
    {
        throw new NotImplementedException();
    }

    public void Editar(Voucher entity)
    {
        throw new NotImplementedException();
    }

    public Voucher ObterPorId(Guid guid)
    {
        throw new NotImplementedException();
    }


    public IQueryable<Voucher> ObterPorSpecification(ISpecification<Voucher> specification)
    {
        throw new NotImplementedException();
    }

}
