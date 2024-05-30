﻿using FluentResults;
using SuperLoja.Api.Domain.Dtos;
using SuperLoja.Api.Domain.Entidades;
using SuperLoja.Api.Domain.Repository;

namespace SuperLoja.Api.Domain.Services;

public class ProdutoService
{
    private IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public Result Cadastrar(CriarProdutoDto dto)
    {
        var produto = new Produto(
            nome: dto.Nome,
            codigo: dto.Codigo,
            marca: dto.Marca,
            quantidade: dto.Quantidade,
            quantidadeMinima: dto.QuantidadeMinima,
            pesoUnitario: dto.PesoUnitario);

        var validationResult = produto.Validar();
        if (!validationResult.IsValid)
            return new Result().WithError(new Error("Dados invalidos de produto"));

        var produtoJaExisteResult = ValidarProdutoJaExistente(produto);
        if (produtoJaExisteResult.IsFailed)
            return produtoJaExisteResult;

        throw new NotImplementedException();
    }

    private Result ValidarProdutoJaExistente(Produto produto)
    {
        var result = new Result();
        bool existeDuplicata = false;
        existeDuplicata = _produtoRepository
            .AsQueryable()
            .Any(p => p.Codigo == produto.Codigo);

        if (existeDuplicata)
            result = result.WithError((new Error("Já existe um produto com esse código")));

        existeDuplicata = _produtoRepository
            .AsQueryable()
            .Any(p => p.Nome == produto.Nome && p.Marca == produto.Marca);
        
        if (existeDuplicata)
            result = result.WithError(new Error("Já existe um produto com essa marca e nome"));

        return result;
    }
}