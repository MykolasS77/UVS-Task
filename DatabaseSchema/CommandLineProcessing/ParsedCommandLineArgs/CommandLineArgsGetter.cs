using Services;
using System;

namespace DatabaseSchema.CommandLineProcessing.ParsedCommandLineArgs
{
    public class CommandLineArgsGetter : ICommandLineArgsGetter
    {
        private readonly string[] _args;

        public CommandLineArgsGetter()
        {

            _args = Environment.GetCommandLineArgs();

        }

        public string GetMethodTypeArg()
        {
            return _args[1];
        }
        public string[] GetKeyAndValuePairArgs()
        {
            return _args[2..];
        }
    }
}
