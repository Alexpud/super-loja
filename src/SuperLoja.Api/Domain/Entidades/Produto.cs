using FluentValidation.Results;
using SuperLoja.Api.Domain.Validator;

namespace SuperLoja.Api.Domain.Entidades;

public class Produto : EntidadeBase
{
    public string Nome { get; }
    public string Codigo { get; }
    public string Marca { get; }
    public int Quantidade { get; }
    public float PesoUnitario { get; }

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