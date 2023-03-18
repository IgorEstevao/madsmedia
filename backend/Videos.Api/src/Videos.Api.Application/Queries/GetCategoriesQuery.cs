using System.Collections.Generic;
using Videos.Api.Application.Dtos.Response;

namespace Videos.Api.Application.Queries;

public class GetCategoriesQuery : Query<IEnumerable<CategoryResponse>>
{
    public override bool IsValid()
    {
        return true;
    }
}
