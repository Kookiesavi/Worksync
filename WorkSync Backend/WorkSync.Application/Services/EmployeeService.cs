using System.Linq;
using System.Threading.Tasks;
using WorkSync.Application.DTOs;
using WorkSync.Application.Interfaces;
using WorkSync.Domain.Entities;

namespace WorkSync.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ITeamRepository _teamRepository;
    public EmployeeService(IEmployeeRepository employeeRepository, ITeamRepository teamRepository)
    {
        _employeeRepository = employeeRepository;
        _teamRepository = teamRepository;
    }

    public async Task<EmployeeDto?> CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto)
    {
       if(createEmployeeDto.TeamId.HasValue)
        {
            var team = await _teamRepository.GetTeamByIdAsync(createEmployeeDto.TeamId.Value);
            if (team == null)
            {
                throw new InvalidOperationException("Team not found.");
            }
        }

        var emp = await _employeeRepository.AddEmployeeAsync(new WorkSync.Domain.Entities.Employee
         {
             FirstName = createEmployeeDto.FirstName,
             LastName = createEmployeeDto.LastName,
             Email = createEmployeeDto.Email,
             Designation = createEmployeeDto.Designation,
             Department = createEmployeeDto.Department,
            TeamId = createEmployeeDto.TeamId
        });

        var employee = await _employeeRepository.EmployeeByIdAsync(emp.Id); 
         return new EmployeeDto
         {
             Id = employee.Id,
             FirstName = employee.FirstName,
             LastName = employee.LastName,
             Email = employee.Email,
             Department = employee.Department,
             Designation = employee.Designation,
             TeamId= employee.TeamId,
             TeamName= employee.Team?.Name
         };
    }


    public async Task<IEnumerable<EmployeeDto?>> GetAllEmployeesAsync()
    {
      var employees = await _employeeRepository.EmployeesAsync();
      return employees.Select(e => new EmployeeDto
      {
          Id = e.Id,
          FirstName = e.FirstName,
          LastName = e.LastName,    
          Email = e.Email,
          Department = e.Department,
          Designation = e.Designation,
          TeamId = e.TeamId,
          TeamName = e.Team?.Name != null ? e.Team.Name : null
      });
    }

    public async Task<EmployeeDto?> GetEmployeeByIdAsync(Guid id)
    {
        var employee = await _employeeRepository.EmployeeByIdAsync(id);
        if (employee == null)
        {
            return null;
        }
        return new EmployeeDto
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            Department = employee.Department,
            Designation = employee.Designation,
            TeamId = employee.TeamId,
            TeamName = employee.Team?.Name != null ? employee.Team.Name : null
        };
    }

    public async Task<EmployeeDto?> UpdateEmployeeAsync(Guid id, UpdateEmployeeDto updateEmployeeDto)
    {
        var employee = new Employee
        {
            Id = id,
            FirstName = updateEmployeeDto.FirstName,
            LastName = updateEmployeeDto.LastName,
            Email = updateEmployeeDto.Email,
            Designation = updateEmployeeDto.Designation,
            Department = updateEmployeeDto.Department,
            TeamId = updateEmployeeDto.TeamId
        };
         var resultEmployee=await _employeeRepository.UpdateEmployeeAsync(id,employee);
        return new EmployeeDto
        {
            Id = resultEmployee.Id,
            FirstName = resultEmployee.FirstName,
            LastName = resultEmployee.LastName,
            Email = resultEmployee.Email,
            Department = resultEmployee.Department,
            Designation = resultEmployee.Designation,
            TeamId = resultEmployee.TeamId,
            TeamName = resultEmployee.Team?.Name
        };
    }

    public async Task<string> DeleteEmployeeAsync(Guid id)
    {

        var employee = await _employeeRepository.EmployeeByIdAsync(id);
        if (employee == null)
        {
            throw new InvalidOperationException("Employee not found.");
        }
        var deletedEmployee = await _employeeRepository.DeleteEmployeeAsync(id);
        return "Employee deleted successfully.";
    }
}
