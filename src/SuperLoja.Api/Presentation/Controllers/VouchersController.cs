using Microsoft.AspNetCore.Mvc;

namespace SuperLoja.Api.Presentation.Controllers;

[ApiController]
public class VouchersController(IVoucherRepository repository) : ControllerBase
{
    private readonly IVoucherRepository _repository = repository;
        
    /// <summary>
    /// Lista as vouchers aplicaveis para o periodo
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult ListarVouchersAplicaveis(DateTime periodo)
    {
        var spec = new VoucherAplicavelSpecification(periodo);
        return Ok(_repository.ObterPorSpecification(spec));
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