using DatabaseSchema.CommandLineMethods.ArgsProcessing;
using DatabaseSchema.CommandLineMethods.ParsedCommandLineArgs;
using DatabaseSchema.Database;
using DatabaseSchema.Database.BusinessLogic;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace DatabaseSchema
{
    public class ServiceBuilder
    {
        public IRequestMethodParse BuildServiceForRequestParce()
        {
            ServiceProvider requestMethodServiceProvider = new ServiceCollection()
                    .AddSingleton<IRequestMethodParse, RequestMethodParse>()
                    .BuildServiceProvider();

            IRequestMethodParse requestService = requestMethodServiceProvider.GetRequiredService<IRequestMethodParse>();

            return requestService;
        }

        public IDatabaseGetService BuildServiceForGetMethod()
        {
            ServiceProvider getServiceProvider = new ServiceCollection()
                    .AddDbContext<EmployeesDbContext>()
                    .AddSingleton<ICommandLineArgumentsService, ParsedArgs>()
                    .AddSingleton<IGetEmployeeArgsProcessingService, ArgsProcessingForGetEmployee>()
                    .AddSingleton<IDatabaseGetService, GetEmployee>()
                    .BuildServiceProvider();

            IDatabaseGetService getService = getServiceProvider.GetRequiredService<IDatabaseGetService>();

            return getService;
        }

        public IDatabaseSetService BuildServiceForSetMethod()
        {

            ServiceProvider setServiceProvider = new ServiceCollection()
                    .AddDbContext<EmployeesDbContext>()
                    .AddSingleton<ICommandLineArgumentsService, ParsedArgs>()
                    .AddSingleton<ISetEmployeeArgsProcessingService, ArgsProcessingForSetEmployee>()
                    .AddSingleton<IDatabaseSetService, SetEmployee>()
                    .BuildServiceProvider();

            IDatabaseSetService setSerivce = setServiceProvider.GetRequiredService<IDatabaseSetService>();

            return setSerivce;

        }
    }
}
