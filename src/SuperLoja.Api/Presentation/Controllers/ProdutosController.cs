using Microsoft.AspNetCore.Mvc;
using SuperLoja.Api.Domain.Dtos;
using SuperLoja.Api.Presentation.ViewModel;
using System.Net;

namespace SuperLoja.Api.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    /// <summary>
    /// Lista todos os produtos disponiveis
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<ProdutoDto>), (int)HttpStatusCode.OK)]
    public ActionResult<List<ProdutoDto>> Listar()
    {
        return Ok(new List<ProdutoDto>());
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
        return Ok();
    }

    [HttpGet("codigo/{codigo}")]
    [ProducesResponseType(typeof(ProdutoDto), (int)HttpStatusCode.OK)]
    public ActionResult<ProdutoDto> ObterPorCodigo(string codigo)
    {
        return Ok();
    }

    /// <summary>
    /// Cadastra um novo produto
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult Cadastrar(CriarProdutoViewModel dto)
    {
        return Ok();
    }
}
