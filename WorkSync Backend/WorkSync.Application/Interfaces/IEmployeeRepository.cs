using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSync.Domain.Entities;

namespace WorkSync.Application.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> EmployeesAsync();
        Task<Employee> EmployeeByIdAsync(Guid id);
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task<Employee> UpdateEmployeeAsync(Guid id, Employee employee);
        Task<Employee> DeleteEmployeeAsync(Guid id);

    }
}
