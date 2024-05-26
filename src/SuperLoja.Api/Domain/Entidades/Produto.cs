namespace SuperLoja.Api.Domain.Entidades;

public class Produto : EntidadeBase
{
    public string Nome { get; set; }
    public string Codigo { get; set; }
    public string Marca { get; set; }
    public int Quantidade { get; set; }
    public int QuantidadeMinima { get; set; }
    public float PesoUnitario { get; set; }
}