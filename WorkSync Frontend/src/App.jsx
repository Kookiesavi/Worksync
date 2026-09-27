import { useEffect, useState } from "react";
import { getallEmployees, getallTeams } from "./Api/apiService";
import "./App.css";
import AdminDashboard from "./Pages/AdminDashboard";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import AdminEmployees from "./Pages/AdminEmployees";
import AdminTeams from "./Pages/AdminTeams";
import AdminProjects from "./Pages/AdminProjects";
import AdminLeaves from "./Pages/AdminLeaves";
import AdminNavbar from "./Components/AdminNavbar";
import AdminHearder from "./Components/AdminHeader";

function App() {
  const [employeeCount, setEmployeeCount] = useState(0);
  const [teamCount, setTeamCount] = useState(0);
  const [employees, setEmployees] = useState([]);

  useEffect(() => {
    getallEmployees().then((data) => {
      setEmployeeCount(data.length);
      setEmployees(data);
      console.log("Employees data fetched:", data);
    });
  }, []);
  useEffect(() => {
    getallTeams().then((data) => {
      setTeamCount(data.length);
      console.log("Teams data fetched:", data);
    });
  }, []);

  useEffect(() => {
    console.log("Worksync app loaded!....");
  }, []);

  return (
    <BrowserRouter>
      <div className="admin-layout">
        <AdminNavbar />
        <main className="admin-content">
          <AdminHearder />

          <Routes>
            <Route
              path="/"
              element={
                <AdminDashboard
                  employeeCount={employeeCount}
                  teamCount={teamCount}
                  employees={employees}
                />
              }
            />
            <Route path="/employees" element={<AdminEmployees />} />
            <Route path="/teams" element={<AdminTeams />} />
            <Route path="/projects" element={<AdminProjects />} />
            <Route path="/leaves" element={<AdminLeaves />} />
          </Routes>
        </main>
      </div>
    </BrowserRouter>

    // <div>
    //   <AdminDashboard employeeCount={employeeCount} teamCount={teamCount} />

    //   <div className="employee-list">
    //     <h3>Employee List:</h3>
    //     <ul>
    //       {employees.map((employee) => (
    //         <li key={employee.id} className="employee-card">
    //           <strong>
    //             {employee.firstName} {employee.lastName}
    //           </strong>
    //           <span>{employee.designation}</span>
    //           <span>{employee.department}</span>
    //           <span>{employee.email}</span>
    //         </li>
    //       ))}
    //     </ul>
    //   </div>
    // </div>
  );
}

export default App;
