namespace Kairos.Tests.UnitTests.Tests.Entities;
public class SugestaoEntityTest
{
    #region </Constants>
        private const int InvalidNumberZero = 0;
        private const int InvalidNumber = -1;
        private const int ValidUsuario = 1;
        private const int ValidEvento = 1;
        private const string ValidConteudo = "Test";

    #endregion

    #region </Id>
        [Theory]
        [InlineData(InvalidNumber, ValidUsuario, ValidEvento, ValidConteudo,"199-01-01")]
        [InlineData(InvalidNumberZero, ValidUsuario, ValidEvento, ValidConteudo,"199-01-01")]
        public void Sugestao_ShouldFailIdIfIdIsNegative(int id, int usuarioID, int eventoID, string conteudo ,DateTime dataHoraCheckin)
        {
            Assert.True(true); 
            Assert.Throws<DomainValidationException>(() =>
            {
                var acount = new SugestaoEntity(id, usuarioID, eventoID, conteudo, dataHoraCheckin);
            });
        }
    #endregion

    #region </Usuario>
        [Theory]
        [InlineData(InvalidNumber, ValidEvento, ValidConteudo,"199-01-01")]
        [InlineData(InvalidNumberZero, ValidEvento, ValidConteudo,"199-01-01")]
        public void Sugestao_ShouldFailUsuarioIdIfIdIsNegative(int usuarioID, int eventoID, string conteudo,DateTime dataHoraCheckin)
        {
            Assert.True(true); 
            Assert.Throws<DomainValidationException>(() =>
            {
                var acount = new SugestaoEntity(usuarioID, eventoID, conteudo, dataHoraCheckin);
            });
        }
    #endregion

    #region </Evento>
        [Theory]
        [InlineData(ValidUsuario, InvalidNumber, ValidConteudo,"199-01-01")]
        [InlineData(ValidUsuario, InvalidNumberZero, ValidConteudo,"199-01-01")]
        public void Sugestao_ShouldFailEventoIdIfIdIsNegative(int usuarioID, int eventoID, string conteudo ,DateTime dataHoraCheckin)
        {
            Assert.True(true); 
            Assert.Throws<DomainValidationException>(() =>
            {
                var acount = new SugestaoEntity(usuarioID, eventoID, conteudo, dataHoraCheckin);
            });
        }
    #endregion

    #region </Conteudo>
        [Theory]
        [InlineData(ValidUsuario, ValidEvento, null,"199-01-01")]
        [InlineData(ValidUsuario, ValidEvento, "","199-01-01")]
        [InlineData(ValidUsuario, ValidEvento, " ","199-01-01")]
        public void Sugestao_ShouldFailIfConteudoIsNullOrEmptyOrWhiteSpace(int usuarioID, int eventoID, string conteudo ,DateTime dataHoraCheckin)
        {
            Assert.True(true); 
            Assert.Throws<DomainValidationException>(() =>
            {
                var acount = new SugestaoEntity(usuarioID, eventoID, conteudo, dataHoraCheckin);
            });
        }
    #endregion

    #region </Criar>
        [Theory]
        [InlineData(ValidUsuario, ValidEvento, ValidConteudo,"199-01-01")]
        public void Sugestao_ShouldCreate(int usuarioID, int eventoID, string conteudo ,DateTime dataHoraCheckin)
        {
            var count = new SugestaoEntity(usuarioID, eventoID, conteudo, dataHoraCheckin);
            Assert.NotNull(count);
        }
    #endregion
}