using FluentValidation.Results;

namespace SuperLoja.Api.Domain.Entidades;

public abstract class EntidadeBase
{
    public Guid Id { get; private set; }
    public DateTime CriadoEm { get; private set; }
    public DateTime? UltimaAtualizacaoEm { get; private set; }
    public abstract ValidationResult Validar();

    protected EntidadeBase()
    {
        Id = Guid.NewGuid();
        CriadoEm = DateTime.Now;
    }
}
