using DatabaseSchema.CommandLineMethods.ParsedCommandLineArgs;
using DatabaseSchema.CommandLineProcessing;
using DatabaseSchema.CommandLineProcessing.ArgsValidation;
using DatabaseSchema.CommandLineProcessing.ParsedCommandLineArgs;
using DatabaseSchema.Database;
using DatabaseSchema.Database.BusinessLogic;
using DatabaseSchema.Database.DTOMakers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace DatabaseSchema
{
    public class ServiceBuilder
    {

        public ServiceProvider BuildServiceForProgram()
        {
            ServiceProvider setServiceProvider = new ServiceCollection()
                    .AddDbContext<EmployeesDbContext>()
                    .AddSingleton<ICommandLineArgsGetter, CommandLineArgsGetter>()
                    .AddSingleton<IArgsValidation, CommandLineArgsValidation>()
                    .AddSingleton<IFormatArgsForRequest, ArgsFormattingForRequest>()
                    .AddSingleton<IDTOMaker, DTOMaker>()
                    .AddSingleton<IDatabaseLogicService, DatabaseLogic>()
                    .AddSingleton<IRequestMethodParse, RequestMethodParse>()
                    .AddSingleton<IMethodInit, MethodInit>()
                    .BuildServiceProvider();

            return setServiceProvider;
        }
    }
}
