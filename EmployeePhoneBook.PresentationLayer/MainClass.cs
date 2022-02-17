using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeePhoneBook.Entities;
using EmployeePhoneBook.Exceptions;
using EmployeePhoneBook.BusinessLayer;

namespace EmployeePhoneBook.PresentationLayer
{
    public class MainClass
    {
        static void Main()
        {
            int choice;
            do
            {
                PrintMenu();
                Console.Write("Enter your Choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        ListAllEmployees();
                        break;
                    case 3:
                        SearchEmployeeByID();
                        break;
                    case 4:
                        UpdateEmployee();
                        break;
                    case 5:
                        DeleteEmployee();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (choice != -1);
        }

        private static void DeleteEmployee()
        {
            try
            {
                int deleteEmpID;
                Console.Write("Enter GuestID to Delete: ");
                deleteEmpID = Convert.ToInt32(Console.ReadLine());
                Employee deleteEmp = EmployeeBL.SearchEmployeeBL(deleteEmpID);
                if (deleteEmp != null)
                {
                    bool empdeleted = EmployeeBL.DeleteEmployeeBL(deleteEmpID);
                    if (empdeleted)
                        Console.WriteLine("Employee Deleted");
                    else
                        Console.WriteLine("Employee not Deleted ");
                }
                else
                {
                    Console.WriteLine("No Employee Details Available");
                }


            }
            catch (EmployeePhoneBookException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void UpdateEmployee()
        {
            try
            {
                int updateEmpID;
                Console.Write("Enter EmployeeID to Update Details: ");
                updateEmpID = Convert.ToInt32(Console.ReadLine());
                Employee updatedEmp = EmployeeBL.SearchEmployeeBL(updateEmpID);
                if (updatedEmp != null)
                {
                    Console.Write("Update Employee Name : ");
                    updatedEmp.EmployeeName = Console.ReadLine();
                    Console.Write("Update PhoneNumber : ");
                    updatedEmp.EmployeeContactNumber = Console.ReadLine();
                    bool empUpdated = EmployeeBL.UpdateEmployeeBL(updatedEmp);
                    if (empUpdated)
                        Console.WriteLine("Employee Details Updated");
                    else
                        Console.WriteLine("Employee Details not Updated ");
                }
                else
                {
                    Console.WriteLine("No Employee Details Available");
                }


            }
            catch (EmployeePhoneBookException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void SearchEmployeeByID()
        {
            try
            {
                int searchEmpID;
                Console.Write("Enter EmployeeID to Search: ");
                searchEmpID = Convert.ToInt32(Console.ReadLine());
                Employee searchEmp = EmployeeBL.SearchEmployeeBL(searchEmpID);
                if (searchEmp != null)
                {
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("EmployeeID\t\tName\t\tPhoneNumber");
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("{0}\t\t{1}\t\t{2}", searchEmp.EmployeeID, searchEmp.EmployeeName, searchEmp.EmployeeContactNumber);
                    Console.WriteLine("******************************************************************************");
                }
                else
                {
                    Console.WriteLine("No Employee Details Available");
                }

            }
            catch (EmployeePhoneBookException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ListAllEmployees()
        {
            try
            {
                List<Employee> empList = EmployeeBL.GetAllEmployeesBL();
                if (empList != null)
                {
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("EmployeeID\t\tName\t\tPhoneNumber");
                    Console.WriteLine("******************************************************************************");
                    foreach (Employee emp in empList)
                    {
                        Console.WriteLine("{0}\t\t{1}\t\t{2}", emp.EmployeeID, emp.EmployeeName, emp.EmployeeContactNumber);
                    }
                    Console.WriteLine("******************************************************************************");

                }
                else
                {
                    Console.WriteLine("No Employee Details Available");
                }
            }
            catch (EmployeePhoneBookException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AddEmployee()
        {
            try
            {
                Employee newEmp = new Employee();
                Console.Write("Enter EmployeeID : ");
                newEmp.EmployeeID = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Employee Name : ");
                newEmp.EmployeeName = Console.ReadLine();
                Console.Write("Enter PhoneNumber : ");
                newEmp.EmployeeContactNumber = Console.ReadLine();
                bool empAdded = EmployeeBL.AddEmployeeBL(newEmp);
                if (empAdded)
                    Console.WriteLine("Employee Added");
                else
                    Console.WriteLine("Employee not Added");
            }
            catch (EmployeePhoneBookException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void PrintMenu()
        {
            Console.WriteLine("\n***********Employee PhoneBook Menu***********");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. List All Employees");
            Console.WriteLine("3. Search Employee by ID");
            Console.WriteLine("4. Update Employee");
            Console.WriteLine("5. Delete Employee");
            Console.WriteLine("6. Exit");
            Console.WriteLine("******************************************\n");
        }
    }
}
