namespace Services
{
    public interface ICommandLineArgsGetter
    {
        public string GetMethodTypeArg();
        public string[] GetKeyAndValuePairArgs();
    }
}
