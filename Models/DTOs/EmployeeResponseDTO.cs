using System.ComponentModel.DataAnnotations;

namespace Models.DTOs
{
    public class EmployeeResponseDTO
    {
        [Required]
        [MaxLength(128)]
        public string? Name { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "{0} must be a positive number.")]
        public int? Salary { get; set; }
    }
}
