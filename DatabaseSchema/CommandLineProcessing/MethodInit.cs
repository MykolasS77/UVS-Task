using Models;
using Models.DTOs;
using Services;
using System.Threading.Tasks;

namespace DatabaseSchema.CommandLineProcessing
{
    public class MethodInit : IMethodInit
    {
        private readonly IRequestMethodParse _requestMethodParse;
        private readonly IDatabaseLogicService _databaseLogicService;
        public MethodInit(IRequestMethodParse requestMethodParse, IDatabaseLogicService databaseLogicService)
        {

            _requestMethodParse = requestMethodParse;
            _databaseLogicService = databaseLogicService;

        }

        public async Task<EmployeeResponseDTO?> InitMethod()
        {

            RequestMethod parsedRequestMethod = _requestMethodParse.GetParsedRequestMethod();

            if (parsedRequestMethod == RequestMethod.Get)
            {
                return await _databaseLogicService.GetEmployeeResponse();
            }
            if (parsedRequestMethod == RequestMethod.Set)
            {
                await _databaseLogicService.AddEmployee();
            }
            return null;

        }
    }
}
