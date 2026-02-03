using Services;
using Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DatabaseSchema.CommandLineMethods.ArgsProcessing;
using Models.DTOs;

namespace DatabaseSchema.Database.BusinessLogic
{
    public class GetEmployee : IDatabaseGetService
    {
        private readonly EmployeesDbContext _context;
        private int _employeeId;
        public GetEmployee(EmployeesDbContext context, IGetEmployeeArgsProcessingService getEmployeeProcessingService)
        {
            _employeeId = getEmployeeProcessingService.CreateDTOForGetEmployee().Id;
            _context = context;
        }

        private async Task<Employee> GetEmployeeFromDatabase()
        {

            Employee? employee = await _context.Employees.FirstOrDefaultAsync(p => p.Id == _employeeId);
            if (employee == null)
            {
                throw new Exception($"Employee with id {_employeeId} not found");
            }

            return employee;


        }

        public async Task<string> GetEmployeeName()
        {
            Employee employee = await GetEmployeeFromDatabase();

            if (employee.Name != null) {

                return employee.Name;
            
            }

            throw new Exception("Employee object does not contain a Name property");

        }

        public async Task<int?> GetEmployeeSalary()
        {
            Employee employee = await GetEmployeeFromDatabase();

            if (employee.Salary != null)
            {

                return employee.Salary;

            }

            throw new Exception("Employee object does not contain a Name property");
        }

        public async Task<EmployeeResponseDTO> GetEmployeeResponse()
        {
            string employeeName = await GetEmployeeName();
            int? employeeSalary = await GetEmployeeSalary();

            if (employeeName == null) {

                throw new Exception("Employee name property for given id was not found.");

            }

            if (employeeSalary == null)
            {

                throw new Exception("Employee salary property for given id was not found.");

            }

            EmployeeResponseDTO employeeResponseDTO = new EmployeeResponseDTO()
            {
                Name = employeeName,
                Salary = employeeSalary
            };

            return employeeResponseDTO;
        }

    }
}
