using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using SuperLoja.Api.Domain.Dtos;
using SuperLoja.Api.Domain.Entidades;
using SuperLoja.Api.Domain.Repository;
using SuperLoja.Api.Domain.Services;
using SuperLoja.Api.Domain.Specs.Produtos;
using SuperLoja.Api.Presentation.ViewModels;
using System.Net;

namespace SuperLoja.Api.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController(IProdutoRepository produtoRepository, ProdutoService produtoService, IMapper mapper, ILogger<ProdutosController> logger) : ControllerBase
{
    private readonly IProdutoRepository _produtoRepository = produtoRepository;
    private readonly ProdutoService _produtoService = produtoService;
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<ProdutosController> _logger = logger;

    [HttpGet("log")]
    public ActionResult Logar()
    {
        _logger.LogInformation("Informação");
        return Ok();
    }

    /// <summary>
    /// Lista todos os produtos disponiveis
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<ProdutoDto>), (int)HttpStatusCode.OK)]
    public ActionResult<List<ProdutoDto>> Listar()
    {
        var produtos = _produtoRepository.Listar();
        return Ok(_mapper.Map<List<ProdutoDto>>(produtos));
    }

    /// <summary>
    /// Obt�m produto pelo Id dele
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ProdutoDto), (int)HttpStatusCode.OK)]
    public ActionResult<ProdutoDto> ObterPorId(Guid id)
    {
        var produto = _produtoRepository.AsQueryable()
            .FirstOrDefault(p => p.Id == id);
        if (produto == null)
            return NoContent();
        return Ok();
    }

    /// <summary>
    /// Obt�m o produto pelo c�digo
    /// </summary>
    /// <param name="codigo"></param>
    /// <returns></returns>
    [HttpGet("codigo/{codigo}")]
    [ProducesResponseType(typeof(ProdutoDto), (int)HttpStatusCode.OK)]
    public ActionResult<ProdutoDto> ObterPorCodigo(string codigo)
    {
        var produto = _produtoRepository
            .EncontrarTodos(new ProdutosPorCodigoSpecification(codigo))
            .FirstOrDefault();
        if (produto == null)
            return NoContent();
        return Ok();
    }

    /// <summary>
    /// Cadastra um novo produto
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(Result<Produto>), (int)HttpStatusCode.OK)]
    public ActionResult Cadastrar(CadastrarProdutoViewModel model)
    {
        var dto = _mapper.Map<CadastrarProdutoDto>(model);
        return Ok(_produtoService.Cadastrar(dto));
    }

    /// <summary>
    /// Remove um produto
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public ActionResult Deletar(Guid id)
    {
        _produtoRepository.Remover(id);
        _produtoRepository.Commit();
        return NoContent();
    }
}
