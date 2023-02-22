using FluentValidation;
using Todo_App.Application.TodoItems.Commands.UpdateTodoItemDetail;

namespace Todo_App.Application.TodoItems.Commands.UpdateTodoItem;

public class UpdateTodoItemDetailCommandValidator : AbstractValidator<UpdateTodoItemDetailCommand>
{
    public UpdateTodoItemDetailCommandValidator()
    {
        RuleFor(v => v.Colour)
            .Must(c => !string.IsNullOrWhiteSpace(Domain.ValueObjects.Colour.From(c)))
            .When((m, p) => !string.IsNullOrWhiteSpace(m.Colour));
    }
}