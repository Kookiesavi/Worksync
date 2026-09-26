function AdminDashboard({ employeeCount, teamCount }) {
  return (
    <>
      <h1>WorkSync Dashboard</h1>
      <p>Employee And Team Management System</p>

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
    </>
  );
}

export default AdminDashboard;
