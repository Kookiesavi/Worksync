import { useEffect, useState } from "react";
import { getallEmployees } from "../Api/apiService";
import AddEmployee from "./AddEmployee";
import Toast from "../Components/Toast";

function AdminEmployees() {
  const [employees, setEmployees] = useState([]);
  const [showAddEmployeeForm, setShowAddEmployeeForm] = useState(false);
  const [currentPage, setCurrentPage] = useState(1);
  const employeesPerPage = 10;
  const indexOfLastEmployee = currentPage * employeesPerPage;
  const indexOfFirstEmployee = indexOfLastEmployee - employeesPerPage;
  const currentEmployees = employees.slice(
    indexOfFirstEmployee,
    indexOfLastEmployee,
  );
  const totalPages = Math.ceil(employees.length / employeesPerPage);
  const [toast, setToast] = useState({
    show: false,
    message: "",
    type: "",
  });

  const loadEmployees = async () => {
    try {
      const data = await getallEmployees();
      setEmployees(data);
    } catch (error) {
      console.error("Error fetching employees:", error);
    }
  };

  useEffect(() => {
    loadEmployees();
  }, []);

  return (
    <>
      {toast.show && (
        <Toast
          message={toast.message}
          type={toast.type}
          onClose={() =>
            setToast({
              show: false,
              message: "",
              type: "",
            })
          }
        />
      )}
      {showAddEmployeeForm && (
        <AddEmployee
          onCancel={() => setShowAddEmployeeForm(false)}
          onSuccess={() => {
            setToast({
              show: true,
              message: "Employee created successfully!",
              type: "success",
            });
            loadEmployees(); // Refresh the employee list after adding a new employee
          }}
          onError={() => {
            setToast({
              show: true,
              message: "Failed to create employee.",
              type: "error",
            });
          }}
        />
      )}

      <div className="employees-content">
        <div className="employee-table">
          <table>
            <thead>
              <tr>
                <th>Name</th>
                <th>Email</th>
                <th>Designation</th>
                <th>Department</th>
                <th>Team</th>
              </tr>
            </thead>
            <tbody>
              {currentEmployees.map((employee) => (
                <tr key={employee.id}>
                  <td>
                    {employee.firstName} {employee.lastName}
                  </td>
                  <td>{employee.email}</td>
                  <td>{employee.designation}</td>
                  <td>{employee.department}</td>
                  <td>{employee.teamName || "Not Assigned"} </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>

        {totalPages > 1 && (
          <div className="pagination">
            <button
              onClick={() => setCurrentPage(currentPage - 1)}
              disabled={currentPage === 1}
            >
              &lt;
            </button>

            <span>
              Page {currentPage} of {totalPages}
            </span>

            <button
              onClick={() => setCurrentPage(currentPage + 1)}
              disabled={currentPage === totalPages}
            >
              &gt;
            </button>
          </div>
        )}

        <div>
          <button
            className="employee-add-btn"
            onClick={() => setShowAddEmployeeForm(true)}
          >
            +
          </button>
        </div>
      </div>
    </>
  );
}

export default AdminEmployees;
