namespace Videos.Api.Dtos;

public class ContentFilterDto
{
    public int[] CategoryIds { get; }
    public int[] StudioIds { get; }

    public ContentFilterDto(int[] categoryIds, int[] studioIds)
    {
        CategoryIds = categoryIds;
        StudioIds = studioIds;
    }
}
