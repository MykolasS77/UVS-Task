using System.ComponentModel.DataAnnotations;

namespace Models.DTOs
{
    public class GetEmployeeDTO
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "{0} must be a positive number.")]
        public int Id { get; set; }
    }
}
