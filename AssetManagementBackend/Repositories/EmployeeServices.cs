using AssetManagementSystem.Models;

namespace AssetManagementSystem.Repositories
{
    public class EmployeeServices : IEmployeeService
    {
        private assetManagementContext _context;
        public EmployeeServices(assetManagementContext context)
        {
            _context = context;
        }
        public List<Employee> GetAllEmployees()
        {

            var employees = _context.Employees.ToList();
            if (employees.Count > 0)
            { return employees; }
            else
                return null;
        }

        
        public int AddNewEmployee(Employee employee)
        {
            try
            {
                if (employee != null)
                {
                    _context.Employees.Add(employee);
                    _context.SaveChanges();
                    return employee.EmployeeId;
                }
                else return 0;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public string DeleteEmployee(int id)
        {
            if (id != null)
            {
                var employee = _context.Employees.FirstOrDefault(x => x.EmployeeId == id);
                if (employee != null)
                {
                    _context.Employees.Remove(employee);
                    _context.SaveChanges();
                    return "The given Employee id " + id + "Removed";
                }
                else
                    return "Something went wrong with deletion";

            }
            return "Id should not be null or zero";
        }

        public Employee GetEmployeeById(int id)
        {
            if (id != 0 || id != null)
            {
                var employee = _context.Employees.FirstOrDefault(x => x.EmployeeId == id);
                if (employee != null)
                    return employee;
                else
                    return null;
            }
            return null;
        }

        public string UpdateEmployee(Employee employee)
        {
            var existingEmployee = _context.Employees.FirstOrDefault(x => x.EmployeeId == employee.EmployeeId);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Email = employee.Email;
                existingEmployee.Gender = employee.Gender;
                existingEmployee.ContactNumber = employee.ContactNumber;
                existingEmployee.Address = employee.Address;
                existingEmployee.PasswordHash = employee.PasswordHash;
                existingEmployee.CreatedAt = employee.CreatedAt;
                existingEmployee.UpdatedAt = employee.UpdatedAt;
                _context.Entry(existingEmployee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return "Record Updated successfully";
            }
            else
            {
                return "something went wrong while update";
            }
        }
    }
}
