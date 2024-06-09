using SuperLoja.Api.Domain.Entidades;
using System.Linq.Expressions;

namespace SuperLoja.Api.Domain.Specs;

public class ProdutoComMesmoNomeSpecification(string nome) : LinqSpecification<Produto>
{
    private readonly string _nome = nome;
    protected override Expression<Func<Produto, bool>> GetExpression()
        => produto => produto.Nome == _nome;
}
