using AssetManagementSystem.Models;
using AssetManagementSystem.Repositories;
using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AssetManagementTests.nUnitTests
{
    [TestFixture]
    public class EmployeeServicesTest
    {
        private Mock<assetManagementContext> _mockContext;
        private IEmployeeService _employeeService;

        [SetUp]
        public void Setup()
        {
            _mockContext = new Mock<assetManagementContext>();
            _employeeService = new EmployeeServices(_mockContext.Object);
        }

        [Test]
        public void GetAllEmployees_ReturnsListOfEmployees()
        {
            // Arrange
            var employees = new List<Employee>
            {
                new Employee { EmployeeId = 1, Name = "Employee 1" },
                new Employee { EmployeeId = 2, Name = "Employee 2" }
            };
            _mockContext.Setup(c => c.Employees.ToList()).Returns(employees);

            // Act
            var result = _employeeService.GetAllEmployees();

            // Assert
            Assert.That(result.Count, Is.EqualTo(2)); // Assert that there are 2 employees
        }

        [Test]
        public void AddNewEmployee_ValidEmployee_ReturnsEmployeeId()
        {
            // Arrange
            var employee = new Employee
            {
                EmployeeId = 1,
                Name = "Test Employee",
                Email = "test@example.com",
                Gender = "Male",
                ContactNumber = "1234567890",
                Address = "Test Address",
                PasswordHash = "hashedpassword",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _mockContext.Setup(c => c.Employees.Add(It.IsAny<Employee>())).Verifiable();
            _mockContext.Setup(c => c.SaveChanges()).Verifiable();

            // Act
            var result = _employeeService.AddNewEmployee(employee);

            // Assert
            Assert.That(result, Is.EqualTo(1)); // Assert that the employee ID is 1
            _mockContext.Verify(c => c.Employees.Add(It.IsAny<Employee>()), Times.Once);
            _mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void DeleteEmployee_ValidId_ReturnsSuccessMessage()
        {
            // Arrange
            var employeeId = 1;
            var employee = new Employee
            {
                EmployeeId = employeeId,
                Name = "Test Employee"
            };

            _mockContext.Setup(c => c.Employees.FirstOrDefault(It.IsAny<Func<Employee, bool>>())).Returns(employee);
            _mockContext.Setup(c => c.Employees.Remove(It.IsAny<Employee>())).Verifiable();
            _mockContext.Setup(c => c.SaveChanges()).Verifiable();

            // Act
            var result = _employeeService.DeleteEmployee(employeeId);

            // Assert
            Assert.That(result, Is.EqualTo("The given Employee id 1 Removed"));  // Assert the deletion message
            _mockContext.Verify(c => c.Employees.Remove(It.IsAny<Employee>()), Times.Once);
            _mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void GetEmployeeById_ValidId_ReturnsEmployee()
        {
            // Arrange
            var employeeId = 1;
            var employee = new Employee
            {
                EmployeeId = employeeId,
                Name = "Test Employee"
            };

            _mockContext.Setup(c => c.Employees.FirstOrDefault(It.IsAny<Func<Employee, bool>>())).Returns(employee);

            // Act
            var result = _employeeService.GetEmployeeById(employeeId);

            // Assert
            Assert.That(result, Is.Not.Null);  // Assert that the result is not null
            Assert.That(result.EmployeeId, Is.EqualTo(employeeId));  // Assert that the employeeId matches
        }

        [Test]
        public void UpdateEmployee_ValidEmployee_ReturnsSuccessMessage()
        {
            // Arrange
            var employee = new Employee
            {
                EmployeeId = 1,
                Name = "Updated Employee",
                Email = "updated@example.com",
                Gender = "Male",
                ContactNumber = "0987654321",
                Address = "Updated Address",
                PasswordHash = "newhashedpassword",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            var existingEmployee = new Employee
            {
                EmployeeId = 1,
                Name = "Old Employee",
                Email = "old@example.com",
                Gender = "Male",
                ContactNumber = "1234567890",
                Address = "Old Address",
                PasswordHash = "oldhashedpassword",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _mockContext.Setup(c => c.Employees.FirstOrDefault(It.IsAny<Func<Employee, bool>>())).Returns(existingEmployee);
            _mockContext.Setup(c => c.SaveChanges()).Verifiable();

            // Act
            var result = _employeeService.UpdateEmployee(employee);

            // Assert
            Assert.That(result, Is.EqualTo("Record Updated successfully"));  // Assert the success message
            _mockContext.Verify(c => c.SaveChanges(), Times.Once);  // Verify that SaveChanges was called once
        }
    }
}
