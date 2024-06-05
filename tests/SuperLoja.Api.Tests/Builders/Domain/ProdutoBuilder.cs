using AutoFixture;
using SuperLoja.Api.Domain.Entidades;

namespace SuperLoja.Api.Tests.Builders.Domain;

public class ProdutoBuilder : BaseBuilder<Produto, ProdutoBuilder>
{
    private readonly Fixture _fixture = new();
    private string _codigo, _nome, _marca;
    private int _quantidade;

    public override Produto Build()
    {
        return new Produto(
            nome: _nome,
            codigo: _codigo,
            marca: _marca,
            quantidade: _quantidade,
            pesoUnitario: _fixture.Create<float>());
    }

    public ProdutoBuilder ComCodigo(string codigo)
    {
        _codigo = codigo;
        return this;
    }


    public ProdutoBuilder ComNome(string nome)
    {
        _nome = nome;
        return this;
    }

    public ProdutoBuilder ComMarca(string marca)
    {
        _marca = marca;
        return this;
    }

    public ProdutoBuilder ComQuantidade(int quantidade)
    {
        _quantidade = quantidade;
        return this;
    }

    public override ProdutoBuilder ComPropriedadesPreenchidas()
    {
        _codigo = _fixture.Create<string>();
        _nome = _fixture.Create<string>();
        _marca = _fixture.Create<string>();
        return this;
    }
}