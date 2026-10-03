import { useState } from "react";
import { createEmployee } from "../Api/apiService";

function AddEmployee({ onCancel, onSuccess, onError }) {
  const [formData, setFormData] = useState({
    firstName: "",
    lastName: "",
    email: "",
    designation: "",
    department: "",
  });

  const handleChange = (event) => {
    const { name, value } = event.target;
    setFormData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const handleSave = async () => {
    try {
      await createEmployee(formData);
      onSuccess(); // Call the onSuccess callback to show the success toast
      onCancel(); // Close the form after successful creation
    } catch (error) {
      console.error("Error creating employee:", error);
      onError(); // Call the onError callback to show the error toast
    }
  };

  return (
    <>
      <div className="add-employee-form">
        <div className="add-employee-header">
          <h2>New Employee</h2>
          <button className="close-form-btn" onClick={onCancel}>
            X
          </button>
        </div>
        <div className="add-employee-content">
          <div className="form-group">
            <label>First Name</label>
            <input
              type="text"
              name="firstName"
              placeholder="Enter first name"
              value={formData.firstName}
              onChange={handleChange}
            />
          </div>

          <div className="form-group">
            <label>Last Name</label>
            <input
              type="text"
              name="lastName"
              placeholder="Enter last name"
              value={formData.lastName}
              onChange={handleChange}
            />
          </div>

          <div className="form-group">
            <label>Email</label>
            <input
              type="email"
              name="email"
              placeholder="Enter email"
              value={formData.email}
              onChange={handleChange}
            />
          </div>

          <div className="form-group">
            <label>Designation</label>
            <input
              type="text"
              name="designation"
              placeholder="Enter designation"
              value={formData.designation}
              onChange={handleChange}
            />
          </div>

          <div className="form-group">
            <label>Department</label>
            <input
              type="text"
              name="department"
              placeholder="Enter department"
              value={formData.department}
              onChange={handleChange}
            />
          </div>

          <div className="form-actions">
            <button type="button" onClick={handleSave}>
              Save Employee
            </button>
          </div>
        </div>
      </div>
    </>
  );
}

export default AddEmployee;
