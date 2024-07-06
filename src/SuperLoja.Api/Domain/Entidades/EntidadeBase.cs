using FluentValidation.Results;

namespace SuperLoja.Api.Domain.Entidades;

public abstract class EntidadeBase
{
    public Guid Id { get; }
    public DateTime CriadoEm { get; }
    public DateTime? UltimaAtualizacaoEm { get; protected set; }
    public abstract ValidationResult Validar();

    protected EntidadeBase()
    {
        Id = Guid.NewGuid();
        CriadoEm = DateTime.Now;
    }
}
