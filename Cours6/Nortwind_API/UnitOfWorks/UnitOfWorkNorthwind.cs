using Nortwind_API.Entities;
using Nortwind_API.Repositories;

namespace Nortwind_API.UnitOfWorks
{
    public class UnitOfWorkNorthwind : IUnitOfWorkNorthwind
    {
        private readonly NorthwindContext _context;
        private IEmployeeRepository _employeeRepository;
        private IRepository<Order> _orderRepository;

        public UnitOfWorkNorthwind(NorthwindContext context)
        {
            this._context = context;
            this._employeeRepository = new EmployeeRepository(context);
            this._orderRepository = new BaseRepositorySQL<Order>(context);
        }

        public IEmployeeRepository EmployeeRepository { get { return _employeeRepository; } }
        public IRepository<Order> OrderRepository { get { return _orderRepository; } }

    }
}
