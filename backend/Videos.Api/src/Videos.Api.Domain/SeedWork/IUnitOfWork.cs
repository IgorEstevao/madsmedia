using System.Threading.Tasks;

namespace Videos.Api.Domain.SeedWork;

public interface IUnitOfWork
{
	Task<bool> CommitAsync();
}
