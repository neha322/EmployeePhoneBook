using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeePhoneBook.Entities;
using EmployeePhoneBook.Exceptions;
using EmployeePhoneBook.DataAccessLayer;

namespace EmployeePhoneBook.BusinessLayer
{
    public class EmployeeBL
    {
        private static bool ValidateEmployee(Employee emp)
        {
            StringBuilder sb = new StringBuilder();
            bool validEmployee = true;
            if (emp.EmployeeID <= 0)
            {
                validEmployee = false;
                sb.AppendLine("\nInvalid Employee ID");

            }
            if (emp.EmployeeName == string.Empty)
            {
                validEmployee = false;
                sb.AppendLine("Employee Name Empty..Enter Valid Employee Name");

            }
            if (emp.EmployeeContactNumber.Length < 10)
            {
                validEmployee = false;
                sb.AppendLine("Required 10 Digit Contact Number");
            }
            if (validEmployee == false)
                throw new EmployeePhoneBookException(sb.ToString());
            return validEmployee;
        }
        public static bool AddEmployeeBL(Employee newEmp)
        {
            bool empAdded = false;
            try
            {
                if (ValidateEmployee(newEmp))
                {
                    EmployeeDAL empDAL = new EmployeeDAL();
                    empAdded = empDAL.AddEmployeeDAL(newEmp);
                }
            }
            catch (EmployeePhoneBookException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return empAdded;
        }
        public static List<Employee> GetAllEmployeesBL()
        {
            List<Employee> empList = null;
            try
            {
                EmployeeDAL guestDAL = new EmployeeDAL();
                empList = guestDAL.GetAllEmployeesDAL();
            }
            catch (EmployeePhoneBookException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return empList;
        }

        public static Employee SearchEmployeeBL(int searchEmpID)
        {
            Employee searchEmp= null;
            try
            {
                EmployeeDAL empDAL = new EmployeeDAL();
                searchEmp = empDAL.SearchEmployeeDAL(searchEmpID);
            }
            catch (EmployeePhoneBookException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchEmp;

        }

        public static bool UpdateEmployeeBL(Employee updateEmp)
        {
            bool empUpdated = false;
            try
            {
                if (ValidateEmployee(updateEmp))
                {
                    EmployeeDAL empDAL = new EmployeeDAL();
                    empUpdated = empDAL.UpdateEmployeeDAL(updateEmp);
                }
            }
            catch (EmployeePhoneBookException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return empUpdated;
        }

        public static bool DeleteEmployeeBL(int deleteEmployeeID)
        {
            bool empDeleted = false;
            try
            {
                if (deleteEmployeeID > 0)
                {
                    EmployeeDAL empDAL = new EmployeeDAL();
                    empDeleted = empDAL.DeleteEmployeeDAL(deleteEmployeeID);
                }
                else
                {
                    throw new EmployeePhoneBookException("Invalid Employee ID");
                }
            }
            catch (EmployeePhoneBookException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return empDeleted;
        }
    }
}
