using Models.DTOs;

namespace Services
{
    public interface IMethodInit
    {
        public Task<EmployeeResponseDTO?> InitMethod();
    }
}
