namespace CleanArchDotnet.Core.Todos;

public class Todo
{
    public Guid Id { get; }
    public string Description { get; }
    public TodoStatus Status { get; private set; }

    public Todo(string description)
    {
        Id = Guid.NewGuid();
        Description = description;
        Status = TodoStatus.Created;
    }

    public void MarkTodoAsDone()
    {
        Status = TodoStatus.Done;
    }
    
    public void MarkTodoAsRemoved()
    {
        Status = TodoStatus.Removed;
    }
}