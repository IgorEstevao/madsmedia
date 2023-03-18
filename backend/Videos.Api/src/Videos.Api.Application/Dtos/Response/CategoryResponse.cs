using System;

namespace Videos.Api.Application.Dtos.Response;

public class CategoryResponse
{
    public Guid Id { get; }
    public string Name { get; }

    public CategoryResponse(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}
