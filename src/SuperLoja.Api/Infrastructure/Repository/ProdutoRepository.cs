using SuperLoja.Api.Domain.Entidades;
using SuperLoja.Api.Domain.Repository;

namespace SuperLoja.Api.Infrastructure.Repository;

public class ProdutoRepository : IProdutoRepository
{
    public void Adicionar(Produto produto)
    {
        Console.WriteLine($"Produto com nome {produto.Nome}foi adicionado com sucesso");
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
                pesoUnitario: 1)
        }.AsQueryable();
    }

    public void Commit()
    {
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
                pesoUnitario: 1)
        };
    }

    public Produto ObterPorCodigo(string codigo)
    {
        return new Produto(
            nome: "Produto novo",
            codigo: codigo,
            marca: "Marca nova",
            quantidade: 2,
            pesoUnitario: 1);
    }

    public Produto ObterPorId(Guid id)
    {
        Console.WriteLine($"Obtendo produto com ID {id}");
        return new Produto(
            nome: "Produto novo",
            codigo: "Codigo novo",
            marca: "Marca nova",
            quantidade: 2,
            pesoUnitario: 1);
    }

    public void Remover(Guid id)
    {
        Console.WriteLine($"Removendo produto com ID {id}");
    }
}
