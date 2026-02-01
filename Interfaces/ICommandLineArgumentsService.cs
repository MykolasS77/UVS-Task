using Models;

namespace Services
{
    public interface ICommandLineArgumentsService
    {
        public Dictionary<string, string> GetParsedCommandLineArguments();
    }
}
