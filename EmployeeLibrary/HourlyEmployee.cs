using System;

namespace EmployeeLibrary
{
    public class HourlyEmployee : Employee
    {
        /*
            +HoursWorked 		- decimal
	        +HourlyRate  		- decimal
	        +override string displayText() method
         */

        //  Full-Arg Constructor
        /// <summary>
        ///     Full-Arg Constructor for HourlyEmployee class.
        ///     This will allow us to instantiate an hourly
        ///     employee, with a first name, a last name, an
        ///     employee number, an hours worked, and an
        ///     hourly rate.
        /// </summary>
        /// <param name="firstName">Employee First Name</param>
        /// <param name="lastName">Employee Last Name</param>
        /// <param name="empNumber">Employee Number (1000 - 9999)</param>
        /// <param name="hoursWorked">Hours Worked (0.00 - 84.00)</param>
        /// <param name="hourlyRate">Hourly Rate (0.00 - 99.99)</param>
        public HourlyEmployee(string firstName,
                              string lastName,
                              int    empNumber,
                              decimal hoursWorked,
                              decimal hourlyRate)
                    : base(firstName, lastName, empNumber)
        {
            HoursWorked = hoursWorked;
            HourlyRate = hourlyRate;
        }

        //  Getters/Setters
        /// <summary>
        /// </summary>
        /// <returns>
        ///     Returns a decimal representing hours worked
        /// </returns>
        decimal HoursWorked { get; set; }

        /// <summary>
        /// </summary>
        /// <returns>
        ///     Returns a decimal representing hourly rate
        /// </returns>
        decimal HourlyRate { get; set; }

        //  displayText() method
        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        ///     Returns a string with all hourly employee info
        /// </returns>
        public override string displayText()
        {
            return base.displayText() +
                   "\r\nHours Worked: " + HoursWorked.ToString("n2") +
                   "\r\nHourly  Rate: " + HourlyRate.ToString("c");
        }
    }
}
