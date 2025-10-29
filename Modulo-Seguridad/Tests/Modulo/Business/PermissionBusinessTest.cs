using Moq;
using Business.Implementations.Model_Security;
using Data.Interfaces.DataBasic;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Business.Tests
{
    public class PermissionBusinessTests
    {
        private readonly Mock<IData<Permission>> _mockRepository;
        private readonly Mock<ILogger<Permission>> _mockLogger;
        private readonly DbContext _context;
        private readonly PermissionBusiness _business;

        public PermissionBusinessTests()
        {
            _mockRepository = new Mock<IData<Permission>>();
            _mockLogger = new Mock<ILogger<Permission>>();
            var options = new DbContextOptionsBuilder<DbContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;
            _context = new DbContext(options);

            _business = new PermissionBusiness(_mockRepository.Object, _mockLogger.Object, _context);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnPermissions()
        {
            // Arrange
            var permissions = new List<Permission>
            {
                new Permission { Id = 1, Name = "Read" },
                new Permission { Id = 2, Name = "Write" }
            };
            _mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(permissions);

            // Act
            var result = await _business.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Collection(result,
                item => Assert.Equal("Read", item.Name),
                item => Assert.Equal("Write", item.Name));
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnPermission_WhenExists()
        {
            // Arrange
            var permission = new Permission { Id = 1, Name = "Edit" };
            _mockRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(permission);

            // Act
            var result = await _business.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Edit", result.Name);
        }

        //[Fact]
        //public async Task GetByIdAsync_ShouldThrowException_WhenNotExists()
        //{
        //    // Arrange
        //    _mockRepository.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((Permission)null);

        //    // Act & Assert
        //    await Assert.ThrowsAsync<KeyNotFoundException>(() => _business.GetByIdAsync(99));
        //}

        [Fact]
        public async Task CreateAsync_ShouldReturnCreatedPermission()
        {
            // Arrange
            var permission = new Permission { Id = 1, Name = "Create" };
            _mockRepository.Setup(r => r.CreateAsync(permission)).ReturnsAsync(permission);

            // Act
            var result = await _business.CreateAsync(permission);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Create", result.Name);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnTrue_WhenSuccessful()
        {
            // Arrange
            var permission = new Permission { Id = 1, Name = "Update" };
            _mockRepository.Setup(r => r.UpdateAsync(permission)).ReturnsAsync(true);

            // Act
            var result = await _business.UpdateAsync(permission);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnTrue_WhenSuccessful()
        {
            // Arrange
            _mockRepository.Setup(r => r.DeleteAsync(1)).ReturnsAsync(true);

            // Act
            var result = await _business.DeleteAsync(1);

            // Assert
            Assert.True(result);
        }

        //[Fact]
        //public async Task DeleteAsync_ShouldThrowException_WhenNotFound()
        //{
        //    // Arrange
        //    _mockRepository.Setup(r => r.DeleteAsync(2)).ReturnsAsync(false);

        //    // Act & Assert
        //    await Assert.ThrowsAsync<KeyNotFoundException>(() => _business.DeleteAsync(2));
        //}
    }
}
