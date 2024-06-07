namespace SuperLoja.Api.Domain.Dtos;

public class CadastrarProdutoDto
{
    public string Nome { get; set; }
    public string Codigo { get; set; }
    public string Marca { get; set; }
    public int Quantidade { get; set; }
    public float PesoUnitario { get; set; }
}
