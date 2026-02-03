using DatabaseSchema;
using DatabaseSchema.CommandLineMethods;
using DatabaseSchema.Database;
using DatabaseSchema.Database.BusinessLogic;
using DatabaseSchema.DTOs;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Services;

namespace DatabaseOperationsTests
{
    public class UnitTest1
    {

        
        public UnitTest1()
        {
            

        }

        [Fact]
        public async Task GetEmployeeTest()
        {

            var programRunner = new ProgramRunner();
            await programRunner.RunProgram(["get-employee", "1"]);


            //_commandLineArgsServiceMock.Setup(p => p.GetParsedCommandLineArguments())
            //EmployeesDbContext employeesDbContext = new EmployeesDbContext();

            //var services = new ServiceCollection()
            //        .AddDbContext<EmployeesDbContext>()
            //        .AddScoped<ICommandLineArgumentsService, ParsedArgs>()
            //        .AddScoped<IGetDTOService, GetEmployeeDTO>()
            //        .AddScoped<IDatabaseGetService, GetEmployee>()
            //        .BuildServiceProvider();

            //IGetDTOService getDTOService = services.GetRequiredService<IGetDTOService>();




            //GetEmployee getEmployee = new GetEmployee(employeesDbContext, getDTOService);
        }
    }
}
