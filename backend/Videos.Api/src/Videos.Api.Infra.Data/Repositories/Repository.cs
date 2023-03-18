using Videos.Api.Domain.SeedWork;
using Videos.Api.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Videos.Api.Infra.Data.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IAggregateRoot
{
    protected readonly ApplicationDbContext ApplicationDbContext;
    protected readonly DbSet<TEntity> DbSet;

    protected Repository(ApplicationDbContext applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
        DbSet = applicationDbContext.Set<TEntity>();
    }

    public void Add(TEntity obj)
    {
        ApplicationDbContext.Add(obj);
    }
}
