using Services;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using Models.DTOs;

namespace DatabaseSchema.CommandLineMethods.ArgsProcessing
{
    public class ArgsProcessingForSetEmployee: ArgsProcessingBaseClass, ISetEmployeeArgsProcessingService
    {

        public ArgsProcessingForSetEmployee(ICommandLineArgumentsService commandLineArguments): base(commandLineArguments)
        {

            ValidateArgumentsForRequest();
        }

        protected override void ValidateArgumentsForRequest()
        {
            string className = GetType().Name;
            int propertiesCount = typeof(SetEmployeeDTO).GetProperties().Count();
            

            if (_commandLineArguments.Count != propertiesCount)
            {
                throw new Exception($"Command-line arguments number for set request does not match class '{className}' properties number.");
            }

            bool idValueRepresentsNumber = CheckIfStringRepresentsPositiveNumber(_commandLineArguments["Id"]);
            bool salaryValueRepresentsNumber = CheckIfStringRepresentsPositiveNumber(_commandLineArguments["Salary"]);
            bool employeeNameRepresentsNumber = CheckIfStringRepresentsPositiveNumber(_commandLineArguments["Name"]);


            if (!idValueRepresentsNumber)
            {
                throw new Exception("Id provided in command-line value must be a positive number.");
            }
            if (!salaryValueRepresentsNumber)
            {
                throw new Exception("Salary value provided in command-line value must be a positive number.");
            }
            if (employeeNameRepresentsNumber) {

                throw new Exception("Employee name should be a valid string.");
            
            }




        }

        public SetEmployeeDTO CreateDTOForSetEmployee()
        {
            SetEmployeeDTO employeeSetDTO = new SetEmployeeDTO()
            {
                Id = Int32.Parse(_commandLineArguments["Id"]),
                Name = _commandLineArguments["Name"],
                Salary = Int32.Parse(_commandLineArguments["Salary"]),
            };

            return employeeSetDTO;
        }

    }
}
