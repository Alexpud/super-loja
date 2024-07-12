using SuperLoja.Api.Domain.Entidades;

namespace SuperLoja.Api.Domain.Specs.Produtos;

public class ProdutosPorNomeSpecification : BaseSpecification<Produto>
{
    public ProdutosPorNomeSpecification(string nome)
    {
        expression = produto => produto.Nome == nome;
    }
}

public class ProdutosPorMarcaSpecification : BaseSpecification<Produto>
{
    public ProdutosPorMarcaSpecification(string marca)
    {
        expression = produto => produto.Marca == marca;
    }
}

public class ProdutosPorCodigoSpecification : BaseSpecification<Produto>
{
    public ProdutosPorCodigoSpecification(string codigo)
    {
        expression = produto => produto.Codigo == codigo;
    }
}
