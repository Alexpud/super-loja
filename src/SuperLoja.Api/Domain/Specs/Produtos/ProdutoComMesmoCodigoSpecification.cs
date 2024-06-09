using SuperLoja.Api.Domain.Entidades;
using System.Linq.Expressions;

namespace SuperLoja.Api.Domain.Specs.Produtos;

public class ProdutoComMesmoCodigoSpecification(string codigo) : LinqSpecification<Produto>
{
    private readonly string _codigo = codigo;
    protected override Expression<Func<Produto, bool>> GetExpression()
        => produto => produto.Codigo == _codigo;
}
