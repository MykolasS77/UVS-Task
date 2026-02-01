using Services;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DatabaseSchema.DTOs
{
    public class SetEmployeeDTO: DTOBaseClass, ISetDTOService
    {
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        [MaxLength(128)]
        public string? EmployeeName { get; set; }
        [Required]
        public int? EmployeeSalary { get; set; }


        public SetEmployeeDTO(ICommandLineArgumentsService commandLineArguments): base(commandLineArguments)
        {

            ValidateArgumentsForRequest();

            try
            {
                EmployeeId = Int32.Parse(_commandLineArguments["Id"]);
                EmployeeName = _commandLineArguments["Name"];
                EmployeeSalary = Int32.Parse(_commandLineArguments["Salary"]);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public override void ValidateArgumentsForRequest()
        {

            string className = GetType().Name;
            int propertiesCount = GetType().GetProperties().Count();

            if (_commandLineArguments.Count != propertiesCount)
            {
                throw new Exception($"Command-line arguments number do not match class {className} properties number.");
            }

        }

        public Employee CreateEmployeeSetObject()
        {
            Employee employee = new Employee()
            {
                Id = EmployeeId,
                Name = EmployeeName,
                EmployeeSalary = EmployeeSalary,
            };

            return employee;
        }

    }
}
