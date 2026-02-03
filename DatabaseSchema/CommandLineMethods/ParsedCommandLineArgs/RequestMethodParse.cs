using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseSchema.CommandLineMethods.ParsedCommandLineArgs
{
    public class RequestMethodParse: IRequestMethodParse
    {
        private readonly RequestMethod RequestMethodType;

        private readonly Dictionary<string, RequestMethod> _validRequestMethodArguments = new Dictionary<string, RequestMethod>()
        {
            {"get-employee", RequestMethod.Get},
            {"set-employee", RequestMethod.Set},
        };

        public RequestMethodParse()
        {
            string[] args = Environment.GetCommandLineArgs();
            string methodTypeFromCommandLine = args[1];

            RequestMethodType = _validRequestMethodArguments[methodTypeFromCommandLine];

        }

        public RequestMethod GetParsedRequestMethod()
        {
            return RequestMethodType;
        }
    }
}
