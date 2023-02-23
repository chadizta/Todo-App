using FluentAssertions;
using NUnit.Framework;
using Todo_App.Application.Tags.Queries.GetTags;
using Todo_App.Domain.Entities;

namespace Todo_App.Application.IntegrationTests.TodoLists.Queries;

using static Testing;

public class GetTagTests : BaseTestFixture
{   

    [Test]
    public async Task ShouldReturnAllTags()
    {
        await RunAsDefaultUserAsync();

        await AddAsync(new Tag
        {
            Title = "Tag",
            TodoItemId = 1
        });

        var query = new GetTagsQuery();

        var result = await SendAsync(query);

        result.Should().NotBeNull();        
    }

    [Test]
    public async Task ShouldAcceptAnonymousUser()
    {
        var query = new GetTagsQuery();

        var action = () => SendAsync(query);

        await action.Should().NotThrowAsync<UnauthorizedAccessException>();
    }
}
