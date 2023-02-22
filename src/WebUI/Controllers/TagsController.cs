﻿using Microsoft.AspNetCore.Mvc;
using Todo_App.Application.Tags.Queries.GetTodos;

namespace Todo_App.WebUI.Controllers;

public class TagsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<TagDto>>> Get()
    {
        return await Mediator.Send(new GetTagsQuery());
    }

    //[HttpPost]
    //public async Task<ActionResult<int>> Create(CreateTodoListCommand command)
    //{
    //    return await Mediator.Send(command);
    //}

    //[HttpDelete("{id}")]
    //public async Task<ActionResult> Delete(int id)
    //{
    //    await Mediator.Send(new DeleteTodoListCommand(id));

    //    return NoContent();
    //}
}
