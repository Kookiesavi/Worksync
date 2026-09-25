using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSync.Application.DTOs
{
    public class CreateEmployeeDto
    {
        [Required] 
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Designation { get; set; } = string.Empty;

        [Required]
        public string Department { get; set; } = string.Empty;
        public Guid? TeamId { get; set; } 
        public string? TeamName { get; set; } = string.Empty;
    }
}
