using SuperLoja.Api.Domain.Entidades;
using SuperLoja.Api.Domain.Specs;

namespace SuperLoja.Api.Domain.Repository;

public interface IRepository<T> where T : EntidadeBase
{
    IQueryable<T> AsQueryable();
    IQueryable<T> EncontrarTodos(ISpecification<T> specification);
    void Adicionar(T entity);
    void Editar(T entity);
    void Commit();
    void Remover(Guid id);
}