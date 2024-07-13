using Microsoft.EntityFrameworkCore;
using SuperLoja.Api.Domain.Entidades;
using SuperLoja.Api.Domain.Repository;
using SuperLoja.Api.Domain.Specs;

namespace SuperLoja.Api.Infrastructure.Repository;

public class ProdutoRepository(SuperLojaDbContext context) : IProdutoRepository
{
    private readonly SuperLojaDbContext _context = context;
    public void Adicionar(Produto produto) 
        => _context.Set<Produto>().Add(produto);

    public IQueryable<Produto> AsQueryable()
        => _context.Set<Produto>();

    public async Task Commit()
        => await _context.SaveChangesAsync();

    public void Editar(Produto entity)
        => _context.Set<Produto>().Update(entity);
    public async Task<Produto> ObterPorId(Guid id)
        => await _context.Set<Produto>().FirstOrDefaultAsync(p => p.Id == id);

    public List<Produto> Listar()
    {
        return new List<Produto>
        {
            new Produto(
                nome: "Produto novo",
                codigo: "Codigo novo",
                marca: "Marca nova",
                quantidade: 2,
                pesoUnitario: 1)
        };
    }

    public IQueryable<Produto> EncontrarTodos(BaseSpecification<Produto> specification) 
        => AsQueryable().Where(specification.GetExpression());


    public void Remover(Produto produto)
        => _context.Set<Produto>().Remove(produto);
}
