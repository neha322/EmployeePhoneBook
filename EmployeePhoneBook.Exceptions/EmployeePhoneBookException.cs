using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePhoneBook.Exceptions
{
    public class EmployeePhoneBookException : ApplicationException
    {
        public EmployeePhoneBookException() : base()
        {
        }

        public EmployeePhoneBookException(string message) : base(message)
        {
        }
        public EmployeePhoneBookException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
