using Services;
using System.Collections.Generic;

namespace DatabaseSchema.CommandLineMethods.ParsedCommandLineArgs
{
    public class ArgsFormattingForRequest : IFormatArgsForRequest
    {

        private readonly IArgsValidation _validatedArgs;

        private readonly Dictionary<string, string> _commandLineArgsNameConvert = new Dictionary<string, string>()
        {
            {"--employeeId", "Id"},
            {"--employeeName", "Name"},
            {"--employeeSalary", "Salary"}
        };

        public ArgsFormattingForRequest(IArgsValidation validatedArgs)
        {

            _validatedArgs = validatedArgs;

        }

        public Dictionary<string, string> GetParsedCommandLineArguments()
        {
            string[] validatedArgs = _validatedArgs.GetValidatedCommandLineKeyAndValueArgs();
            Dictionary<string, string> parsedArgs = ParseArgs(validatedArgs);
            return parsedArgs;
        }

        public Dictionary<string, string> ParseArgs(string[] validatedArgs)
        {


            Dictionary<string, string> parsedMethodArguments = new Dictionary<string, string>();

            for (int i = 0; i < validatedArgs.Length; i += 2)
            {
                string? validKey = _commandLineArgsNameConvert[validatedArgs[i]];
                string? validValue = validatedArgs[i + 1];
                parsedMethodArguments.Add(validKey, validValue);
            }

            return parsedMethodArguments;
        }

    }
}
