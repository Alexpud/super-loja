using FluentResults;
using SuperLoja.Api.Domain.Dtos;
using SuperLoja.Api.Domain.Entidades;
using SuperLoja.Api.Domain.Repository;
using SuperLoja.Api.Domain.Specs;
using SuperLoja.Api.Domain.Specs.Produtos;

namespace SuperLoja.Api.Domain.Services;

public class ProdutoService(IProdutoRepository produtoRepository)
{
    private readonly IProdutoRepository _produtoRepository = produtoRepository;
    public Result<Produto> Cadastrar(CadastrarProdutoDto dto)
    {
        var produto = new Produto(
            nome: dto.Nome,
            codigo: dto.Codigo,
            marca: dto.Marca,
            quantidade: dto.Quantidade,
            pesoUnitario: dto.PesoUnitario);

        var validationResult = produto.Validar();
        if (!validationResult.IsValid)
            return new Result().WithError(new Error("Dados invalidos de produto"));

        var produtoJaExisteResult = ValidarProdutoJaExistente(produto);
        if (produtoJaExisteResult.IsFailed)
            return produtoJaExisteResult;

        _produtoRepository.Adicionar(produto);

        _produtoRepository.Commit();

        return new Result<Produto>().WithValue(produto);
    }

    private Result ValidarProdutoJaExistente(Produto produto)
    {
        var result = new Result();
        var produtoComMesmoCodigoSpec = new ProdutoComMesmoCodigoSpecification(produto.Codigo);
        var existeDuplicata = _produtoRepository
            .ObterPorSpecification(produtoComMesmoCodigoSpec)
            .Any();
        if (existeDuplicata)
            result = result.WithError((new Error("Já existe um produto com esse código")));

        var mesmaMarca = new ProdutoComMesmaMarcaSpecification(produto.Marca);
        var mesmoNome = new ProdutoComMesmoNomeSpecification(produto.Nome);
        var mesmaMarcaEProdutoSpec = new AndSpecification<Produto>(mesmoNome, mesmaMarca);
        existeDuplicata = _produtoRepository
            .ObterPorSpecification(mesmaMarcaEProdutoSpec)
            .Any();
                    
        if (existeDuplicata)
            result = result.WithError(new Error("Já existe um produto com essa marca e nome"));

        return result;
    }
}
