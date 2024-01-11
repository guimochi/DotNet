using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEmployee.Models;

namespace WpfEmployee.ViewModels
{
    class EmployeeVM
    {
        private List<EmployeeModel> _employeesList;
        private List<string> _listTitle;
        private readonly NorthwindContext _northwindContext = new();

        public List<EmployeeModel> EmployeesList { 
            get { return _employeesList ??= LoadEmployees(); }
        }

        public List<String> ListTitle
        {
            get
            {
                return _listTitle ??= LoadListTitle();
            }
        }

        private List<string> LoadListTitle()
        {
            return _employeesList.Select(e => e.TitleOfCourtesy).Distinct().ToList();
        }

        private List<EmployeeModel> LoadEmployees()
        {
            List<EmployeeModel> localCollection = new();
            foreach (var item in _northwindContext.Employees)
            {
                localCollection.Add(new EmployeeModel(item));
            }
            return localCollection;
        }
    }
        
}
