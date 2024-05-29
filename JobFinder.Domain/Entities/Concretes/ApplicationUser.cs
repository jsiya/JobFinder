using Microsoft.AspNetCore.Identity;

namespace JobFinder.Domain.Entities.Concretes;

public class ApplicationUser: IdentityUser
{
    public virtual ICollection<Vacancy> Vacancies { get; set; }
    public virtual ICollection<JobApplication> JobApplications { get; set; }
}