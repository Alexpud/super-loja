using System.Linq.Expressions;

namespace SuperLoja.Api.Domain.Specs;

public class AndSpecification<T> : BaseSpecification<T> where T: class
{
    public AndSpecification(ISpecification<T> specificationA, ISpecification<T> specificiationB)
    {
        var expr1 = specificationA.GetExpression();
        var expr2 = specificiationB.GetExpression();
        var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
        expression = Expression.Lambda<Func<T, bool>>
              (Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
    }
}