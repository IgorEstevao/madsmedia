using System;

namespace Videos.Api.Application.Dtos.Response;

public class ContentResponse
{
    public Guid Id { get; }
    public string Title { get; }
    public string Description { get; }
    public double Rate { get; }
    public int Favorites { get; }
    public DateTime ReleaseDate { get; }
    public string[] AlternateTitles { get; }
    public object[] Studios { get; }
    public object[] Categories { get; }

    public ContentResponse(Guid id, string title, string description, double rate, int favorites, DateTime releaseDate, string[] alternateTitles, object[] studios, object[] categories)
    {
        Id = id;
        Title = title;
        Description = description;
        Rate = rate;
        Favorites = favorites;
        ReleaseDate = releaseDate;
        AlternateTitles = alternateTitles;
        Studios = studios;
        Categories = categories;
    }
}
