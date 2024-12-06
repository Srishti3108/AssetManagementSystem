import React, { useState, useEffect } from "react";
import EmployeeService from "./employeeService";

const EmployeeCRUD = () => {
  const [employees, setEmployees] = useState([]);
  const [employee, setEmployee] = useState({
    employeeId: 0,
    name: "",
    email: "",
    gender: "",
    contactNumber: "",
    address: "",
    passwordHash: "",
    createdAt: "",
    updatedAt: "",
  });
  const [isEditing, setIsEditing] = useState(false);

  // Fetch all employees on component load
  useEffect(() => {
    fetchEmployees();
  }, []);

  const fetchEmployees = async () => {
    const data = await EmployeeService.getAllEmployees();
    setEmployees(data);
  };

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setEmployee({ ...employee, [name]: value });
  };

  const handleAddEmployee = async () => {
    if (isEditing) {
      await EmployeeService.updateEmployee(employee);
    } else {
      await EmployeeService.addNewEmployee(employee);
    }
    fetchEmployees();
    setEmployee({
      employeeId: 0,
      name: "",
      email: "",
      gender: "",
      contactNumber: "",
      address: "",
      passwordHash: "",
      createdAt: "",
      updatedAt: "",
    });
    setIsEditing(false);
  };

  const handleEditEmployee = (emp) => {
    setEmployee(emp);
    setIsEditing(true);
  };

  const handleDeleteEmployee = async (id) => {
    await EmployeeService.deleteEmployee(id);
    fetchEmployees();
  };

  return (
    <div className="container mt-5">
      <h2>Employee Management</h2>
      <form
        onSubmit={(e) => {
          e.preventDefault();
          handleAddEmployee();
        }}
      >
        <input
          type="text"
          name="name"
          placeholder="Name"
          value={employee.name}
          onChange={handleInputChange}
          required
        />
        <input
          type="email"
          name="email"
          placeholder="Email"
          value={employee.email}
          onChange={handleInputChange}
          required
        />
        <input
          type="text"
          name="gender"
          placeholder="Gender"
          value={employee.gender}
          onChange={handleInputChange}
          required
        />
        <input
          type="text"
          name="contactNumber"
          placeholder="Contact Number"
          value={employee.contactNumber}
          onChange={handleInputChange}
          required
        />
        <input
          type="text"
          name="address"
          placeholder="Address"
          value={employee.address}
          onChange={handleInputChange}
          required
        />
        <button type="submit" className="btn btn-primary">
          {isEditing ? "Update" : "Add"} Employee
        </button>
      </form>

      <table className="table mt-4">
        <thead>
          <tr>
            <th>Name</th>
            <th>Email</th>
            <th>Gender</th>
            <th>Contact Number</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {employees.map((emp) => (
            <tr key={emp.employeeId}>
              <td>{emp.name}</td>
              <td>{emp.email}</td>
              <td>{emp.gender}</td>
              <td>{emp.contactNumber}</td>
              <td>
                <button
                  className="btn btn-warning"
                  onClick={() => handleEditEmployee(emp)}
                >
                  Edit
                </button>
                <button
                  className="btn btn-danger"
                  onClick={() => handleDeleteEmployee(emp.employeeId)}
                >
                  Delete
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default EmployeeCRUD;
