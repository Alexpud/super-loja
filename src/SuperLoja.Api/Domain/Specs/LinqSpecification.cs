using System.Linq.Expressions;

namespace SuperLoja.Api.Domain.Specs;

public abstract class LinqSpecification<T> : ISpecification<T> where T : class
{
    protected abstract Expression<Func<T, bool>> GetExpression();

    public bool EhSatisfeito(T parametro)
    {
        return GetExpression().Compile()(parametro);
    }
}
