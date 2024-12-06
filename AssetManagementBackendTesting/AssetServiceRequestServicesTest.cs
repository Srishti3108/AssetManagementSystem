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
    public class AssetServiceRequestServicesTests
    {
        private Mock<assetManagementContext> _mockContext;
        private Mock<DbSet<AssetServiceRequest>> _mockSet;
        private AssetServiceRequestServices _service;

        [SetUp]
        public void Setup()
        {
            // Mock data for DbSet
            var mockData = new List<AssetServiceRequest>
            {
                new AssetServiceRequest { RequestId = 1, AssetId = 101, EmployeeId = 1001, IssueType = "Hardware", Description = "Battery Issue", RequestDate = new DateTime(2024, 1, 1), Status = "Open" },
                new AssetServiceRequest { RequestId = 2, AssetId = 102, EmployeeId = 1002, IssueType = "Software", Description = "Application Crash", RequestDate = new DateTime(2024, 2, 1), Status = "Closed" }
            }.AsQueryable();

            // Mock DbSet configuration
            _mockSet = new Mock<DbSet<AssetServiceRequest>>();
            _mockSet.As<IQueryable<AssetServiceRequest>>().Setup(m => m.Provider).Returns(mockData.Provider);
            _mockSet.As<IQueryable<AssetServiceRequest>>().Setup(m => m.Expression).Returns(mockData.Expression);
            _mockSet.As<IQueryable<AssetServiceRequest>>().Setup(m => m.ElementType).Returns(mockData.ElementType);
            _mockSet.As<IQueryable<AssetServiceRequest>>().Setup(m => m.GetEnumerator()).Returns(mockData.GetEnumerator());

            // Mock DbContext
            _mockContext = new Mock<assetManagementContext>();
            _mockContext.Setup(c => c.AssetServiceRequests).Returns(_mockSet.Object);

            // Initialize the service
            _service = new AssetServiceRequestServices(_mockContext.Object);
        }

        [Test]
        public void AddNewAssetServiceRequest_WhenValidInput_ReturnsRequestId()
        {
            // Arrange
            var newRequest = new AssetServiceRequest
            {
                RequestId = 3,
                AssetId = 103,
                EmployeeId = 1003,
                IssueType = "Network",
                Description = "Network Issue",
                RequestDate = new DateTime(2024, 3, 1),
                Status = "Open"
            };

            // Act
            var result = _service.AddNewAssetServiceRequest(newRequest);

            // Assert
            Assert.That(result, Is.EqualTo(3));
            _mockSet.Verify(m => m.Add(It.IsAny<AssetServiceRequest>()), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Test]
        public void DeleteAssetServiceRequest_WhenValidId_ReturnsSuccessMessage()
        {
            // Act
            var result = _service.DeleteAssetServiceRequest(1);

            // Assert
            Assert.That(result, Is.EqualTo("The given Assetservicerequest id 1Removed"));
            _mockSet.Verify(m => m.Remove(It.IsAny<AssetServiceRequest>()), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Test]
        public void DeleteAssetServiceRequest_WhenInvalidId_ReturnsErrorMessage()
        {
            // Act
            var result = _service.DeleteAssetServiceRequest(99);

            // Assert
            Assert.That(result, Is.EqualTo("Something went wrong with deletion"));
        }

        [Test]
        public void GetAllAssetServiceRequest_ReturnsAllRecords()
        {
            // Act
            var result = _service.GetAllAssetServiceRequest();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetAssetServiceRequestById_WhenValidId_ReturnsAssetServiceRequest()
        {
            // Act
            var result = _service.GetAssetServiceRequestById(1);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.AssetId, Is.EqualTo(101));
        }

        [Test]
        public void GetAssetServiceRequestById_WhenInvalidId_ReturnsNull()
        {
            // Act
            var result = _service.GetAssetServiceRequestById(99);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void UpdateAssetServiceRequest_WhenValidInput_ReturnsSuccessMessage()
        {
            // Arrange
            var updatedRequest = new AssetServiceRequest
            {
                RequestId = 1,
                AssetId = 101,
                EmployeeId = 1001,
                IssueType = "Hardware",
                Description = "Updated Battery Issue",
                RequestDate = new DateTime(2024, 1, 1),
                Status = "Closed"
            };

            // Act
            var result = _service.UpdateAssetServiceRequest(updatedRequest);

            // Assert
            Assert.That(result, Is.EqualTo("Record Updated successfully"));
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Test]
        public void UpdateAssetServiceRequest_WhenInvalidInput_ReturnsErrorMessage()
        {
            // Arrange
            var updatedRequest = new AssetServiceRequest
            {
                RequestId = 99,
                AssetId = 103,
                EmployeeId = 1003,
                IssueType = "Network",
                Description = "Updated Network Issue",
                RequestDate = new DateTime(2024, 3, 1),
                Status = "Open"
            };

            // Act
            var result = _service.UpdateAssetServiceRequest(updatedRequest);

            // Assert
            Assert.That(result, Is.EqualTo("something went wrong while update"));
        }
    }
}
