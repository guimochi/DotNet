using Nortwind_API.Entities;

namespace Nortwind_API.Repositories
{
    public class EmployeeRepository : BaseRepositorySQL<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(NorthwindContext dbContext) : base(dbContext)
        {
        }
    }
}
