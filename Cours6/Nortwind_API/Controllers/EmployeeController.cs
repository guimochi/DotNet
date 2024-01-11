using Microsoft.AspNetCore.Mvc;
using Nortwind_API.DTO;
using Nortwind_API.Entities;
using Nortwind_API.Repositories;
using Nortwind_API.UnitOfWorks;

namespace Nortwind_API.Controllers
{
    [ApiController]
    [Route("/api/[controller")]
    public class EmployeeController
    {
        private readonly NorthwindContext _dbcontext;
        private readonly IUnitOfWorkNorthwind _unitOfWorkNorthwind;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController()
        {
            _dbcontext = new NorthwindContext();
            _unitOfWorkNorthwind = new UnitOfWorkNorthwind(_dbcontext);
            _employeeRepository = _unitOfWorkNorthwind.EmployeeRepository;
        }

        [HttpGet]
        public async Task<IList<EmployeeDTO>> GetEmployees()
        {
            IList<Employee> employees = await _employeeRepository.GetAllAsync();
            return employees.Select(e => EmployeeToDTO(e)).ToList();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmploye(int id)
        {
            Employee? employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(EmployeeToDTO(employee));
        }

        [HttpDelete("{id}")]
        public async void DeleteEmploye(int id) {
            Employee? employee = await _employeeRepository.GetByIdAsync(id);
            if (employee != null) {
                await _employeeRepository.DeleteAsync(employee);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> createEmployee()
        private EmployeeDTO EmployeeToDTO(Employee e)
        {
            return new EmployeeDTO
            {
                EmployeeId = e.EmployeeId,
                LastName = e.LastName,
                FirstName = e.FirstName,
                HireDate = e.HireDate,
                BirthDate = e.BirthDate,
                Title = e.Title,
                TitleOfCourtesy = e.TitleOfCourtesy,
            };
        }

        private Employee DTOToEmployee(EmployeeDTO e)
        {
            return new Employee
            {
                EmployeeId = e.EmployeeId,
                LastName = e.LastName,
                FirstName = e.FirstName,
                HireDate = e.HireDate,
                BirthDate = e.BirthDate,
                Title = e.Title,
                TitleOfCourtesy = e.TitleOfCourtesy,
            }
        }
    }
}
