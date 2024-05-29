using JobFinder.Domain.Entities.Common;

namespace JobFinder.Domain.Entities.Concretes;

public class JobApplication: BaseEntity
{
    public string EmployeeId { get; set; }
    public virtual ApplicationUser Employee { get; set; }
    public int VacancyId { get; set; }
    public virtual Vacancy Vacancy { get; set; }
}