using JobFinder.Application.Repositories.Common;

namespace JobFinder.Application.Repositories.JobApplication;

public interface IWriteJobApplicationRepository: IWriteGenericRepository<Domain.Entities.Concretes.JobApplication>
{
    
}