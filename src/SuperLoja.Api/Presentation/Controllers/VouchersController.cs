using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuperLoja.Api.Domain.Dtos;
using SuperLoja.Api.Domain.Repository;
using SuperLoja.Api.Domain.Specs.Vouchers;

namespace SuperLoja.Api.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VouchersController(IVoucherRepository repository, IMapper mapper) : ControllerBase
{
    private readonly IVoucherRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    /// <summary>
    /// Lista as vouchers aplicaveis para o periodo
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<VoucherDto>), (int)HttpStatusCode.OK)]
    public ActionResult ListarVouchersAplicaveis(DateTime periodo)
    {
        var spec = new VoucherAplicavelSpecification(periodo);
        var vouchers = _repository.ObterPorSpecification(spec);
        return base.Ok(_mapper.ProjectTo<VoucherDto>(vouchers));
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