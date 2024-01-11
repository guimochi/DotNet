using Nortwind_API.Entities;
using Nortwind_API.Repositories;

namespace Nortwind_API.UnitOfWorks
{
    public interface IUnitOfWorkNorthwind
    {
        public IEmployeeRepository EmployeeRepository { get; }
        public IRepository<Order> OrderRepository { get; }
    }
}
