using System;
using System.Collections.Generic;
using EmployeePhoneBook.Entities;
using EmployeePhoneBook.Exceptions;

namespace EmployeePhoneBook.DataAccessLayer
{
    public class EmployeeDAL
    {
        public static List<Employee> empList = new List<Employee>();

        public bool AddEmployeeDAL(Employee newEmp)
        {
            bool empAdded = false;
            try
            {
                empList.Add(newEmp);
                empAdded = true;
            }
            catch (SystemException ex)
            {
                throw new EmployeePhoneBookException(ex.Message);
            }
            return empAdded;
        }

        public List<Employee> GetAllEmployeesDAL()
        {
            return empList;
        }

        public Employee SearchEmployeeDAL(int searchEmployeeID)
        {
            Employee searchEmp = null;
            try
            {
                searchEmp = empList.Find(emp => emp.EmployeeID == searchEmployeeID);
            }
            catch (SystemException ex)
            {
                throw new EmployeePhoneBookException(ex.Message);
            }
            return searchEmp;
        }

        public bool UpdateEmployeeDAL(Employee updateEmp)
        {
            bool empUpdated = false;
            try
            {
                for (int i = 0; i < empList.Count; i++)
                {
                    if (empList[i].EmployeeID == updateEmp.EmployeeID)
                    {
                        empList[i].EmployeeName = updateEmp.EmployeeName;
                        empList[i].EmployeeContactNumber = updateEmp.EmployeeContactNumber;
                        empUpdated = true;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new EmployeePhoneBookException(ex.Message);
            }
            return empUpdated;
        }

        public bool DeleteEmployeeDAL(int deleteEmpID)
        {
            bool empDeleted = false;
            try
            {
                Employee deleteEmp = empList.Find(emp => emp.EmployeeID == deleteEmpID);

                if (deleteEmp != null)
                {
                    empList.Remove(deleteEmp);
                    empDeleted = true;
                }
            }
            catch (SystemException ex)
            {
                throw new EmployeePhoneBookException(ex.Message);
            }
            return empDeleted;
        }
    }
}
