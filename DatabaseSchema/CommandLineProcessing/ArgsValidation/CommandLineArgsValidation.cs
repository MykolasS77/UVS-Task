using Services;
using System;

namespace DatabaseSchema.CommandLineProcessing.ArgsValidation
{
    public class CommandLineArgsValidation : IArgsValidation
    {

        private readonly ICommandLineArgsGetter _commandLineArgsGetter;
        private readonly string[] _validMethodTypeArgs = { "get-employee", "set-employee" };
        private readonly string[] _validKeyArgumentsWithStringValues = { "--employeeName" };
        private readonly string[] _validKeyArgumentsWithIntValues = { "--employeeId", "--employeeSalary" };

        public CommandLineArgsValidation(ICommandLineArgsGetter commandLineArgsGetter)
        {
            _commandLineArgsGetter = commandLineArgsGetter;
        }

        public string GetValidatedCommandLineMethodType()
        {
            CheckIfFirstArgumentRepresentsProperRequestMethodValue();
            return _commandLineArgsGetter.GetMethodTypeArg();
        }

        public string[] GetValidatedCommandLineKeyAndValueArgs()
        {
            ValidateKeyAndValueCommandLineArgs();
            return _commandLineArgsGetter.GetKeyAndValuePairArgs();
        }







        private void CheckIfFirstArgumentRepresentsProperRequestMethodValue()
        {
            string? methodTypeArg = _commandLineArgsGetter.GetMethodTypeArg();
            if (methodTypeArg == null)
            {
                throw new ArgumentNullException(nameof(methodTypeArg));
            }

            if (!_validMethodTypeArgs.Contains(methodTypeArg))
            {
                throw new ArgumentException($"'{methodTypeArg}' is not a proper value to determine request method type.");
            }
        }

        private void ValidateKeyAndValueCommandLineArgs()
        {
            string[] keyAndValuePairArgs = _commandLineArgsGetter.GetKeyAndValuePairArgs();
            int methodArgsLength = keyAndValuePairArgs.Length;

            for (int i = 0; i < methodArgsLength; i += 2)
            {

                int keyIndex = i;
                int valueIndex = i + 1;

                CheckIfElementContainsNoValue(keyIndex, valueIndex, keyAndValuePairArgs);
                CheckProperValueTypes(keyIndex, valueIndex, keyAndValuePairArgs);


            }
        }

        private void CheckIfElementContainsNoValue(int keyIndex, int valueIndex, string[] keyAndValuePairArgs)
        {
            bool lastKeyArgumentContainsNoValue = valueIndex == keyAndValuePairArgs.Length;

            if (lastKeyArgumentContainsNoValue)
            {
                ThrowExceptionForEmptyValue(keyAndValuePairArgs[keyIndex]);
            }

            string key = keyAndValuePairArgs[keyIndex];
            string value = keyAndValuePairArgs[valueIndex];



            if (value.Length > 1)
            {
                string keyPrefix = key.Substring(0, 2);
                string valuePrefix = value.Substring(0, 2);
                string keyArgPrefix = "--";

                if (keyPrefix == keyArgPrefix && valuePrefix == keyArgPrefix)
                {
                    ThrowExceptionForEmptyValue(key);
                }
            }
        }

        private void CheckProperValueTypes(int keyIndex, int valueIndex, string[] keyAndValuePairArgs)
        {

            string key = keyAndValuePairArgs[keyIndex];
            string value = keyAndValuePairArgs[valueIndex];

            bool keyArgShouldHaveStringValue = _validKeyArgumentsWithStringValues.Contains(key);
            bool keyArgShouldHaveIntValue = _validKeyArgumentsWithIntValues.Contains(key);
            bool representsNumber = CheckIfStringRepresentsPositiveNumber(value);

            if (keyArgShouldHaveStringValue == false && keyArgShouldHaveIntValue == false)
            {
                throw new ArgumentException($"Argument '{key}' does not represent a proper key value.");
            }

            if (keyArgShouldHaveStringValue == true && representsNumber == true)
            {

                throw new ArgumentException($"Argument '{key}' was provided with incorrect value type '{value}'. It should represent a valid string.");


            }

            if (keyArgShouldHaveIntValue == true && representsNumber == false)
            {

                throw new ArgumentException($"Argument '{key}' was provided with incorrect value type '{value}'. It should represent a positive number.");

            }

        }

        private void ThrowExceptionForEmptyValue(string key)
        {
            throw new ArgumentException($"No value provided for key argument '{key}'.");
        }



        private bool CheckIfStringRepresentsPositiveNumber(string numberStringRepresentation)
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
