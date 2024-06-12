using System.Linq.Expressions;
using SuperLoja.Api.Domain.Entidades;
using SuperLoja.Api.Domain.Specs;

public class PromocaoDisponivelSpecification(DateTime data) : LinqSpecification<Promocao>
{
    private readonly DateTime _date = data;

    protected override Expression<Func<Promocao, bool>> GetExpression()
    {
        return p => p.EstaDisponivel(_date);
    }
}