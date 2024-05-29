using JobFinder.Application.Repositories.Common;
using JobFinder.Application.Repositories.JobApplication;
using JobFinder.Persistence.DbContexts;
using JobFinder.Persistence.Repositories.Common;

namespace JobFinder.Persistence.Repositories.JobApplication;

public class JobApplicationWriteRepository: WriteGenericRepository<Domain.Entities.Concretes.JobApplication>, IWriteJobApplicationRepository
{
    public JobApplicationWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}