using System;
using System.Collections.Generic;
using Videos.Api.Domain.Exceptions;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Videos.Api.Controllers.V1;

[ApiVersion("1")]
[ApiController]
public class MediaController : BaseController
{
    public MediaController(INotificationHandler<ExceptionNotification> notifications) : base(notifications)
    {
    }

    [HttpPut("{contentId:guid}")]
    [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status202Accepted)]
    public Task<IActionResult> Upload([FromRoute] Guid contentId, IFormFileCollection files)
    {
        return Task.FromResult(CreateResponse(Accepted()));
    }

    [HttpDelete("{contentId:guid}/{mediaId:guid}")]
    [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status204NoContent)]
    public Task<IActionResult> Delete([FromRoute] Guid contentId, [FromRoute] Guid mediaId)
    {
        return Task.FromResult(CreateResponse(NoContent()));
    }

    [HttpGet("recently-added")]
    [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
    public Task<IActionResult> GetRecentlyAdded()
    {
        return Task.FromResult(CreateResponse(Ok()));
    }
}
