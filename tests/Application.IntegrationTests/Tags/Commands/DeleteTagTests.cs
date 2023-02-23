using FluentAssertions;
using NUnit.Framework;
using Todo_App.Application.Common.Exceptions;
using Todo_App.Application.Tags.Commands.CreateTag;
using Todo_App.Application.Tags.Commands.DeleteTag;
using Todo_App.Domain.Entities;

namespace Todo_App.Application.IntegrationTests.TodoLists.Commands;

using static Testing;

public class DeleteTagTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTag()
    {
        var command = new DeleteTagCommand(99);
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteTodoList()
    {
        var tagId = await SendAsync(new CreateTagCommand
        {
            TodoItemId = 1,
            Title = "New List"
        });

        await SendAsync(new DeleteTagCommand(tagId));

        var list = await FindAsync<Tag>(tagId);

        list.Should().BeNull();
    }
}
