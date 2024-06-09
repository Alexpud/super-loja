using SuperLoja.Api.Domain.Entidades;
using System.Linq.Expressions;

namespace SuperLoja.Api.Domain.Specs.Produtos;

public class ProdutoComMesmaMarcaSpecification(string marca) : LinqSpecification<Produto>
{
    private readonly string _marca = marca;
    protected override Expression<Func<Produto, bool>> GetExpression()
        => produto => produto.Marca == _marca;
}
