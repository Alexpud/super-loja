namespace SuperLoja.Api.Domain.Entidades;

public abstract class EntidadeBase
{
    public Guid Id { get; set; }
    public DateTime CriadoEm { get; set; }
    public DateTime? UltimaAtualizacaoEm { get; set; }
    public virtual bool EhValida()
    {
        return true;
    }
}
