using AutoMapper;
using SuperLoja.Api.Domain.Dtos;
using SuperLoja.Api.Domain.Entidades;

namespace SuperLoja.Api.Domain.Profiles
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Produto, ProdutoDto>();
            CreateMap<Voucher, VoucherDto>();
        }
    }
}
