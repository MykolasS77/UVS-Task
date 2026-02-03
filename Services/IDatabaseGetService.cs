using Models;
using Models.DTOs;

namespace Services
{
    public interface IDatabaseGetService
    {
        public Task<string> GetEmployeeName();
        public Task<int?> GetEmployeeSalary();

        public Task<EmployeeResponseDTO> GetEmployeeResponse();
    }
}
