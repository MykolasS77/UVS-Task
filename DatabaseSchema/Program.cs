using DatabaseSchema.Database;
using Microsoft.Extensions.DependencyInjection;
using Models.DTOs;
using Services;
using System;
using System.Threading.Tasks;


namespace DatabaseSchema
{
    class Program
    {
        static async Task Main(string[] args)
        {

            CheckIfNoArgsProvided(args);


            ServiceBuilder serviceBuilder = new ServiceBuilder();
            ServiceProvider serviceProvider = serviceBuilder.BuildServiceForProgram();

            using (var scpope = serviceProvider.CreateScope())
            {
                EmployeesDbContext database = scpope.ServiceProvider.GetRequiredService<EmployeesDbContext>();
                IMethodInit methodInit = scpope.ServiceProvider.GetRequiredService<IMethodInit>();

                database.Database.EnsureCreated();

                try
                {
                    EmployeeResponseDTO? result = await methodInit.InitMethod();

                    if (result is EmployeeResponseDTO)
                    {
                        OutputEmployeeDetails(result);
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                }

                Console.WriteLine("Press any key to exit.");
                Console.ReadLine();
            }

        }
        static void OutputEmployeeDetails(EmployeeResponseDTO employeeResponseDTO)
        {
            Console.WriteLine("Employee Details \n");
            Console.WriteLine("Name: " + employeeResponseDTO.Name);
            Console.WriteLine("Salary: " + employeeResponseDTO.Salary + "\n");
        }

        static void CheckIfNoArgsProvided(string[] args)
        {

            if (args.Length == 0)
            {
                throw new ArgumentException("No command-line arguments provided");
            }
        }

    }
}
