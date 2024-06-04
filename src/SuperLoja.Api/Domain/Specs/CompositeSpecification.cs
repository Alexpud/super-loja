namespace SuperLoja.Api.Domain.Specs;

public class CompositeSpecification<T> : ISpecification<T> where T: class
{
    private readonly ISpecification<T> _specificationA;
    private readonly ISpecification<T> _specificationB;

    public CompositeSpecification(ISpecification<T> specificationA, ISpecification<T> specificiationB)
    {
        this._specificationA = specificationA;
        this._specificationB = specificiationB;
    }

    public bool EhSatisfeito(T parametro)
    {
        return _specificationA.EhSatisfeito(parametro) && _specificationB.EhSatisfeito(parametro);
    }
}