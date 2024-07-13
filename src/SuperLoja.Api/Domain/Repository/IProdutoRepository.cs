using SuperLoja.Api.Domain.Entidades;

namespace SuperLoja.Api.Domain.Repository;

public interface IProdutoRepository : IRepository<Produto>
{
    List<Produto> Listar();
}
