using CleanArchDotnet.Core.Ports;
using CleanArchDotnet.Core.Todos;
using CleanArchDotnet.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchDotnet.Infra.Database.Todos;

public class TodoRepository: ITodos
{
    private readonly DatabaseContext _context;
    private readonly DbSet<Todo> _todos;

    public TodoRepository(
        DatabaseContext context    
    )
    {
        _context = context;
        _todos = context.Set<Todo>();
    }

    public async Task<Todo?> GetById(Guid id) =>
        await _todos.FirstOrDefaultAsync(e => 
            e.Status != TodoStatus.Removed && 
            e.Id == id
        );

    public async Task<IReadOnlyCollection<Todo>> Get() =>
        await _todos.ToListAsync();

    public async Task Create(Todo todo)
    {
        await _todos.AddAsync(todo);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Todo todo)
    {
        _context.Entry(todo).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}