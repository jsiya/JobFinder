using JobFinder.Application.Repositories.Common;

namespace JobFinder.Application.Repositories.ApplicationUser;

public interface IReadApplicationUserRepository: IReadGenericRepository<Domain.Entities.Concretes.ApplicationUser>
{
    
}