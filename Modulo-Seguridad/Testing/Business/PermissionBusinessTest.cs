using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Testing.Business
{
    public class PermissionBusinessTests
    {
        private readonly Mock<IData<Permission>> _mockRepository;
        private readonly Mock<ILogger<Permission>> _mockLogger;
        private readonly Mock<DbContext> _mockContext;
        private readonly PermissionBusiness _business;

        public PermissionBusinessTests()
        {
            _mockRepository = new Mock<IData<Permission>>();
            _mockLogger = new Mock<ILogger<Permission>>();
            _mockContext = new Mock<DbContext>();

            _business = new PermissionBusiness(
                _mockRepository.Object,
                _mockLogger.Object,
                _mockContext.Object
            );
        }

        [Fact]
        public async Task GetAllAsync_ReturnsPermissionsList()
        {
            // Arrange
            var data = new List<Permission> { new Permission { Id = 1, Name = "Read" } };
            _mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(data);

            // Act
            var result = await _business.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsEntity_WhenExists()
        {
            // Arrange
            var permission = new Permission { Id = 1, Name = "Write" };
            _mockRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(permission);

            // Act
            var result = await _business.GetByIdAsync(1);

            // Assert
            Assert.Equal("Write", result?.Name);
        }

        [Fact]
        public async Task GetByIdAsync_ThrowsEntityNotFoundException_WhenNotFound()
        {
            // Arrange
            _mockRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((Permission)null);

            // Act & Assert
            await Assert.ThrowsAsync<EntityNotFoundException>(() => _business.GetByIdAsync(1));
        }

        [Fact]
        public async Task CreateAsync_ReturnsCreatedEntity()
        {
            // Arrange
            var permission = new Permission { Id = 2, Name = "Edit" };
            _mockRepository.Setup(r => r.CreateAsync(permission)).ReturnsAsync(permission);

            // Act
            var result = await _business.CreateAsync(permission);

            // Assert
            Assert.Equal(2, result.Id);
            Assert.Equal("Edit", result.Name);
        }

        [Fact]
        public async Task UpdateAsync_ReturnsTrue_WhenSuccess()
        {
            // Arrange
            var permission = new Permission { Id = 3, Name = "Delete" };
            _mockRepository.Setup(r => r.UpdateAsync(permission)).ReturnsAsync(true);

            // Act
            var result = await _business.UpdateAsync(permission);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteAsync_ReturnsTrue_WhenSuccess()
        {
            // Arrange
            _mockRepository.Setup(r => r.DeleteAsync(1)).ReturnsAsync(true);

            // Act
            var result = await _business.DeleteAsync(1);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteAsync_ThrowsEntityNotFoundException_WhenNotFound()
        {
            // Arrange
            _mockRepository.Setup(r => r.DeleteAsync(99)).ReturnsAsync(false);

            // Act & Assert
            await Assert.ThrowsAsync<EntityNotFoundException>(() => _business.DeleteAsync(99));
        }

        [Fact]
        public async Task CreateAsync_ThrowsBusinessException_WhenRepositoryFails()
        {
            // Arrange
            var permission = new Permission { Id = 10, Name = "Fail" };
            _mockRepository
                .Setup(r => r.CreateAsync(permission))
                .ThrowsAsync(new Exception("DB Error"));

            // Act & Assert
            await Assert.ThrowsAsync<BusinessException>(() => _business.CreateAsync(permission));
        }
    }
}
