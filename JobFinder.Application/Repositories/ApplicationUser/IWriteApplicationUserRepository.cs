using JobFinder.Application.Repositories.Common;

namespace JobFinder.Application.Repositories.ApplicationUser;

public interface IWriteApplicationUserRepository: IWriteGenericRepository<Domain.Entities.Concretes.ApplicationUser>
{
    
}