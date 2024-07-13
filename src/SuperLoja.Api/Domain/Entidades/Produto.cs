using FluentValidation.Results;

namespace SuperLoja.Api.Domain.Entidades;

public class Produto : EntidadeBase
{
    public string Nome { get; private set; }
    public string Codigo { get; private set; }
    public string Marca { get; private set; }
    public int Quantidade { get; private set; }
    public float PesoUnitario { get; private set; }
    
    private Produto() { }

    public Produto(
        string nome, 
        string codigo, 
        string marca, 
        int quantidade, 
        float pesoUnitario)
    {
        Nome = nome;
        Codigo = codigo;
        Marca = marca;
        Quantidade = quantidade;
        PesoUnitario = pesoUnitario;
    }

    public override ValidationResult Validar() 
        => new ProdutoValidator().Validate(this);
}