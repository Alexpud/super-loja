using SuperLoja.Api.Domain.Entidades;
using SuperLoja.Api.Domain.Repository;

namespace SuperLoja.Api.Infrastructure.Repository;

public class ProdutoRepository : IProdutoRepository
{
    public void Adicionar(Produto produto)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Produto> AsQueryable()
    {
        return new List<Produto>
        {
            new Produto(
                nome: "Produto novo",
                codigo: "Codigo novo",
                marca: "Marca nova",
                quantidade: 2,
                quantidadeMinima: 2,
                pesoUnitario: 1)
        }.AsQueryable();
    }

    public void Commit()
    {
        throw new NotImplementedException();
    }

    public List<Produto> Listar()
    {
        return new List<Produto>
        {
            new Produto(
                nome: "Produto novo",
                codigo: "Codigo novo",
                marca: "Marca nova",
                quantidade: 2,
                quantidadeMinima: 2,
                pesoUnitario: 1)
        };
    }

    public Produto ObterPorCodigo(string codigo)
    {
        return new Produto(
            nome: "Produto novo",
            codigo: "Codigo novo",
            marca: "Marca nova",
            quantidade: 2,
            quantidadeMinima: 2,
            pesoUnitario: 1);
    }

    public Produto ObterPorId(Guid id)
    {
        return new Produto(
            nome: "Produto novo",
            codigo: "Codigo novo",
            marca: "Marca nova",
            quantidade: 2,
            quantidadeMinima: 2,
            pesoUnitario: 1);
    }
}
