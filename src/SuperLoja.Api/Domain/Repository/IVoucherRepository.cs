using SuperLoja.Api.Domain.Entidades;

namespace SuperLoja.Api.Domain.Repository;

public interface IVoucherRepository : IRepository<Voucher>
{
    void Atualizar(Voucher voucher);

    Voucher ObterPorId(Guid guid);

}