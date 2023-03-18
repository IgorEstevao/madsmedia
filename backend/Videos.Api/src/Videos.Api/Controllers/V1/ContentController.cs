using System;
using System.Collections.Generic;
using Videos.Api.Domain.Exceptions;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Videos.Api.Application.Dtos.Response;
using Videos.Api.Application.Queries;
using Videos.Api.Dtos;

namespace Videos.Api.Controllers.V1;

[ApiVersion("1")]
[ApiController]
public class ContentController : BaseController
{
    private readonly IMediator _bus;

    public ContentController(INotificationHandler<ExceptionNotification> notifications, IMediator bus) : base(notifications)
    {
        _bus = bus;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ContentResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromQuery] ContentFilterDto filters)
    {
        var query = new GetAllContentsQuery(filters.CategoryIds, filters.StudioIds);
        var result = await _bus.Send(query);
        return CreateResponse(Ok(new Response<IEnumerable<ContentResponse>>(result)));
    }

    [HttpGet("{searchTerm}")]
    [ProducesResponseType(typeof(IEnumerable<ContentResponse>), StatusCodes.Status200OK)]
    public Task<IActionResult> GetBySearchTerm([FromRoute] string searchTerm, [FromQuery] int limitSize, [FromQuery] ContentFilterDto filters)
    {
        return Task.FromResult(CreateResponse(Ok()));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ContentResponse), StatusCodes.Status200OK)]
    public Task<IActionResult> GetById([FromRoute] Guid id)
    {
        return Task.FromResult(CreateResponse(Ok()));
    }

    [HttpGet("trending")]
    [ProducesResponseType(typeof(IEnumerable<ContentResponse>), StatusCodes.Status200OK)]
    public Task<IActionResult> GetTrending([FromQuery] ContentFilterDto filters)
    {
        return Task.FromResult(CreateResponse(Ok()));
    }

    [HttpPost]
    [ProducesResponseType(typeof(IEnumerable<ContentResponse>), StatusCodes.Status201Created)]
    public Task<IActionResult> Create()
    {
        return Task.FromResult(CreateResponse(Created(Request.Path.ToUriComponent(), null)));
    }

    [HttpGet("recently-added")]
    [ProducesResponseType(typeof(IEnumerable<ContentResponse>), StatusCodes.Status200OK)]
    public Task<IActionResult> GetRecentlyAdded([FromQuery] ContentFilterDto filters)
    {
        return Task.FromResult(CreateResponse(Ok()));
    }

    [HttpGet("bookmarked")]
    [ProducesResponseType(typeof(IEnumerable<ContentResponse>), StatusCodes.Status200OK)]
    public Task<IActionResult> GetBookmarked([FromQuery] ContentFilterDto filters)
    {
        return Task.FromResult(CreateResponse(Ok()));
    }

    [HttpPut("{id:guid}/bookmark")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public Task<IActionResult> Bookmark([FromRoute] Guid id)
    {
        return Task.FromResult(CreateResponse(Ok()));
    }

    [HttpDelete("{id:guid}/bookmark")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public Task<IActionResult> DeleteBookmark([FromRoute] Guid id)
    {
        return Task.FromResult(CreateResponse(NoContent()));
    }

    [HttpGet("categories")]
    [ProducesResponseType(typeof(IEnumerable<CategoryResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCategories()
    {
        var query = new GetCategoriesQuery();
        var result = await _bus.Send(query);
        return CreateResponse(Ok(new Response<IEnumerable<CategoryResponse>>(result)));
    }
}
