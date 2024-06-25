using SuperLoja.Api.Domain.Entidades;
using SuperLoja.Api.Domain.Repository;
using SuperLoja.Api.Domain.Specs;

namespace SuperLoja.Api.Infrastructure.Repository;


public class VoucherRepository : IVoucherRepository
{
    public void Adicionar(Voucher entity)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Voucher> AsQueryable()
    {
        throw new NotImplementedException();
    }

    public void Commit()
    {
        throw new NotImplementedException();
    }

    public void Editar(Voucher entity)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Voucher> ObterPorSpecification(ISpecification<Voucher> specification)
    {
        throw new NotImplementedException();
    }

}

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

    public void Commit() {}

    public void Editar(Produto entity)
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
                pesoUnitario: 1)
        };
    }

    public IQueryable<Produto> ObterPorSpecification(ISpecification<Produto> specification)
    {
        return AsQueryable().Where(specification.EhSatisfeito).AsQueryable();
    }


    public void Remover(Guid id)
    {
        Console.WriteLine($"Removendo produto com ID {id}");
    }
}
