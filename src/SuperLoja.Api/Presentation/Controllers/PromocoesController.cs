using Microsoft.AspNetCore.Mvc;

namespace SuperLoja.Api.Presentation.Controllers;

[ApiController]
public class PromocoesController : ControllerBase
{
        
    /// <summary>
    /// Lista as promocoes disponiveis cadastradas de acordo com os filtros
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult ListarPromocoesDisponiveis()
    {
        return Ok();
    }

        
    /// <summary>
    /// Cadastra uma promocao
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public ActionResult Cadastrar()
    {
        return Ok();
    }

        
    /// <summary>
    /// Desativara as promocoes recebidas
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public ActionResult DesativaPromocoes()
    {
        return Ok();
    }
}