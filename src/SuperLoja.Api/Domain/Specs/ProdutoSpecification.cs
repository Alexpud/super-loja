using SuperLoja.Api.Domain.Entidades;
using System.Linq.Expressions;

namespace SuperLoja.Api.Domain.Specs;

public class ProdutoComMesmoCodigoSpecification(string codigo) : LinqSpecification<Produto>
{
    private readonly string _codigo = codigo;
    public override Expression<Func<Produto, bool>> GetExpression()
        => produto => produto.Codigo == _codigo;
}
