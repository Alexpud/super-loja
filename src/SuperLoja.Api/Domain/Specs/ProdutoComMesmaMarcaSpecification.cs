using SuperLoja.Api.Domain.Entidades;
using System.Linq.Expressions;

namespace SuperLoja.Api.Domain.Specs;

public class ProdutoComMesmaMarcaSpecification(string marca) : LinqSpecification<Produto>
{
    private readonly string _marca = marca;
    public override Expression<Func<Produto, bool>> GetExpression()
        => produto => produto.Marca == _marca;
}
