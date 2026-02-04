using DatabaseSchema.CommandLineProcessing.ArgsValidation;
using Moq;
using Services;

namespace Tests
{
    public class ErrorHandlingTest
    {
        private readonly Mock<ICommandLineArgsGetter> _commandLineArgsGetter;
        private readonly Mock<CommandLineArgsValidation> _argsValidation;

        public ErrorHandlingTest()
        {

            _commandLineArgsGetter = new Mock<ICommandLineArgsGetter>();
            _argsValidation = new Mock<CommandLineArgsValidation>(_commandLineArgsGetter.Object);

        }

        [Theory]
        [InlineData("get-employee")]
        [InlineData("set-employee")]
        public void KeyArgsTest_ProperValidation(string commandLineArgsString)
        {

            try
            {
                _commandLineArgsGetter.Setup(p => p.GetMethodTypeArg()).Returns(commandLineArgsString);
                string value = _argsValidation.Object.GetValidatedCommandLineMethodType();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }

        }

        [Theory]
        [InlineData("--employeeId 1 --employeeName John --employeeSalary 1500")]
        public void KeyArgsTest_ShouldNotThrowError(string commandLineArgsString)
        {
            string[] methodArgs = TestHelpers.TurnStringToArray(commandLineArgsString);

            try
            {
                _commandLineArgsGetter.Setup(p => p.GetKeyAndValuePairArgs()).Returns(methodArgs);
                string[] values = _argsValidation.Object.GetValidatedCommandLineKeyAndValueArgs();
            }
            catch (Exception ex)
            {

                Assert.Fail(ex.ToString());

            }

        }

        [Theory]
        [InlineData("--employeeId one --employeeName John --employeeSalary 1500")]
        [InlineData("--employeeId two --employeeName Angus --employeeSalary 900")]
        [InlineData("--employeeId three --employeeName Jimi --employeeSalary 1700")]
        [InlineData("--employeeId four --employeeName Ozzy --employeeSalary 1500")]
        [InlineData("--employeeId five --employeeName Billie --employeeSalary 1200")]
        [InlineData("--employeeName John --employeeId six --employeeSalary 1500")]
        [InlineData("--employeeId seven --employeeSalary 900 --employeeName Angus")]
        [InlineData("--employeeSalary 1500 --employeeId eight --employeeName Ozzy")]
        [InlineData("--employeeSalary 1500 --employeeName Ozzy --employeeId nine")]
        public void KeyArgsTest_IncorrectIdValueType(string commandLineArgsString)
        {
            string[] methodArgs = TestHelpers.TurnStringToArray(commandLineArgsString);
            _commandLineArgsGetter.Setup(p => p.GetKeyAndValuePairArgs()).Returns(methodArgs);
            Assert.Throws<ArgumentException>(() => _argsValidation.Object.GetValidatedCommandLineKeyAndValueArgs());
        }

        [Theory]
        [InlineData("--employeeId 1 --employeeName 1 --employeeSalary 1500")]
        [InlineData("--employeeId 2 --employeeName 1 --employeeSalary 900")]
        [InlineData("--employeeId 3 --employeeName 1 --employeeSalary 1700")]
        [InlineData("--employeeId 4 --employeeName 1 --employeeSalary 1500")]
        [InlineData("--employeeId 5 --employeeName 1 --employeeSalary 1200")]
        [InlineData("--employeeName 1 --employeeId 1 --employeeSalary 1500")]
        [InlineData("--employeeId 2 --employeeSalary 900 --employeeName 1")]
        [InlineData("--employeeSalary 1500 --employeeId 3 --employeeName 1")]
        [InlineData("--employeeSalary 1500 --employeeName 1 --employeeId 4")]
        public void KeyArgsTest_IncorrectNameValueType(string commandLineArgsString)
        {
            string[] methodArgs = TestHelpers.TurnStringToArray(commandLineArgsString);
            _commandLineArgsGetter.Setup(p => p.GetKeyAndValuePairArgs()).Returns(methodArgs);
            Assert.Throws<ArgumentException>(() => _argsValidation.Object.GetValidatedCommandLineKeyAndValueArgs());
        }

        [Theory]
        [InlineData("--employeeId 1 --employeeName 1 --employeeSalary -150")]
        [InlineData("--employeeId 2 --employeeName 1 --employeeSalary -9999")]
        [InlineData("--employeeId 3 --employeeName 1 --employeeSalary 0")]
        [InlineData("--employeeId 4 --employeeName 1 --employeeSalary -589156")]
        [InlineData("--employeeId 5 --employeeName 1 --employeeSalary -12222")]
        [InlineData("--employeeName 1 --employeeId 1 --employeeSalary -4")]
        [InlineData("--employeeId 2 --employeeSalary 900 --employeeName 1")]
        [InlineData("--employeeSalary -1598723 --employeeId 3 --employeeName 1")]
        [InlineData("--employeeSalary -5654898 --employeeName 1 --employeeId 4")]
        public void KeyArgsTest_IncorrectSalaryValueType(string commandLineArgsString)
        {
            string[] methodArgs = TestHelpers.TurnStringToArray(commandLineArgsString);
            _commandLineArgsGetter.Setup(p => p.GetKeyAndValuePairArgs()).Returns(methodArgs);
            Assert.Throws<ArgumentException>(() => _argsValidation.Object.GetValidatedCommandLineKeyAndValueArgs());
        }

        [Theory]
        [InlineData("--employeeId --employeeName John --employeeSalary 1500")]
        [InlineData("--employeeId 2 --employeeName --employeeSalary 900")]
        [InlineData("--employeeId 3 --employeeName Jimi --employeeSalary")]
        [InlineData("--employeeId --employeeName --employeeSalary")]
        public void KeyArgsTest_EmptyValues(string commandLineArgsString)
        {
            string[] methodArgs = TestHelpers.TurnStringToArray(commandLineArgsString);
            _commandLineArgsGetter.Setup(p => p.GetKeyAndValuePairArgs()).Returns(methodArgs);
            Assert.Throws<ArgumentException>(() => _argsValidation.Object.GetValidatedCommandLineKeyAndValueArgs());
        }



        [Theory]
        [InlineData("get-ceo")]
        [InlineData("get-food")]
        [InlineData("get-someone")]
        [InlineData("get-info")]
        public void KeyArgsTest_ImproperGetMethodArg(string commandLineArgsString)
        {
            _commandLineArgsGetter.Setup(p => p.GetMethodTypeArg()).Returns(commandLineArgsString);
            Assert.Throws<ArgumentException>(() => _argsValidation.Object.GetValidatedCommandLineMethodType());
        }

    }
}
