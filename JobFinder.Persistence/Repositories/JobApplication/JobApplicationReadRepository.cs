using JobFinder.Application.Repositories.JobApplication;
using JobFinder.Persistence.DbContexts;
using JobFinder.Persistence.Repositories.Common;

namespace JobFinder.Persistence.Repositories.JobApplication;

public class JobApplicationReadRepository: ReadGenericRepository<Domain.Entities.Concretes.JobApplication>, IReadJobApplicationRepository
{
    public JobApplicationReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}