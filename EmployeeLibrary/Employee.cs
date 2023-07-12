using System;

namespace EmployeeLibrary
{
    public abstract class Employee
    {
        /*
	        +FirstName 		- string
	        +LastName 		- string
	        +EmpNum	  		- int
	        +virtual string displayText() method
         */

        //  Full-Arg constructor
        /// <summary>
        ///     Abstract Employee class representing the
        ///     information all employees have in common,
        ///     i.e. a first name, a last name, and an
        ///     employee number
        /// </summary>
        /// <param name="firstName">Employee first name</param>
        /// <param name="lastName">Employee last name</param>
        /// <param name="empNum">Employee number (1000 - 9999)</param>
        public Employee(string firstName, string lastName, int empNum)
        {
            FirstName   = firstName;
            LastName    = lastName;
            EmpNum      = empNum;
        }

        //  Getters/Setters
        /// <summary>
        /// </summary>
        /// <returns>
        ///     Returns a string representing employee first name
        /// </returns>
        string FirstName { get; set; }

        /// <summary>
        /// </summary>
        /// <returns>
        ///     Returns a string representing employee last name
        /// </returns>
        string LastName { get; set; }

        /// <summary>
        /// </summary>
        /// <returns>
        ///     Returns a string representing employee number
        /// </returns>
        int EmpNum { get; set; }

        //  displayText() method
        /// <summary>
        /// </summary>
        /// <returns>
        ///     Returns a string with first name, last name,
        ///     and employee number.
        /// </returns>
        public virtual string displayText()
        {
            return "Name: " + FirstName + " " + LastName +
                   "\r\nEmployee Number: " + EmpNum;
        }
    }
}
