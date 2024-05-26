using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuperLoja.Api.Domain.Dtos;
using SuperLoja.Api.Domain.Repository;
using SuperLoja.Api.Domain.Services;
using SuperLoja.Api.Presentation.ViewModel;
using System.Net;

namespace SuperLoja.Api.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly ProdutoService _produtoService;
    private readonly IMapper _mapper;

    public ProdutosController(
        IProdutoRepository produtoRepository, 
        ProdutoService produtoService,
        IMapper mapper)
    {
        _produtoRepository = produtoRepository;
        _produtoService = produtoService;
        _mapper = mapper;
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
    /// Obtém produto pelo Id dele
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ProdutoDto), (int)HttpStatusCode.OK)]
    public ActionResult<ProdutoDto> ObterPorId(Guid id)
    {
        var produto = _produtoRepository.ObterPorId(id);
        if (produto == null)
            return NoContent();
        return Ok();
    }

    /// <summary>
    /// Obtém o produto pelo código
    /// </summary>
    /// <param name="codigo"></param>
    /// <returns></returns>
    [HttpGet("codigo/{codigo}")]
    [ProducesResponseType(typeof(ProdutoDto), (int)HttpStatusCode.OK)]
    public ActionResult<ProdutoDto> ObterPorCodigo(string codigo)
    {
        var produto = _produtoRepository.ObterPorCodigo(codigo);
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
    public ActionResult Cadastrar(CriarProdutoViewModel model)
    {
        var dto = _mapper.Map<CriarProdutoDto>(model);
        return Ok(_produtoService.Cadastrar(dto));
    }
}
