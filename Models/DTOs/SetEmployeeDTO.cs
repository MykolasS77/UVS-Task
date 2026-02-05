using System.ComponentModel.DataAnnotations;

namespace Models.DTOs
{
    public class SetEmployeeDTO
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "{0} must be a positive number.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} not provided")]
        [MaxLength(128)]
        public string? Name { get; set; }
        [Required(ErrorMessage = "{0} not provided")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} must be a positive number.")]
        public int? Salary { get; set; }
    }
}
