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
    public class AssetBorrowingServicesTests
    {
        private Mock<assetManagementContext> _mockContext;
        private Mock<DbSet<AssetBorrowing>> _mockSet;
        private AssetBorrowingServices _service;

        [SetUp]
        public void Setup()
        {
            // Mock data for DbSet
            var mockData = new List<AssetBorrowing>
            {
                new AssetBorrowing { BorrowId = 1, EmployeeId = 1001, AssetId = 101, BorrowDate = new DateTime(2024, 1, 1), ReturnDate = null, Status = "Borrowed" },
                new AssetBorrowing { BorrowId = 2, EmployeeId = 1002, AssetId = 102, BorrowDate = new DateTime(2024, 2, 1), ReturnDate = new DateTime(2024, 3, 1), Status = "Returned" }
            }.AsQueryable();

            // Mock DbSet configuration
            _mockSet = new Mock<DbSet<AssetBorrowing>>();
            _mockSet.As<IQueryable<AssetBorrowing>>().Setup(m => m.Provider).Returns(mockData.Provider);
            _mockSet.As<IQueryable<AssetBorrowing>>().Setup(m => m.Expression).Returns(mockData.Expression);
            _mockSet.As<IQueryable<AssetBorrowing>>().Setup(m => m.ElementType).Returns(mockData.ElementType);
            _mockSet.As<IQueryable<AssetBorrowing>>().Setup(m => m.GetEnumerator()).Returns(mockData.GetEnumerator());

            // Mock DbContext
            _mockContext = new Mock<assetManagementContext>();
            _mockContext.Setup(c => c.AssetBorrowings).Returns(_mockSet.Object);

            // Initialize the service
            _service = new AssetBorrowingServices(_mockContext.Object);
        }

        [Test]
        public void AddNewAssetBorrowing_WhenValidInput_ReturnsBorrowId()
        {
            // Arrange
            var newBorrowing = new AssetBorrowing
            {
                BorrowId = 3,
                EmployeeId = 1003,
                AssetId = 103,
                BorrowDate = new DateTime(2024, 3, 1),
                ReturnDate = null,
                Status = "Borrowed"
            };

            // Act
            var result = _service.AddNewAssetBorrowing(newBorrowing);

            // Assert
            Assert.That(result, Is.EqualTo(3));
            _mockSet.Verify(m => m.Add(It.IsAny<AssetBorrowing>()), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Test]
        public void DeleteAssetBorrowing_WhenValidId_ReturnsSuccessMessage()
        {
            // Act
            var result = _service.DeleteAssetBorrowing(1);

            // Assert
            Assert.That(result, Is.EqualTo("The given AssetBorrowing id 1Removed"));
            _mockSet.Verify(m => m.Remove(It.IsAny<AssetBorrowing>()), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Test]
        public void DeleteAssetBorrowing_WhenInvalidId_ReturnsErrorMessage()
        {
            // Act
            var result = _service.DeleteAssetBorrowing(99);

            // Assert
            Assert.That(result, Is.EqualTo("Something went wrong with deletion"));
        }

        [Test]
        public void GetAllAssetBorrowing_ReturnsAllRecords()
        {
            // Act
            var result = _service.GetAllAssetBorrowing();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetAssetBorrowingById_WhenValidId_ReturnsAssetBorrowing()
        {
            // Act
            var result = _service.GetAssetBorrowingById(1);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.AssetId, Is.EqualTo(101));
        }

        [Test]
        public void GetAssetBorrowingById_WhenInvalidId_ReturnsNull()
        {
            // Act
            var result = _service.GetAssetBorrowingById(99);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void UpdateAssetBorrowing_WhenValidInput_ReturnsSuccessMessage()
        {
            // Arrange
            var updatedBorrowing = new AssetBorrowing
            {
                BorrowId = 1,
                EmployeeId = 1005,
                AssetId = 105,
                BorrowDate = new DateTime(2024, 5, 1),
                ReturnDate = new DateTime(2024, 6, 1),
                Status = "Returned"
            };

            // Act
            var result = _service.UpdateAssetBorrowing(updatedBorrowing);

            // Assert
            Assert.That(result, Is.EqualTo("Record Updated successfully"));
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Test]
        public void UpdateAssetBorrowing_WhenInvalidInput_ReturnsErrorMessage()
        {
            // Arrange
            var updatedBorrowing = new AssetBorrowing
            {
                BorrowId = 99,
                EmployeeId = 1005,
                AssetId = 105,
                BorrowDate = new DateTime(2024, 5, 1),
                ReturnDate = new DateTime(2024, 6, 1),
                Status = "Returned"
            };

            // Act
            var result = _service.UpdateAssetBorrowing(updatedBorrowing);

            // Assert
            Assert.That(result, Is.EqualTo("something went wrong while update"));
        }
    }
}