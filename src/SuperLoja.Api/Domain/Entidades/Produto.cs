using FluentValidation.Results;
using SuperLoja.Api.Domain.Validator;

namespace SuperLoja.Api.Domain.Entidades;

public class Produto : EntidadeBase
{
    public string Nome { get; private set; }
    public string Codigo { get; private set; }
    public string Marca { get; private set; }
    public int Quantidade { get; private set; }
    public int QuantidadeMinima { get; private set; }
    public float PesoUnitario { get; private set; }

    public Produto(
        string nome, 
        string codigo, 
        string marca, 
        int quantidade, 
        int quantidadeMinima, 
        float pesoUnitario) : base()
    {
        Nome = nome;
        Codigo = codigo;
        Marca = marca;
        Quantidade = quantidade;
        QuantidadeMinima = quantidadeMinima;
        PesoUnitario = pesoUnitario;
    }

    public override ValidationResult Validar() 
        => new ProdutoValidator().Validate(this);
}