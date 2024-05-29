using JobFinder.Domain.Entities.Common;

namespace JobFinder.Domain.Entities.Concretes;

public class Vacancy: BaseEntity
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? EmployerId { get; set; }
    public virtual ApplicationUser Employer { get; set; }
    public virtual ICollection<JobApplication> JobApplications { get; set; }
}