using Models.DTOs;

namespace Services
{
    public interface IDatabaseLogicService
    {
        public Task<EmployeeResponseDTO> GetEmployeeResponse();
        public Task AddEmployee();
    }
}
