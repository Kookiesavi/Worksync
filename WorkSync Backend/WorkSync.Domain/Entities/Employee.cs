using System;
using System.Runtime.InteropServices;
namespace WorkSync.Domain.Entities;

public class Employee
{
    public Guid Id { get; set; }
    public string FirstName{ get; set; } = string.Empty;
    public string? LastName{ get; set; } = string.Empty; 
    public string Email{ get; set; } = string.Empty;
    public string? Designation{ get; set; } = string.Empty; 
    public string? Department{ get; set; } = string.Empty; 
    public decimal? Salary{ get; set; } = 0;
    public Guid? TeamId { get; set; } 
    public Team? Team { get; set; } 


}
