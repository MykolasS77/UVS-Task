using Models;
using Models.DTOs;

namespace Services
{
    public interface IDTOMaker
    {
        public GetEmployeeDTO MakeDTOForGetRequest();
        public SetEmployeeDTO MakeDTOForSetRequest();
        public EmployeeResponseDTO MakeDTOForResponse(Employee employee);
    }
}
