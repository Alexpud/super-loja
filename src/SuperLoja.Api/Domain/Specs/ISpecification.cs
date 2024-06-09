namespace SuperLoja.Api.Domain.Specs;

// COmentario fo isugestao do SonarQube para dar suporte a contravariancias: https://learn.microsoft.com/en-us/dotnet/standard/generics/covariance-and-contravariance
public interface ISpecification<in T>
{
    public bool EhSatisfeito(T parametro);
}
