using JobFinder.Application.Repositories.ApplicationUser;
using JobFinder.Persistence.DbContexts;
using JobFinder.Persistence.Repositories.Common;

namespace JobFinder.Persistence.Repositories.ApplicationUser;

public class ApplicationUserReadRepository: ReadGenericRepository<Domain.Entities.Concretes.ApplicationUser>, IReadApplicationUserRepository
{
    public ApplicationUserReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}