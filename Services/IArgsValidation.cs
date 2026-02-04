namespace Services
{
    public interface IArgsValidation
    {
        public string[] GetValidatedCommandLineKeyAndValueArgs();
        public string GetValidatedCommandLineMethodType();
    }
}
