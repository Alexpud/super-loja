using AutoMapper;
using SuperLoja.Api.Domain.Dtos;
using SuperLoja.Api.Domain.Entidades;

namespace SuperLoja.Api.Domain.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Produto, ProdutoDto>();
            CreateMap<Voucher, VoucherDto>();
        }
    }
}
