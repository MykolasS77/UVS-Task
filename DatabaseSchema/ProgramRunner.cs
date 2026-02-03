using DatabaseSchema.CommandLineMethods;
using DatabaseSchema.CommandLineMethods.ArgsProcessing;
using DatabaseSchema.Database;
using DatabaseSchema.Database.BusinessLogic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Models.DTOs;
using Services;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DatabaseSchema
{
    public class ProgramRunner
    {
        public async Task RunProgram(string[] args)
        {

            if (args.Length == 0)
            {
                throw new ArgumentException("No command-line arguments provided");
            }

            using (EmployeesDbContext db = new EmployeesDbContext())
            {
                db.Database.EnsureCreated();

                ServiceBuilder serviceBuilder = new ServiceBuilder();
                IRequestMethodParse requestMethodService = serviceBuilder.BuildServiceForRequestParce();
                RequestMethod requestMethod = requestMethodService.GetParsedRequestMethod();

                if (requestMethod == RequestMethod.Get)
                {
                    ExecuteGetSequence(serviceBuilder);
                }
                if (requestMethod == RequestMethod.Set)

                    ExecuteSetSequence(serviceBuilder);
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();

        }

        private void ExecuteGetSequence(ServiceBuilder serviceBuilder)
        {
            IDatabaseGetService getService = serviceBuilder.BuildServiceForGetMethod();

            try
            {
                EmployeeResponseDTO employee = getService.GetEmployeeResponse().Result;

                OutputEmployeeDetails(employee);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private async void ExecuteSetSequence(ServiceBuilder serviceBuilder)
        {

            IDatabaseSetService setService = serviceBuilder.BuildServiceForSetMethod();

            try
            {
                await setService.AddEmployee();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }

        }

        private void OutputEmployeeDetails(EmployeeResponseDTO employeeResponseDTO)
        {
            Console.WriteLine("Employee Name: " + employeeResponseDTO.Name);
            Console.WriteLine("Employee Salary: " + employeeResponseDTO.Salary);
        }

    }
}
