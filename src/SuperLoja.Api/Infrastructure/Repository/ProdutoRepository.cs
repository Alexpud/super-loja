using SuperLoja.Api.Domain.Entidades;
using SuperLoja.Api.Domain.Repository;

namespace SuperLoja.Api.Infrastructure.Repository;

public class ProdutoRepository : IProdutoRepository
{
    public List<Produto> Listar()
    {
        return new List<Produto>
        {
            new Produto()
            {
                Nome = "Produto novo",
                Codigo = "Codigo novo",
                Marca = "Marca nova",
                PesoUnitario = 2,
                Quantidade = 2,
                Id = Guid.NewGuid()
            }
        };
    }

    public Produto ObterPorCodigo(string codigo)
    {
        return new Produto()
        {
            Codigo = codigo
        };
    }

    public Produto ObterPorId(Guid id)
    {
        return new Produto()
        {
            Id = id
        };
    }
}
