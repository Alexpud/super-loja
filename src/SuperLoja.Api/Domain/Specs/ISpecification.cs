namespace SuperLoja.Api.Domain.Specs;

public interface ISpecification<T>
{
    public bool EhSatisfeito(T parametro);
}
