namespace SuperLoja.Api.Domain.Dtos;

public class ProdutoDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Codigo { get; set; }
    public string Marca { get; set; }
    public int Quantidade { get; set; }
    public float PesoUnitario { get; set; }
}