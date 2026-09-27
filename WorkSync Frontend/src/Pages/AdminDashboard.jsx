function AdminDashboard({ employeeCount, teamCount, employees }) {
  console.log("Emp data = ", employees);
  return (
    <>
      <div className="dashboard-cards">
        <div className="dashboard-card">
          <h3>Total Employees</h3>
          <p>{employeeCount}</p>
        </div>

        <div className="dashboard-card">
          <h3>Total Teams</h3>
          <p>{teamCount}</p>
        </div>

        <div className="dashboard-card">
          <h3>Total Projects</h3>
          <p>0</p>
        </div>

        <div className="dashboard-card">
          <h3>Total Leaves</h3>
          <p>0</p>
        </div>
      </div>
      <div className="recent-employees">
        <div className="section-header">
          <h2>Recent Employees</h2>
          <a href="/employees">View All</a>
        </div>
        {employees.slice(0, 5).map((employee) => (
          <div className="recent-employee" key={employee.id}>
            <div className="employee-info">
              <span className="employee-name">
                {employee.firstName} {employee.lastName}
              </span>
              <span>{employee.designation}</span>
              <span>{employee.department}</span>
            </div>
          </div>
        ))}
      </div>
    </>
  );
}

export default AdminDashboard;
