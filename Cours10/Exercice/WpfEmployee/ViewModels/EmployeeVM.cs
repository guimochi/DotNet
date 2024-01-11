using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfEmployee.Models;

namespace WpfEmployee.ViewModels
{
    class EmployeeVM
    {
        private readonly NorthwindContext _northwindContext = new();
        private EmployeeModel _selectedEmployee;
        private ObservableCollection<EmployeeModel> _employeesList;
        private ObservableCollection<string> _listTitle;
        private DelegateCommand _addEmployee;
        private DelegateCommand _saveEmployee;

        public EmployeeModel SelectedEmployee
        { 
            get
            {
                return _selectedEmployee;
            }
            set
            { 
                _selectedEmployee = value;
            }
        }

        public ObservableCollection<EmployeeModel> EmployeesList
        {
            get { return _employeesList ??= LoadEmployees(); }
        }

        public ObservableCollection<String> ListTitle
        {
            get
            {
                return _listTitle ??= LoadListTitle();
            }
        }

        private ObservableCollection<string> LoadListTitle()
        {
            return new ObservableCollection<string>(_northwindContext.Employees.Select(e => e.TitleOfCourtesy).Distinct().ToList());
        }

        private ObservableCollection<EmployeeModel> LoadEmployees()
        {
            ObservableCollection<EmployeeModel> localCollection = new();
            foreach (var item in _northwindContext.Employees)
            {
                localCollection.Add(new EmployeeModel(item));
            }
            return localCollection;
        }

        public DelegateCommand AddCommand
        {
            get
            {
                return _addEmployee ??= new DelegateCommand(AddEmployee);
            }
        }

        public DelegateCommand SaveCommand
        {
            get
            {
                return _saveEmployee ??= new DelegateCommand(SaveEmployee);
            }
        }

        private void SaveEmployee()
        {
            Employee? employee = _northwindContext.Employees
                .FirstOrDefault(e => e.EmployeeId == SelectedEmployee.Employee.EmployeeId);
            if (employee == null)
            {
                _northwindContext.Add(SelectedEmployee.Employee);
            } 

            _northwindContext.SaveChanges();
            MessageBox.Show("Enregistrement en base de données fait");
        }

        private void AddEmployee()
        {

            Employee eGlobal = new Employee();
            EmployeeModel eModel = new(eGlobal);
            EmployeesList.Add(eModel);
            SelectedEmployee = eModel;
        }

        private EmployeeModel CreateEmployeModelFromSelectedEmployee()
        {
            Employee employee = new Employee
            {
                FirstName = _selectedEmployee.FirstName,
                LastName = _selectedEmployee.LastName,
                BirthDate = _selectedEmployee.BirthDate,
                HireDate = _selectedEmployee.HireDate,
                TitleOfCourtesy = _selectedEmployee.TitleOfCourtesy,
            };
            return new EmployeeModel(employee);
        }
    }
}
