using System;
using Videos.Api.Domain.SeedWork;
using System.Collections.Generic;
using Videos.Api.Domain.Aggregates.MediaAggregate;
using Videos.Api.Domain.Aggregates.TagAggregate;
using Videos.Api.Domain.Aggregates.StudioAggregate;
using Videos.Api.Domain.Exceptions;

namespace Videos.Api.Domain.Aggregates.ContentAggregate;

public class Content : Entity, IAggregateRoot
{
    public string Title { get; }
    public string Description { get; }
    public int Favorites { get; private set; }
    public DateTime ReleaseDate { get; }
    public ContentRate Rate { get; }
    public string[] AlternateTitles { get; }
    public IReadOnlyCollection<Category> Categories => _categories;
    public IReadOnlyCollection<Media> Medias => _medias;
    public IReadOnlyCollection<Studio> Studios => _studios;
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; private set; }

    private readonly List<Category> _categories;
    private readonly List<Media> _medias;
    private readonly List<Studio> _studios;

    public Content(string title, string[] alternateTitles, string description, DateTime releaseDate, int favoritesCounter, ContentRate rate)
    {
        if (favoritesCounter < 0) throw new DomainException($"{nameof(Favorites)} can't be negative");
        if (title.Length > 200) throw new DomainException($"{nameof(Title)} length must be less than 200 words");
        if (description.Length > 2000) throw new DomainException($"{nameof(Description)} length must be less than 2000 words");

        SetId();
        Title = title;
        Description = description;
        Favorites = favoritesCounter;
        ReleaseDate = releaseDate;
        Rate = rate;
        AlternateTitles = alternateTitles;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;

        _categories = new List<Category>();
        _medias = new List<Media>();
        _studios = new List<Studio>();
    }

    protected Content()
    {
    }

    public void AddCategories(params Category[] tags)
    {
        _categories.AddRange(tags);
        UpdatedAt = DateTime.UtcNow;
    }

    public void AddMedia(params Media[] medias)
    {
        _medias.AddRange(medias);
        UpdatedAt = DateTime.UtcNow;
    }

    public void AddStudios(params Studio[] studios)
    {
        _studios.AddRange(studios);
        UpdatedAt = DateTime.UtcNow;
    }

    public void IncrementFavorites()
    {
        Favorites++;
        UpdatedAt = DateTime.UtcNow;
    }
}
