import { Link } from "react-router-dom";
function AdminNavbar() {
  return (
    <nav>
      <Link to="/">Dashboard</Link>
      <Link to="/employees">Employees</Link>
      <Link to="/teams">Teams</Link>
      <Link to="/projects">Projects</Link>
      <Link to="/leaves">Leaves</Link>
    </nav>
  );
}
export default AdminNavbar;
