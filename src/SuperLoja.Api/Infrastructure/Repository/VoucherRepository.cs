using Microsoft.EntityFrameworkCore;
using SuperLoja.Api.Domain.Entidades;
using SuperLoja.Api.Domain.Repository;
using SuperLoja.Api.Domain.Specs;

namespace SuperLoja.Api.Infrastructure.Repository;

public class VoucherRepository(SuperLojaDbContext context) : IVoucherRepository
{
    private readonly SuperLojaDbContext _context = context;
    public void Adicionar(Voucher entity)
    {
        _context.Set<Voucher>().Add(entity);
    }

    public IQueryable<Voucher> AsQueryable() 
        => _context.Set<Voucher>();

    public async Task Commit() 
        => await _context.SaveChangesAsync();

    public void Editar(Voucher entity) 
        => _context.Set<Voucher>().Update(entity);

    public IQueryable<Voucher> EncontrarTodos(BaseSpecification<Voucher> specification) 
        => _context.Set<Voucher>().Where(specification.GetExpression());

    public async Task<Voucher> ObterPorId(Guid id)
        => await _context.Set<Voucher>().FirstOrDefaultAsync(p => p.Id == id);

    public void Remover(Voucher entity)
        => _context.Remove(entity);
}
