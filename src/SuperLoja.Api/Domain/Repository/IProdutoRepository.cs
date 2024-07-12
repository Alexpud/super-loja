using SuperLoja.Api.Domain.Entidades;
using SuperLoja.Api.Domain.Specs;

namespace SuperLoja.Api.Domain.Repository;

public interface IProdutoRepository : IRepository<Produto>
{
    List<Produto> Listar();
}
