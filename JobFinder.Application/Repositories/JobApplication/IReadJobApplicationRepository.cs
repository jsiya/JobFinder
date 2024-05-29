using JobFinder.Application.Repositories.Common;

namespace JobFinder.Application.Repositories.JobApplication;

public interface IReadJobApplicationRepository: IReadGenericRepository<Domain.Entities.Concretes.JobApplication>
{
    
}