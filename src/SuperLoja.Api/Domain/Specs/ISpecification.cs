using System.Linq.Expressions;

namespace SuperLoja.Api.Domain.Specs;

// COmentario fo isugestao do SonarQube para dar suporte a contravariancias: https://learn.microsoft.com/en-us/dotnet/standard/generics/covariance-and-contravariance
public interface ISpecification<T>
{
    public Expression<Func<T, bool>> GetExpression();
    public bool EhSatisfeito(T parametro);
}
