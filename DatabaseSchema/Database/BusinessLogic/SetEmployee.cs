using Services;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Threading.Tasks;
using Models.DTOs;

namespace DatabaseSchema.Database.BusinessLogic
{
    public class SetEmployee: IDatabaseSetService
    {

        private readonly EmployeesDbContext _context;
        private readonly ISetEmployeeArgsProcessingService _setDTO;
        public SetEmployee(EmployeesDbContext context, ISetEmployeeArgsProcessingService setDataTransfer)
        {
            _setDTO = setDataTransfer;
            _context = context;
        }

        public async Task AddEmployee()
        {
            Employee newEmployee = CreateEmployeeObject();
            _context.Employees.Add(newEmployee);
            await _context.SaveChangesAsync();
            Console.WriteLine("Employee added successfully.");
        }


        private Employee CreateEmployeeObject()
        {
            SetEmployeeDTO employeeDto = _setDTO.CreateDTOForSetEmployee();

            Employee employee = new Employee()
            {
                Id = employeeDto.Id,
                Name = employeeDto.Name,
                Salary = employeeDto.Salary,
            };

            return employee;
                
        }

    }
}
