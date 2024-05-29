namespace SuperLoja.Api.Domain.Dtos;

public class CriarProdutoDto
{
    public string Nome { get; set; }

    public string Codigo { get; set; }

    public string Marca { get; set; }

    public int Quantidade { get; set; }

    public int QuantidadeMinima { get; set; }

    public float PesoUnitario { get; set; }
}
