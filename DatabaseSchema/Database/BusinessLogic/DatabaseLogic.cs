using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTOs;
using Services;
using System;
using System.Threading.Tasks;

namespace DatabaseSchema.Database.BusinessLogic
{
    public class DatabaseLogic : IDatabaseLogicService
    {
        private readonly EmployeesDbContext _context;
        private IDTOMaker _DTOMaker;
        public DatabaseLogic(EmployeesDbContext context, IDTOMaker dtoMaker)
        {
            _context = context;
            _DTOMaker = dtoMaker;
        }

        public async Task<EmployeeResponseDTO> GetEmployeeResponse()
        {

            GetEmployeeDTO employeeDTO = _DTOMaker.MakeDTOForGetRequest();
            int employeeId = employeeDTO.Id;

            Employee? employee = await _context.Employees.FirstOrDefaultAsync(p => p.Id == employeeId);
            if (employee == null)
            {
                throw new Exception($"Employee with id '{employeeId}' not found");
            }

            return _DTOMaker.MakeDTOForResponse(employee);


        }

        public async Task AddEmployee()
        {

            Employee newEmployee = CreateEmployeeObject();
            _context.Employees.Add(newEmployee);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }

            Console.WriteLine("Employee added successfully.");

        }

        private Employee CreateEmployeeObject()
        {
            SetEmployeeDTO employeeDto = _DTOMaker.MakeDTOForSetRequest();

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
