using System.Collections.Generic;
using Videos.Api.Application.Dtos.Response;

namespace Videos.Api.Application.Queries;

public class GetAllContentsQuery : Query<IEnumerable<ContentResponse>>
{
    public int[] CategoryIds { get; }
    public int[] StudioIds { get; }

    public GetAllContentsQuery(int[] categoryIds, int[] studioIds)
    {
        CategoryIds = categoryIds;
        StudioIds = studioIds;
    }

    public override bool IsValid()
    {
        return true;
    }
}
