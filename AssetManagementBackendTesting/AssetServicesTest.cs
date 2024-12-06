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
    public class AssetServicesTest
    {
        private Mock<assetManagementContext> _mockContext;
        private IAssetService _assetService;

        [SetUp]
        public void Setup()
        {
            _mockContext = new Mock<assetManagementContext>();
            _assetService = new AssetServices(_mockContext.Object);
        }

        [Test]
        public void AddNewAsset_ValidAsset_ReturnsAssetId()
        {
            // Arrange
            var asset = new Asset
            {
                AssetId = 1,
                AssetName = "Test Asset",
                AssetCategory = "Category",
                AssetModel = "Model",
                ManufacturingDate = DateTime.Now,
                ExpiryDate = DateTime.Now.AddYears(5),
                AssetValue = 1000,
                Status = "Active",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _mockContext.Setup(c => c.Assets.Add(It.IsAny<Asset>())).Verifiable();
            _mockContext.Setup(c => c.SaveChanges()).Verifiable();

            // Act
            var result = _assetService.AddNewAsset(asset);

            // Assert
            Assert.That(result, Is.EqualTo(1)); // Corrected to Assert.That
            _mockContext.Verify(c => c.Assets.Add(It.IsAny<Asset>()), Times.Once);
            _mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void DeleteAsset_ValidId_ReturnsSuccessMessage()
        {
            // Arrange
            var assetId = 1;
            var asset = new Asset
            {
                AssetId = assetId,
                AssetName = "Test Asset"
            };

            _mockContext.Setup(c => c.Assets.FirstOrDefault(It.IsAny<Func<Asset, bool>>())).Returns(asset);
            _mockContext.Setup(c => c.Assets.Remove(It.IsAny<Asset>())).Verifiable();
            _mockContext.Setup(c => c.SaveChanges()).Verifiable();

            // Act
            var result = _assetService.DeleteAsset(assetId);

            // Assert
            Assert.That(result, Is.EqualTo("The given Asset id 1 Removed"));  // Corrected to Assert.That
            _mockContext.Verify(c => c.Assets.Remove(It.IsAny<Asset>()), Times.Once);
            _mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void GetAllAsset_ReturnsListOfAssets()
        {
            // Arrange
            var assets = new List<Asset>
            {
                new Asset { AssetId = 1, AssetName = "Asset 1" },
                new Asset { AssetId = 2, AssetName = "Asset 2" }
            };
            _mockContext.Setup(c => c.Assets.ToList()).Returns(assets);

            // Act
            var result = _assetService.GetAllAsset();

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));  // Corrected to Assert.That
        }

        [Test]
        public void GetAssetById_ValidId_ReturnsAsset()
        {
            // Arrange
            var assetId = 1;
            var asset = new Asset
            {
                AssetId = assetId,
                AssetName = "Test Asset"
            };

            _mockContext.Setup(c => c.Assets.FirstOrDefault(It.IsAny<Func<Asset, bool>>())).Returns(asset);

            // Act
            var result = _assetService.GetAssetById(assetId);

            // Assert
            Assert.That(result, Is.Not.Null);  // Corrected to Assert.That
            Assert.That(result.AssetId, Is.EqualTo(assetId));  // Corrected to Assert.That
        }

        [Test]
        public void UpdateAsset_ValidAsset_ReturnsSuccessMessage()
        {
            // Arrange
            var asset = new Asset
            {
                AssetId = 1,
                AssetName = "Updated Asset"
            };

            var existingAsset = new Asset
            {
                AssetId = 1,
                AssetName = "Old Asset"
            };

            _mockContext.Setup(c => c.Assets.FirstOrDefault(It.IsAny<Func<Asset, bool>>())).Returns(existingAsset);
            _mockContext.Setup(c => c.SaveChanges()).Verifiable();

            // Act
            var result = _assetService.UpdateAsset(asset);

            // Assert
            Assert.That(result, Is.EqualTo("Record Updated successfully"));  // Corrected to Assert.That
            _mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }
    }
}