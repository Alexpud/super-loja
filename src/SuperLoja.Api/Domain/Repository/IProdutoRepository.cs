using SuperLoja.Api.Domain.Entidades;

namespace SuperLoja.Api.Domain.Repository;

public interface IProdutoRepository
{
    List<Produto> Listar();
    Produto ObterPorId(Guid id);
    Produto ObterPorCodigo(string codigo);
}
