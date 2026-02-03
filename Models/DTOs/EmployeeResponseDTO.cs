using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.DTOs
{
    public class EmployeeResponseDTO
    {
        public string? Name { get; set; }
        public int? Salary { get; set; }
    }
}
