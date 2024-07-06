namespace SuperLoja.Api.Tests.Builders.Domain;

public abstract class BaseBuilder<TEntity, TBuilder> where TBuilder : class, new()
{
    protected TEntity _object;

    public virtual TBuilder BuildDefault() => new TBuilder();

    public abstract TEntity Create();
}
