namespace Services
{
    public interface IFormatArgsForRequest
    {
        public Dictionary<string, string> GetParsedCommandLineArguments();

        public Dictionary<string, string> ParseArgs(string[] validatedArgs);
    }
}
