using AutoMapper;
using SuperLoja.Api.Domain.Dtos;
using SuperLoja.Api.Presentation.ViewModels;

namespace SuperLoja.Api.Presentation.Profiles;

public class PresentationProfile : Profile
{
    public PresentationProfile()
    {
        CreateMap<CadastrarProdutoViewModel, CadastrarProdutoDto>();
        CreateMap<CadastrarVoucherViewModel, CadastrarVoucherDto>();
    }
}