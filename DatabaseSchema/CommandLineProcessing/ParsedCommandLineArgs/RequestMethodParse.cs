using Models;
using Services;
using System.Collections.Generic;

namespace DatabaseSchema.CommandLineMethods.ParsedCommandLineArgs
{
    public class RequestMethodParse : IRequestMethodParse
    {
        private readonly IArgsValidation _validatedArgs;

        private readonly Dictionary<string, RequestMethod> _commandLineArgToEnumConversion = new Dictionary<string, RequestMethod>()
        {
            {"get-employee", RequestMethod.Get},
            {"set-employee", RequestMethod.Set},
        };

        public RequestMethodParse(IArgsValidation validatedArgsGetter)
        {

            _validatedArgs = validatedArgsGetter;

        }

        public RequestMethod GetParsedRequestMethod()
        {
            string methodTypeFromCommandLine = _validatedArgs.GetValidatedCommandLineMethodType();
            return _commandLineArgToEnumConversion[methodTypeFromCommandLine];
        }
    }
}
