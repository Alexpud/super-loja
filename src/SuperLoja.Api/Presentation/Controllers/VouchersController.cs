using System.Net;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using SuperLoja.Api.Domain.Dtos;
using SuperLoja.Api.Domain.Repository;
using SuperLoja.Api.Domain.Services;
using SuperLoja.Api.Domain.Specs.Vouchers;
using SuperLoja.Api.Presentation.ViewModels;

namespace SuperLoja.Api.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VouchersController(IVoucherRepository repository, VoucherService voucherService, IMapper mapper) : ControllerBase
{
    private readonly IVoucherRepository _repository = repository;
    private readonly VoucherService _voucherService = voucherService;
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
        var vouchers = _repository.EncontrarTodos(spec);
        return base.Ok(_mapper.ProjectTo<VoucherDto>(vouchers));
    }

        
    /// <summary>
    /// Cadastra um voucher
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(VoucherDto), (int) HttpStatusCode.OK)]
    public ActionResult Cadastrar(CadastrarVoucherViewModel model)
    {
        var dto = _mapper.Map<CadastrarVoucherDto>(model);
        return Ok(_voucherService.Cadastrar(dto));
    }

        
    /// <summary>
    /// Desativara as vouchers recebidas
    /// </summary>
    /// <returns></returns>
    [HttpPatch]
    [ProducesResponseType(typeof(Result), (int) HttpStatusCode.OK)]
    public async Task<ActionResult> Desativavouchers(DesativarVouchersViewModel model)
    {
        return Ok(await _voucherService.Desativar(model.VoucherIds));
    }
}