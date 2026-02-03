using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseSchema.CommandLineMethods.ArgsProcessing
{
    public abstract class ArgsProcessingBaseClass
    {
        protected readonly Dictionary<string, string> _commandLineArguments;

        public ArgsProcessingBaseClass(ICommandLineArgumentsService commandLineArguments)
        {
            _commandLineArguments = commandLineArguments.GetParsedCommandLineArguments();
        }

        protected abstract void ValidateArgumentsForRequest();

        protected bool CheckIfStringRepresentsPositiveNumber(string numberStringRepresentation)
        {
            int number = 0;
            bool canConvert = Int32.TryParse(numberStringRepresentation, out number);

            if (canConvert && number > 0)
            {

                return true;

            }

            return false;

        }

    }
}
