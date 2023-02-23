using FluentAssertions;
using NUnit.Framework;
using Todo_App.Application.Common.Exceptions;
using Todo_App.Application.Tags.Commands.CreateTag;
using Todo_App.Application.TodoItems.Commands.CreateTodoItem;
using Todo_App.Application.TodoLists.Commands.CreateTodoList;
using Todo_App.Domain.Entities;

namespace Todo_App.Application.IntegrationTests.TodoItems.Commands;

using static Testing;

public class CreateTagTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateTagCommand();

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldCreateTag()
    {
        var userId = await RunAsDefaultUserAsync();

        var listId = await SendAsync(new CreateTodoListCommand
        {
            Title = "New List"
        });

        var createTodoItemCommand = new CreateTodoItemCommand
        {
            ListId = listId,
            Title = "Tasks"
        };

        var itemId = await SendAsync(createTodoItemCommand);

        var item = await FindAsync<TodoItem>(itemId);

        var createTagCommand = new CreateTagCommand
        {
            TodoItemId = itemId,
            Title = "Tag"
        };

        var tagId = await SendAsync(createTagCommand);

        var tag = await FindAsync<Tag>(tagId);

        item.Should().NotBeNull();
        item!.ListId.Should().Be(createTodoItemCommand.ListId);
        item.Title.Should().Be(createTodoItemCommand.Title);
        item.CreatedBy.Should().Be(userId);
        item.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
        item.LastModifiedBy.Should().Be(userId);
        item.LastModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
        tag.Should().NotBeNull();
        tag.Title.Should().Be(createTagCommand.Title);
        tag.CreatedBy.Should().Be(userId);
        tag.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
        tag.LastModifiedBy.Should().Be(userId);
        tag.LastModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    }
}
