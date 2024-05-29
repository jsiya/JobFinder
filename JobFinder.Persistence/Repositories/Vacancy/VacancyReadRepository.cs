using JobFinder.Application.Repositories.Vacancy;
using JobFinder.Persistence.DbContexts;
using JobFinder.Persistence.Repositories.Common;

namespace JobFinder.Persistence.Repositories.Vacancy;

public class VacancyReadRepository: ReadGenericRepository<Domain.Entities.Concretes.Vacancy>, IReadVacanyRepository
{
    public VacancyReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}