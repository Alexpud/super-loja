using SuperLoja.Api.Domain.Entidades;
using SuperLoja.Api.Tests.Builders.Domain;

namespace SuperLoja.Api.Tests.Builders;
public class PromocaoBuilder : BaseBuilder<Promocao, PromocaoBuilder>
{
    private bool _ativa;
    private DateTime _dataExpiracao;
    private float _taxa;
    
    public override PromocaoBuilder ComPropriedadesPreenchidas()
    {
        throw new NotImplementedException();
    }

    public PromocaoBuilder EhAtiva(bool ehAtivada)
    {
        _ativa = ehAtivada;
        return this;
    }

    public PromocaoBuilder ComDataExpiracao(DateTime dateTime)
    {
        _dataExpiracao = dateTime;
        return this;
    }

    public override Promocao Build()
    {
        return new Promocao(
            ativa: _ativa,
            dataExpiracao: _dataExpiracao,
            taxa: _taxa
        );
    }
}