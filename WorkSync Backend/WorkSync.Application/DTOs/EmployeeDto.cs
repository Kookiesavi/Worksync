using System;
using System.ComponentModel.DataAnnotations;

namespace WorkSync.Application.DTOs;

public class EmployeeDto
{
    [Required]
    public Guid Id { get; set; } 

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
