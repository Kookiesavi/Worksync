import { Link, NavLink } from "react-router-dom";
function AdminNavbar() {
  return (
    <aside className="admin-sidebar">
      <h2>WorkSync</h2>
      <nav>
        <NavLink to="/">Dashboard</NavLink>
        <NavLink to="/employees">Employees</NavLink>
        <NavLink to="/teams">Teams</NavLink>
        <NavLink to="/projects">Projects</NavLink>
        <NavLink to="/leaves">Leaves</NavLink>
      </nav>
      <div className="sidebar-bottom">
        <Link to="/logout">Logout</Link>
      </div>
    </aside>
  );
}
export default AdminNavbar;
