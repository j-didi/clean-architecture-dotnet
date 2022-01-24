using CleanArchDotnet.Core.Todos;

namespace CleanArchDotnet.Core.Ports;

public interface ITodos
{
    Task<Todo?> GetById(Guid id);
    Task<IReadOnlyCollection<Todo>> Get();
    Task Create(Todo todo);
    Task Update(Todo todo);
}