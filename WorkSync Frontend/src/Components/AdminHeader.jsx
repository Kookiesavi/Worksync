import { useLocation } from "react-router-dom";

function AdminHearder() {
  const location = useLocation();

  const pageTitles = {
    "/": "Dashboard",
    "/employees": "Employees",
    "/teams": "Teams",
    "/projects": "Projects",
    "/leaves": "Leaves",
  };

  const pageTitle = pageTitles[location.pathname] || "Admin Portal";

  return (
    <header className="admin-header">
      <h1>{pageTitle}</h1>
      <div className="admin-user">
        <span className="admin-avatar">A</span>
        <span>Administrator</span>
      </div>
    </header>
  );
}
export default AdminHearder;
