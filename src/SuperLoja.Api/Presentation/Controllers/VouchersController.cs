using Microsoft.AspNetCore.Mvc;

namespace SuperLoja.Api.Presentation.Controllers;

[ApiController]
public class VouchersController : ControllerBase
{
        
    /// <summary>
    /// Lista as vouchers disponiveis cadastradas de acordo com os filtros
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult ListarVouchersAplicaveis()
    {
        return Ok();
    }

        
    /// <summary>
    /// Cadastra um voucher
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public ActionResult Cadastrar()
    {
        return Ok();
    }

        
    /// <summary>
    /// Desativara as vouchers recebidas
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public ActionResult Desativavouchers()
    {
        return Ok();
    }
}