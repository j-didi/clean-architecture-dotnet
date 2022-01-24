using FluentValidation;

namespace CleanArchDotnet.Core.Todos.UseCases.Writes.CreateTodo;

public class CreateTodoValidator : AbstractValidator<CreateTodoCommand>
{
    public CreateTodoValidator()
    {
        RuleFor(e => e.Description)
            .MinimumLength(5)
            .MaximumLength(255);
    }
}