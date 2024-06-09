using SuperLoja.Api.Domain.Entidades;
using SuperLoja.Api.Domain.Specs;

namespace SuperLoja.Api.Domain.Repository;

public interface IProdutoRepository
{
    IQueryable<Produto> AsQueryable();
    IQueryable<Produto> ObterPorSpecification(ISpecification<Produto> specification);
    List<Produto> Listar();
    void Adicionar(Produto produto);
    void Commit();
    void Remover(Guid id);
}
