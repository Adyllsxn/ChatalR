namespace Kairos.Tests.UnitTests.Repositories.Evento;
public class CreateTests
{
    #region </Context>
        private readonly Mock<AppDbContext> _mockContext;
        private readonly Mock<DbSet<EventoEntity>> _mockSet;
        private readonly EventoRepository _repository;

    #endregion

    #region </Configuration>
        public CreateTests()
        {
            _mockSet = new Mock<DbSet<EventoEntity>>();
            _mockContext = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());
            _mockContext.Setup(c => c.Eventos).Returns(_mockSet.Object);

            _repository = new EventoRepository(_mockContext.Object);
        }
    #endregion

    #region </Tests>

        [Fact]
        public async Task Evento_CreateAsync_NullEntity_ReturnsBadRequest()
        {
            // Arrange
            EventoEntity? entity = null;

            // Act
            var result = await _repository.CreateAsync(entity!, CancellationToken.None);

            // Assert
            Assert.Equal(400, result.Code);
            Assert.Equal("Parâmetros não podem estar vazio.", result.Message);
        }


        [Fact]
        public async Task Evento_CreateAsync_ValidEntity_ReturnsCreated()
        {
            // Arrange
            var entity = new EventoEntity("Titulo", "Desc", DateTime.Now, DateTime.Now.AddHours(1), "Local", 1, 1, "img.png");

            // Act
            var result = await _repository.CreateAsync(entity, CancellationToken.None);

            // Assert
            Assert.Equal(201, result.Code);
            Assert.Equal("Operação executada com sucesso.", result.Message);
            Assert.Equal(entity, result.Data);
        }
        
    #endregion
}
