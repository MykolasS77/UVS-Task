using Services;
using Models;
using System;
using System.Linq;

namespace DatabaseSchema.Database.BusinessLogic
{
    internal class GetMethod: IDatabaseGetService
    {
        private readonly EmployeesDbContext _context;
        private readonly IGetDTOService _getDTO;
        public GetMethod(EmployeesDbContext context, IGetDTOService getDTO)
        {
            _getDTO = getDTO;
            _context = context;
        }

        public Employee? GetEmployee()
        {
            int employeeId = _getDTO.GetId();
            Employee? employee = _context.Employees.FirstOrDefault(p => p.Id == employeeId);

            if (employee == null)
            {

                Console.WriteLine($"Employee with id {employeeId} not found");
                return null;

            }

            return employee;
        }
    }
}
