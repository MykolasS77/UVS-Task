using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} not provided")]
        [MaxLength(128)]
        public string? Name { get; set; }
        [Required(ErrorMessage = "{0} not provided")]
        public int? EmployeeSalary { get; set; }
    }
}
