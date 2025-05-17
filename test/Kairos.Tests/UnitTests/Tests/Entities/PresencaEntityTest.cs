namespace Kairos.Tests.UnitTests.Tests.Entities;
public class PresencaEntityTest
{
    #region </Constants>
        private const int InvalidNumberZero = 0;
        private const int InvalidNumber = -1;
        private const int ValidUsuario = 1;
        private const int ValidEvento = 1;
    #endregion

    #region </Id>
        [Theory]
        [InlineData(InvalidNumber, ValidUsuario, ValidEvento, "199-01-01")]
        [InlineData(InvalidNumberZero, ValidUsuario, ValidEvento, "199-01-01")]
        public void Presenca_ShouldFailIdIfIdIsNegative(int id, int usuarioID, int eventoID, DateTime dataHoraCheckin)
        {
            Assert.True(true); 
            Assert.Throws<DomainValidationException>(() =>
            {
                var acount = new PresencaEntity(id, usuarioID, eventoID, dataHoraCheckin);
            });
        }
    #endregion

    #region </UsuarioId>
        [Theory]
        [InlineData(InvalidNumber, ValidEvento, "199-01-01")]
        [InlineData(InvalidNumberZero, ValidEvento, "199-01-01")]
        public void Presenca_ShouldFailUsuarioIdIfIdIsNegative(int usuarioID, int eventoID, DateTime dataHoraCheckin)
        {
            Assert.True(true); 
            Assert.Throws<DomainValidationException>(() =>
            {
                var acount = new PresencaEntity(usuarioID, eventoID, dataHoraCheckin);
            });
        }
    #endregion

    #region </EventoId>
        [Theory]
        [InlineData(ValidUsuario, InvalidNumber, "199-01-01")]
        [InlineData(ValidUsuario, InvalidNumberZero, "199-01-01")]
        public void Presenca_ShouldFailEventoIdIfIdIsNegative(int usuarioID, int eventoID, DateTime dataHoraCheckin)
        {
            Assert.True(true); 
            Assert.Throws<DomainValidationException>(() =>
            {
                var acount = new PresencaEntity(usuarioID, eventoID, dataHoraCheckin);
            });
        }
    #endregion
}
