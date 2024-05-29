using JobFinder.Application.Repositories.ApplicationUser;
using JobFinder.Persistence.DbContexts;
using JobFinder.Persistence.Repositories.Common;

namespace JobFinder.Persistence.Repositories.ApplicationUser;

public class ApplicationUserWriteRepository: WriteGenericRepository<Domain.Entities.Concretes.ApplicationUser>, IWriteApplicationUserRepository
{
    public ApplicationUserWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}