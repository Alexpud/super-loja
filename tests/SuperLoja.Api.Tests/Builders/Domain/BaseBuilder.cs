namespace SuperLoja.Api.Tests.Builders.Domain;

public abstract class BaseBuilder<TEntity, TBuilder>
{
    protected TEntity _object;
    
    public abstract TBuilder ComPropriedadesPreenchidas();

    public abstract TEntity Build();
}
