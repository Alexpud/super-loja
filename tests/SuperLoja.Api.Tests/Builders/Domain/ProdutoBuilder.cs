using AutoFixture;
using SuperLoja.Api.Domain.Entidades;

namespace SuperLoja.Api.Tests.Builders.Domain;

public class ProdutoBuilder : BaseBuilder<Produto, ProdutoBuilder>
{
    private readonly Fixture _fixture = new();
    private string _codigo;
    public override ProdutoBuilder BuildDefault()
    {
        return this;
    }

    public ProdutoBuilder ComCodigo(string codigo)
    {
        _codigo = codigo;
        return this;
    }

    public override Produto Create()
    {
        return new Produto(
            nome: _fixture.Create<string>(),
            codigo: _codigo ?? _fixture.Create<string>(),
            marca: _fixture.Create<string>(),
            quantidade: _fixture.Create<int>(),
            quantidadeMinima: _fixture.Create<int>(),
            pesoUnitario: _fixture.Create<float>());
    }
}

public abstract class BaseBuilder<TEntity, TBuilder>
{
    protected TEntity _object;
    
    public abstract TBuilder BuildDefault();

    public virtual TEntity Create() => _object;
}
