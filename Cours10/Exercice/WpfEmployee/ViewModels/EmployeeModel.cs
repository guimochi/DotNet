using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEmployee.Models;

namespace WpfEmployee.ViewModels
{
    class EmployeeModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private readonly Employee _employee;

        public Employee Employee
        { 
            get { return _employee; }
        }

        public EmployeeModel(Employee employee)
        {
            _employee = employee;            
        }

        public string FirstName
        {
            get { return _employee.FirstName; }
            set { _employee.FirstName = value; OnPropertyChanged("FullName"); }
        }

        public string LastName
        {
            get { return _employee.LastName; }
            set { _employee.LastName = value; OnPropertyChanged("FullName"); }
        }

        public string FullName
        {
            get { return _employee.FirstName + " " + _employee.LastName; }
        }

        public string TitleOfCourtesy
        {
            get
            {
                return _employee.TitleOfCourtesy;
            }
            set { _employee.TitleOfCourtesy = value; }
        }

        public string DisplayBirthDate
        {
            get
            {
                return _employee.BirthDate.HasValue ? _employee.BirthDate.Value.ToShortDateString() : string.Empty;
            }
        }

        public DateTime? BirthDate
        {
            get { return _employee.BirthDate; }
            set
            {
                _employee.BirthDate = value;
            }
        }
        public DateTime? HireDate
        {
            get { return _employee.HireDate; }
            set
            {
                _employee.HireDate = value;

            }
        }
    }
}
