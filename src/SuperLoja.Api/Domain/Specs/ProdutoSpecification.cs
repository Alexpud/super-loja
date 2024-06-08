using SuperLoja.Api.Domain.Entidades;
using System.Linq.Expressions;

namespace SuperLoja.Api.Domain.Specs;

public class ProdutoComMesmoCodigoSpecification(string codigo) : LinqSpecification<Produto>
{
    private readonly string _codigo = codigo;
    public override Expression<Func<Produto, bool>> GetExpression()
        => produto => produto.Codigo == _codigo;
}

public class ProdutoComMesmaMarcaSpecification(string marca) : LinqSpecification<Produto>
{
    private readonly string _marca = marca;
    public override Expression<Func<Produto, bool>> GetExpression()
        => produto => produto.Marca == _marca;
}

public class ProdutoComMesmoNomeSpecification(string nome) : LinqSpecification<Produto>
{
    private readonly string _nome = nome;
    public override Expression<Func<Produto, bool>> GetExpression()
        => produto => produto.Nome == _nome;
}
