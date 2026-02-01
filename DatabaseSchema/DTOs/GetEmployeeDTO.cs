using Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DatabaseSchema.DTOs
{
    public class GetEmployeeDTO: DTOBaseClass, IGetDTOService
    {
        [Required]
        public int? EmployeeId { get; set; }

        public GetEmployeeDTO(ICommandLineArgumentsService commandLineArguments): base(commandLineArguments)
        {

            ValidateArgumentsForRequest();

            try
            {
                EmployeeId = Int32.Parse(_commandLineArguments["Id"]);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public override void ValidateArgumentsForRequest()
        {
            string className = GetType().Name;
            int propertiesCount = GetType().GetProperties().Count();

            if (_commandLineArguments.Count != propertiesCount)
            {
                throw new Exception($"Command-line arguments number do not match class {className} properties number.");
            }
        }

        public int GetId()
        {
                return EmployeeId ?? throw new ArgumentNullException("EmployeeId is null"); 
        }
    }
}
