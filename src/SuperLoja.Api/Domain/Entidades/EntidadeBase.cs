using FluentValidation.Results;

namespace SuperLoja.Api.Domain.Entidades;

public abstract class EntidadeBase
{
    public Guid Id { get; set; }
    public DateTime CriadoEm { get; set; }
    public DateTime? UltimaAtualizacaoEm { get; set; }
    public abstract ValidationResult Validar();

    public EntidadeBase()
    {
        Id = Guid.NewGuid();
        CriadoEm = DateTime.Now;
    }
}
