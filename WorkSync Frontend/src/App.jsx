import { useEffect, useState } from "react";
import { getallEmployees, getallTeams } from "./Api/apiService";

function App() {
  const [employeeCount, setEmployeeCount] = useState(0);
  const [teamCount, setTeamCount] = useState(0);

  useEffect(() => {
    getallEmployees().then((data) => {
      setEmployeeCount(data.length);
    });
  }, []);
  useEffect(() => {
    getallTeams().then((data) => {
      setTeamCount(data.length);
    });
  }, []);

  useEffect(() => {
    console.log("Worksync app loaded!....");
  }, []);

  return (
    <div>
      <h1>Worksync</h1>
      <p>Employee And Team Management System</p>

      <h2> DashBoard </h2>

      {/* <button onClick={() => setEmployeeCount(employeeCount + 1)}>
        Add Employee
      </button> */}

      <p>Total Employee Count: {employeeCount}</p>
      {/* <button onClick={() => setTeamCount(teamCount + 1)}>Add Team</button> */}
      <p>Total Team Count: {teamCount}</p>
    </div>
  );
}

export default App;
