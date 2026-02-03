using Models;
using Models.DTOs;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DatabaseSchema.CommandLineMethods.ArgsProcessing
{
    public class ArgsProcessingForGetEmployee: ArgsProcessingBaseClass, IGetEmployeeArgsProcessingService
    {

        public ArgsProcessingForGetEmployee(ICommandLineArgumentsService commandLineArguments): base(commandLineArguments)
        {
            ValidateArgumentsForRequest();
            
        }

        protected override void ValidateArgumentsForRequest()
        {
            string className = GetType().Name;
            int propertiesCount = typeof(GetEmployeeDTO).GetProperties().Count();

            if (_commandLineArguments.Count != propertiesCount)
            {
                throw new Exception($"Command-line number of arguments for get request does not match class DTO '{className}' properties number.");
            }

            bool isNumber = CheckIfStringRepresentsPositiveNumber(_commandLineArguments["Id"]);

            if (!isNumber)
            {

                throw new Exception("Command-line id value for get request does not represent a number.");

            }
        }


        public GetEmployeeDTO CreateDTOForGetEmployee()
        {
            GetEmployeeDTO getDto = new GetEmployeeDTO()
            {
                Id = Int32.Parse(_commandLineArguments["Id"])
            };

            return getDto;
        }

    }
}
