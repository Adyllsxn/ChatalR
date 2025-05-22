namespace Kairos.Tests.UnitTests.Repositories.Evento;
public class DeleteTests
{
    #region </Context>
        private readonly Mock<AppDbContext> _mockContext;
        private readonly Mock<DbSet<EventoEntity>> _mockSet;
        private readonly EventoRepository _repository;

    #endregion

    #region </Configuration>
        public DeleteTests()
        {
            _mockSet = new Mock<DbSet<EventoEntity>>();
            _mockContext = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());
            _mockContext.Setup(c => c.Eventos).Returns(_mockSet.Object);

            _repository = new EventoRepository(_mockContext.Object);
        }
    #endregion

    #region </Tests>
        [Fact]
        public async Task Evento_DeleteAsync_InvalidId_ReturnsBadRequest()
        {
            // Arrange
            var result = await _repository.DeleteAsync(0, CancellationToken.None);

            // Assert
            Assert.Equal(400, result.Code);
            Assert.Equal("ID deve ser maior que zero.", result.Message);
            Assert.False(result.Data);
        }

        [Fact]
        public async Task Evento_DeleteAsync_IdNotFound_ReturnsNotFound()
        {
            // Arrange
            _mockContext.Setup(c => c.Eventos.FindAsync(It.IsAny<object[]>(), It.IsAny<CancellationToken>()))
                        .ReturnsAsync((EventoEntity?)null);

            // Act
            var result = await _repository.DeleteAsync(999, CancellationToken.None);

            // Assert
            Assert.Equal(404, result.Code);
            Assert.Equal("ID não encontrado.", result.Message);
            Assert.False(result.Data);
        }

    #endregion
}
