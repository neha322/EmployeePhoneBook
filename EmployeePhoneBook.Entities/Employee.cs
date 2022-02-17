using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePhoneBook.Entities
{
    public class Employee
    {
        private int employeeID;
        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }
        private string employeeName;

        public string EmployeeName
        {
            get { return employeeName; }
            set { employeeName = value; }
        }
        private string employeeContactNumber;

        public string EmployeeContactNumber
        {
            get { return employeeContactNumber; }
            set { employeeContactNumber = value; }
        }

        public Employee()
        {
            employeeID = 0;
            employeeName = string.Empty;
            employeeContactNumber = string.Empty;
        }
    }
}
