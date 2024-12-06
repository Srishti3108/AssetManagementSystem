using NUnit.Framework;
using Moq;
using AssetManagementSystem.Repositories;
using AssetManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AssetManagementTests.nUnitTests
{
    [TestFixture]
    public class AssetAuditServicesTests
    {
        private Mock<assetManagementContext> _mockContext;
        private Mock<DbSet<AssetAudit>> _mockSet;
        private AssetAuditServices _service;

        [SetUp]
        public void Setup()
        {
            // Mock data for DbSet
            var mockData = new List<AssetAudit>
            {
                new AssetAudit { AuditId = 1, AssetId = 101, EmployeeId = 1001, AuditDate = new DateTime(2024, 1, 1), Status = "Completed" },
                new AssetAudit { AuditId = 2, AssetId = 102, EmployeeId = 1002, AuditDate = new DateTime(2024, 2, 1), Status = "Pending" }
            }.AsQueryable();

            // Mock DbSet configuration
            _mockSet = new Mock<DbSet<AssetAudit>>();
            _mockSet.As<IQueryable<AssetAudit>>().Setup(m => m.Provider).Returns(mockData.Provider);
            _mockSet.As<IQueryable<AssetAudit>>().Setup(m => m.Expression).Returns(mockData.Expression);
            _mockSet.As<IQueryable<AssetAudit>>().Setup(m => m.ElementType).Returns(mockData.ElementType);
            _mockSet.As<IQueryable<AssetAudit>>().Setup(m => m.GetEnumerator()).Returns(mockData.GetEnumerator());

            // Mock DbContext
            _mockContext = new Mock<assetManagementContext>();
            _mockContext.Setup(c => c.AssetAudits).Returns(_mockSet.Object);

            // Initialize the service
            _service = new AssetAuditServices(_mockContext.Object);
        }

        [Test]
        public void AddNewAssetAudit_WhenValidInput_ReturnsAuditId()
        {
            // Arrange
            var newAudit = new AssetAudit
            {
                AuditId = 3,
                AssetId = 103,
                EmployeeId = 1003,
                AuditDate = new DateTime(2024, 3, 1),
                Status = "Completed"
            };

            // Act
            var result = _service.AddNewAssetAudit(newAudit);

            // Assert
            Assert.That(result, Is.EqualTo(3));
            _mockSet.Verify(m => m.Add(It.IsAny<AssetAudit>()), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Test]
        public void GetAllAssetAudits_ReturnsAllRecords()
        {
            // Act
            var result = _service.GetAllAssetAudits();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetAssetAuditById_WhenValidId_ReturnsAssetAudit()
        {
            // Act
            var result = _service.GetAssetAuditById(1);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.AssetId, Is.EqualTo(101));
        }

        [Test]
        public void GetAssetAuditById_WhenInvalidId_ReturnsNull()
        {
            // Act
            var result = _service.GetAssetAuditById(99);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void DeleteAssetAudit_WhenValidId_ReturnsSuccessMessage()
        {
            // Act
            var result = _service.DeleteAssetAudit(1);

            // Assert
            Assert.That(result, Is.EqualTo("The given Asset Audit id 1 Removed"));
            _mockSet.Verify(m => m.Remove(It.IsAny<AssetAudit>()), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Test]
        public void DeleteAssetAudit_WhenInvalidId_ReturnsErrorMessage()
        {
            // Act
            var result = _service.DeleteAssetAudit(99);

            // Assert
            Assert.That(result, Is.EqualTo("Something went wrong with deletion"));
        }

        [Test]
        public void UpdateAssetAudit_WhenValidInput_ReturnsSuccessMessage()
        {
            // Arrange
            var updatedAudit = new AssetAudit
            {
                AuditId = 1,
                AssetId = 105,
                EmployeeId = 1005,
                AuditDate = new DateTime(2024, 5, 1),
                Status = "In Progress"
            };

            // Act
            var result = _service.UpdateAssetAudit(updatedAudit);

            // Assert
            Assert.That(result, Is.EqualTo("Record Updated successfully"));
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Test]
        public void UpdateAssetAudit_WhenInvalidInput_ReturnsErrorMessage()
        {
            // Arrange
            var updatedAudit = new AssetAudit
            {
                AuditId = 99,
                AssetId = 105,
                EmployeeId = 1005,
                AuditDate = new DateTime(2024, 5, 1),
                Status = "In Progress"
            };

            // Act
            var result = _service.UpdateAssetAudit(updatedAudit);

            // Assert
            Assert.That(result, Is.EqualTo("Something went wrong while updating"));
        }
    }
}
    