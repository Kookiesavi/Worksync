using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSync.Application.Interfaces;
using WorkSync.Domain.Entities;
using WorkSync.Infrastructure.Data;

namespace WorkSync.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly WorkSyncDbContext workSyncDbContext;
        public EmployeeRepository(WorkSyncDbContext workSyncDbContext)
        {
            this.workSyncDbContext = workSyncDbContext;
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            if(employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            await workSyncDbContext.Employees.AddAsync(employee);
            await workSyncDbContext.SaveChangesAsync();
            return employee;
        }


        public async Task<Employee> EmployeeByIdAsync(Guid id)
        {
            return await workSyncDbContext.Employees.Include(e=>e.Team).FirstOrDefaultAsync(e => e.Id == id);
        }           
        

        public async Task<List<Employee>> EmployeesAsync()
        {
            //return await workSyncDbContext.Employees.ToListAsync();
            return await workSyncDbContext.Employees.Include(e=>e.Team).ToListAsync();
        }

        public async Task<Employee> UpdateEmployeeAsync(Guid id, Employee employee)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException(nameof(id), "Missing Employee ID");
            }
            var existingEmp = await EmployeeByIdAsync(id);
            if (existingEmp==null)
            {
                throw new ArgumentException("Employee ID not found");
            }
            existingEmp.FirstName = employee.FirstName;
            existingEmp.LastName = employee.LastName;
            existingEmp.Email = employee.Email;
            existingEmp.Designation = employee.Designation;
            existingEmp.Department = employee.Department;
            existingEmp.TeamId = employee.TeamId;
            await workSyncDbContext.SaveChangesAsync();
            return await workSyncDbContext.Employees.Include(e => e.Team).FirstOrDefaultAsync(e => e.Id == id);

        }


        public async Task<Employee> DeleteEmployeeAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException(nameof(id), "Missing Employee ID");
            }

            var employee = await EmployeeByIdAsync(id);
            if (employee == null)
            {
                throw new ArgumentException("Employee ID not found");
            }

            workSyncDbContext.Employees.Remove(employee);
            await workSyncDbContext.SaveChangesAsync();
            return employee;
        }



    }
}
