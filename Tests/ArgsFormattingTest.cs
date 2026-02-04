using DatabaseSchema.CommandLineMethods.ParsedCommandLineArgs;
using Moq;
using Services;

namespace Tests
{
    public class ArgsFormattingTest
    {

        private readonly Mock<IArgsValidation> _argsValidationServiceMock;
        private readonly Mock<ArgsFormattingForRequest> _argsFormatting;

        public ArgsFormattingTest()
        {

            _argsValidationServiceMock = new Mock<IArgsValidation>();
            _argsFormatting = new Mock<ArgsFormattingForRequest>(_argsValidationServiceMock.Object);

        }

        [Theory]
        [InlineData("--employeeId 1 --employeeName John --employeeSalary 1500")]
        [InlineData("--employeeId 2 --employeeName Angus --employeeSalary 900")]
        [InlineData("--employeeId 3 --employeeName Jimi --employeeSalary 1700")]
        [InlineData("--employeeId 4 --employeeName Ozzy --employeeSalary 1500")]
        [InlineData("--employeeId 5 --employeeName Billie --employeeSalary 1200")]
        [InlineData("--employeeName John --employeeId 1 --employeeSalary 1500")]
        [InlineData("--employeeId 2 --employeeSalary 900 --employeeName Angus")]
        [InlineData("--employeeSalary 1500 --employeeId 3 --employeeName Ozzy")]
        [InlineData("--employeeSalary 1500 --employeeName Ozzy --employeeId 4")]
        public void ArgsArrayToDictTest(string commandLineArgsString)
        {
            string[] methodArgs = TestHelpers.TurnStringToArray(commandLineArgsString);
            _argsValidationServiceMock.Setup(p => p.GetValidatedCommandLineKeyAndValueArgs()).Returns(methodArgs);
            var parsedArgs = _argsFormatting.Object.GetParsedCommandLineArguments();

            int idValueIndex = methodArgs.IndexOf("--employeeId") + 1;
            int nameValueIndex = methodArgs.IndexOf("--employeeName") + 1;
            int salaryValueIndex = methodArgs.IndexOf("--employeeSalary") + 1;

            Assert.Equal(methodArgs[idValueIndex], parsedArgs["Id"]);
            Assert.Equal(methodArgs[nameValueIndex], parsedArgs["Name"]);
            Assert.Equal(methodArgs[salaryValueIndex], parsedArgs["Salary"]);


        }

    }
}
