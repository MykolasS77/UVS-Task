using DatabaseSchema.Database;
using Services;
using Microsoft.Extensions.DependencyInjection;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseSchema.CommandLineMethods.ParsedCommandLineArgs
{
    public class ParsedArgs: ICommandLineArgumentsService
    {
        private readonly Dictionary<string, string> _parsedCommandLineArguments;
        
        private readonly Dictionary<string, string> _validPropertyArguments = new Dictionary<string, string>()
        {
            {"--employeeId", "Id"},
            {"--employeeName", "Name"},
            {"--employeeSalary", "Salary"}
        };

        public ParsedArgs()
        {
            
            string [] args = Environment.GetCommandLineArgs();
            string[] propertyArgumentsFromCommandLine = args[2..];
            Dictionary<string, string> parsedMethodArguments = new Dictionary<string, string>();

            for (int i = 0; i < propertyArgumentsFromCommandLine.Length; i+=2) {

                try
                {
                    string? validKey = _validPropertyArguments[propertyArgumentsFromCommandLine[i]];
                    string? validValue = propertyArgumentsFromCommandLine[i + 1];
                    parsedMethodArguments.Add(validKey, validValue);
                }
                catch (Exception ex) { 

                    Console.WriteLine(propertyArgumentsFromCommandLine[i] + " is not a valid method argument.");
                    Console.WriteLine(ex.Message);  
                }

            }

            _parsedCommandLineArguments = parsedMethodArguments;


        }

        public Dictionary<string, string> GetParsedCommandLineArguments()
        {
            return _parsedCommandLineArguments;
        }

    }
}
