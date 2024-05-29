using JobFinder.Application.Repositories.Vacancy;
using JobFinder.Persistence.DbContexts;
using JobFinder.Persistence.Repositories.Common;

namespace JobFinder.Persistence.Repositories.Vacancy;

public class VacancyWriteARepository: WriteGenericRepository<Domain.Entities.Concretes.Vacancy>, IWriteVacanyRepository
{
    public VacancyWriteARepository(ApplicationDbContext context) : base(context)
    {
    }
}