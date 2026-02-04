using Models;
using Models.DTOs;
using Services;
using System;
using System.Collections.Generic;

namespace DatabaseSchema.Database.DTOMakers
{
    public class DTOMaker : IDTOMaker
    {
        private readonly IFormatArgsForRequest _formatedArgsForRequest;

        public DTOMaker(IFormatArgsForRequest formatedArgsForRequest)
        {

            _formatedArgsForRequest = formatedArgsForRequest;

        }

        public GetEmployeeDTO MakeDTOForGetRequest()
        {
            Dictionary<string, string> formatedArgs = _formatedArgsForRequest.GetParsedCommandLineArguments();

            GetEmployeeDTO getEmployeeDTO = new GetEmployeeDTO()
            {
                Id = Int32.Parse(formatedArgs["Id"])
            };

            return getEmployeeDTO;


        }

        public SetEmployeeDTO MakeDTOForSetRequest()
        {
            Dictionary<string, string> formatedArgs = _formatedArgsForRequest.GetParsedCommandLineArguments();

            SetEmployeeDTO setEmployeeDTO = new SetEmployeeDTO()
            {
                Id = Int32.Parse(formatedArgs["Id"]),
                Name = formatedArgs["Name"],
                Salary = Int32.Parse(formatedArgs["Salary"])
            };

            return setEmployeeDTO;


        }

        public EmployeeResponseDTO MakeDTOForResponse(Employee employee)
        {
            EmployeeResponseDTO employeeResponseDTO = new EmployeeResponseDTO()
            {
                Name = employee.Name,
                Salary = employee.Salary
            };

            return employeeResponseDTO;
        }


    }
}
