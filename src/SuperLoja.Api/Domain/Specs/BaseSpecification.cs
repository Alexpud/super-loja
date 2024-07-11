using System.Linq.Expressions;

namespace SuperLoja.Api.Domain.Specs;

public abstract class BaseSpecification<T> : ISpecification<T> where T : class
{
    protected Expression<Func<T, bool>> expression;

    public bool EhSatisfeito(T parametro)
    {
        return expression.Compile()(parametro);
    }

    public Expression<Func<T, bool>> GetExpression()
        => expression;
}
