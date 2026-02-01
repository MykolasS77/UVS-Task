using DatabaseSchema.Database;
using DatabaseSchema.DTOs;
using Services;
using Microsoft.Extensions.DependencyInjection;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseSchema.CommandLineMethods
{
    public class ParsedArgs: ICommandLineArgumentsService
    {
        private readonly Dictionary<string, string> ParsedCommandLineArguments;
        
        private readonly Dictionary<string, string> _validMethodArguments = new Dictionary<string, string>()
        {
            {"--employeeId", "Id"},
            {"--employeeName", "Name"},
            {"--employeeSalary", "Salary"}
        };

        public ParsedArgs()
        {
            string [] args = Environment.GetCommandLineArgs();
            string methodTypeFromCommandLine = args[1];
            string[] methodValuesFromCommandLine = args[2..];
            Dictionary<string, string> parsedMethodArguments = new Dictionary<string, string>();

            for (int i = 0; i < methodValuesFromCommandLine.Length; i++) {

                string? validKey = _validMethodArguments[methodValuesFromCommandLine[i]];
                string? validValue = methodValuesFromCommandLine[i + 1];

                if (validKey == null) {

                    throw new ArgumentException($"Command-line key argument {validKey} was not found.");
                
                }

                if (validValue == null)
                {

                    throw new ArgumentException($"Command-line value argument {validValue} was not found.");

                }

                parsedMethodArguments.Add(validKey, validValue);
                i++;

            }

            ParsedCommandLineArguments = parsedMethodArguments;


        }

        public Dictionary<string, string> GetParsedCommandLineArguments()
        {
            return ParsedCommandLineArguments;
        }

    }
}
