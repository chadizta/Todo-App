using FluentValidation;
using Todo_App.Application.Common.Interfaces;

namespace Todo_App.Application.Tags.Commands.CreateTag;

public class CreateTagCommandValidator : AbstractValidator<CreateTagCommand>
{
    private readonly IApplicationDbContext _context;    

    public CreateTagCommandValidator(IApplicationDbContext context)
    {
        _context = context;
       
        RuleFor(v => v.Title)
            .NotEmpty().WithMessage("Tag Title is required.")            
            .Must((command, title) => ValidTag(command)).WithMessage("The specified Tag Title already exists.");
    }

    public bool ValidTag(CreateTagCommand command)
    { 
        return _context.Tag.Where(x => x.TodoItemId == command.TodoItemId)
            .All(l => l.Title != command.Title);
    }
}
