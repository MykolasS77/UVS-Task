using Services;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSchema.Database.BusinessLogic
{
    public class SetMethod: IDatabaseSetService
    {

        private readonly EmployeesDbContext _context;
        private readonly ISetDTOService _setDataTransfer;
        public SetMethod(EmployeesDbContext context, ISetDTOService setDataTransfer)
        {
            _setDataTransfer = setDataTransfer;
            _context = context;
        }

        public async Task AddEmployee()
        {
            Employee newEmployee = _setDataTransfer.CreateEmployeeSetObject();
            _context.Employees.Add(newEmployee);
            await _context.SaveChangesAsync();
        }
    }
}
