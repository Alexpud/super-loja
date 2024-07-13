using SuperLoja.Api.Domain.Entidades;
using SuperLoja.Api.Domain.Specs;

namespace SuperLoja.Api.Domain.Repository;

public interface IRepository<T> where T : EntidadeBase
{
    IQueryable<T> AsQueryable();
    IQueryable<T> EncontrarTodos(BaseSpecification<T> specification);
    Task<T> ObterPorId(Guid id);
    void Adicionar(T entity);
    void Editar(T entity);
    Task Commit();
    void Remover(T entity);
}