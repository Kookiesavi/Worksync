using System;
using System.Globalization;
using WorkSync.Application.DTOs;

namespace WorkSync.Application.Interfaces;

public interface IEmployeeService
{
   Task<IEnumerable<EmployeeDto?>> GetAllEmployeesAsync();
   Task<EmployeeDto?> GetEmployeeByIdAsync(Guid id);
   Task<EmployeeDto?> CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto);
    Task<EmployeeDto?> UpdateEmployeeAsync(Guid id, UpdateEmployeeDto updateEmployeeDto);
    Task<string> DeleteEmployeeAsync(Guid id);
}
