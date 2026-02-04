namespace Tests
{
    static class TestHelpers
    {
        public static string[] TurnStringToArray(string commandLineArgsString)
        {
            return commandLineArgsString.Split(" ");
        }
    }
}
