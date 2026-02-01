using DatabaseSchema.CommandLineMethods;
using DatabaseSchema.Database;
using DatabaseSchema.Database.BusinessLogic;
using DatabaseSchema.DTOs;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Services;
using System;
using System.Threading.Tasks;


namespace DatabaseSchema
{
    class Program
    {
        private static readonly string Password = Environment.GetEnvironmentVariable("UvsTaskPassword") 
            ?? throw new InvalidOperationException("You must set the UvsTaskPassword environment variable");
        private static readonly string Database = Environment.GetEnvironmentVariable("UvsTaskDatabase") 
            ?? throw new InvalidOperationException("You must set the UvsTaskDatabase environment variable");
        private static readonly string Port = Environment.GetEnvironmentVariable("UvsTaskPort") 
            ?? throw new InvalidOperationException("You must set the UvsTaskPort environment variable");
        private static readonly string SchemaLocation = Environment.GetEnvironmentVariable("UvsTaskSchemaLocation") 
            ?? throw new InvalidOperationException("You must set the UvsTaskSchemaLocation environment variable");

        static async Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                throw new ArgumentException("No command-line arguments provided");
            }

            using (EmployeesDbContext db = new EmployeesDbContext())
            {
                db.Database.EnsureCreated();

                RequestMethodParse requestMethodParse = new RequestMethodParse();
                RequestMethod requestMethod = requestMethodParse.GetRequestMethod();

                if (requestMethod == RequestMethod.Get)
                {
                    var services = new ServiceCollection()
                        .AddDbContext<EmployeesDbContext>()
                        .AddScoped<IGetDTOService, GetEmployeeDTO>()
                        .AddScoped<IDatabaseGetService, GetMethod>()
                        .AddScoped<ICommandLineArgumentsService, ParsedArgs>()
                        .BuildServiceProvider();

                    var getService = services.GetRequiredService<IDatabaseGetService>();

                    Employee? employee = getService.GetEmployee();

                    if (employee != null)
                    {
                        Console.WriteLine("Employee Name: " + employee.Name);
                        Console.WriteLine("Employee Salary: " + employee.EmployeeSalary);
                    }
                    

                }
                if(requestMethod == RequestMethod.Set)
                {
                    var services = new ServiceCollection()
                        .AddDbContext<EmployeesDbContext>()
                        .AddScoped<ISetDTOService, SetEmployeeDTO>()
                        .AddScoped<IDatabaseSetService, SetMethod>()
                        .AddScoped<ICommandLineArgumentsService, ParsedArgs>()
                        .BuildServiceProvider();

                    var setSerivce = services.GetRequiredService<IDatabaseSetService>();

                    await setSerivce.AddEmployee();

                }

                Console.ReadLine();
                

                

            }
        }

      
    }
}
