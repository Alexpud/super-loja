namespace SuperLoja.Api.Domain.Specs;

public class AndSpecification<T> : ISpecification<T> where T: class
{
    private readonly ISpecification<T> _specificationA;
    private readonly ISpecification<T> _specificationB;

    public AndSpecification(ISpecification<T> specificationA, ISpecification<T> specificiationB)
    {
        _specificationA = specificationA;
        _specificationB = specificiationB;
    }

    public bool EhSatisfeito(T parametro)
    {
        return _specificationA.EhSatisfeito(parametro) && _specificationB.EhSatisfeito(parametro);
    }
}