import axios from "axios";

const API_URL = "https://localhost:7107/api/employees"; // Update with your actual API endpoint

const EmployeeService = {
  getAllEmployees: async () => {
    const response = await axios.get(API_URL);
    return response.data;
  },

  getEmployeeById: async (id) => {
    const response = await axios.get(`${API_URL}/${id}`);
    return response.data;
  },

  addNewEmployee: async (employee) => {
    const response = await axios.post(API_URL, employee);
    return response.data;
  },

  updateEmployee: async (employee) => {
    const response = await axios.put(`${API_URL}/${employee.employeeId}`, employee);
    return response.data;
  },

  deleteEmployee: async (id) => {
    const response = await axios.delete(`${API_URL}/${id}`);
    return response.data;
  },
};

export default EmployeeService;


