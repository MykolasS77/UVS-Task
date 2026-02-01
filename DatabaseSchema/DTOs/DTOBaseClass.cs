using Services;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseSchema.DTOs
{
    public abstract class DTOBaseClass
    {
        protected readonly Dictionary<string, string> _commandLineArguments;
        protected readonly RequestMethod _requestMethod;

        public DTOBaseClass(ICommandLineArgumentsService commandLineArguments)
        {
            _commandLineArguments = commandLineArguments.GetParsedCommandLineArguments();
        }

        public abstract void ValidateArgumentsForRequest();
    }
}
