using System.Threading.Tasks;


namespace DatabaseSchema
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ProgramRunner programRunner = new ProgramRunner();
            await programRunner.RunProgram(args);
            
        }
    }
}
