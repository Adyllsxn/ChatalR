namespace Kairos.Tests.UnitTests.Tests.Entities;
public class EventoEntityTest
{
    #region </Constants>
        private const int InvalidNumberZero = 0;
        private const int InvalidNumber = -1;
        private const string ValidTitulo = "test";
        private const string ValidDescricao = "test";
        private const string ValidLocal = "test";
        private const int ValidTipoEvento = 1;
        private const int ValidUsuario = 1;
        private const string ValidImagemUrl = "test";
    #endregion

    #region </Id>
        [Theory]
        [InlineData(InvalidNumber, ValidTitulo, ValidDescricao, "1999-01-01", "1999-01-01", ValidLocal, ValidTipoEvento, ValidUsuario, ValidImagemUrl)]
        [InlineData(InvalidNumberZero, ValidTitulo, ValidDescricao, "1999-01-01", "1999-01-01", ValidLocal, ValidTipoEvento, ValidUsuario, ValidImagemUrl)]
        public void Evento_ShouldFailIdIfIdIsNegative(int id, string titulo, string descricao, DateTime dataHoraInicio, DateTime dataHoraFim, string local, int tipoEventoID, int usuarioID, string imagemUrl)
        {
            Assert.True(true); 
            Assert.Throws<DomainValidationException>(() =>
            {
                var acount = new EventoEntity(id, titulo, descricao ,dataHoraInicio, dataHoraFim, local, tipoEventoID, usuarioID, imagemUrl);
            });
        }
    #endregion

    #region </Titulo>
        [Theory]
        [InlineData(null, ValidDescricao, "1999-01-01", "1999-01-01", ValidLocal, ValidTipoEvento, ValidUsuario, ValidImagemUrl)]
        [InlineData("", ValidDescricao, "1999-01-01", "1999-01-01", ValidLocal, ValidTipoEvento, ValidUsuario, ValidImagemUrl)]
        [InlineData(" ", ValidDescricao, "1999-01-01", "1999-01-01", ValidLocal, ValidTipoEvento, ValidUsuario, ValidImagemUrl)]
        public void Evento_ShouldFailIfTituloIsNullOrEmptyOrWhiteSpace(string titulo, string descricao, DateTime dataHoraInicio, DateTime dataHoraFim, string local, int tipoEventoID, int usuarioID,  string imagemUrl)
        {
            Assert.True(true); 
            Assert.Throws<DomainValidationException>(() =>
            {
                var acount = new EventoEntity(titulo, descricao ,dataHoraInicio, dataHoraFim, local, tipoEventoID, usuarioID, imagemUrl);
            });
        }
    #endregion

    #region </Descrição>
        [Theory]
        [InlineData(ValidTitulo, null, "1999-01-01", "1999-01-01", ValidLocal, ValidTipoEvento, ValidUsuario, ValidImagemUrl)]
        [InlineData(ValidTitulo, "", "1999-01-01", "1999-01-01", ValidLocal, ValidTipoEvento, ValidUsuario, ValidImagemUrl)]
        [InlineData(ValidTitulo, " ", "1999-01-01", "1999-01-01", ValidLocal, ValidTipoEvento, ValidUsuario, ValidImagemUrl)]
        public void Evento_ShouldFailIfDescricaoIsNullOrEmptyOrWhiteSpace(string titulo, string descricao, DateTime dataHoraInicio, DateTime dataHoraFim, string local, int tipoEventoID, int usuarioID, string imagemUrl)
        {
            Assert.True(true); 
            Assert.Throws<DomainValidationException>(() =>
            {
                var acount = new EventoEntity(titulo, descricao ,dataHoraInicio, dataHoraFim, local, tipoEventoID, usuarioID, imagemUrl);
            });
        }
    #endregion

    #region </Local>
        [Theory]
        [InlineData(ValidTitulo, ValidDescricao, "1999-01-01", "1999-01-01", null, ValidTipoEvento, ValidUsuario, ValidImagemUrl)]
        [InlineData(ValidTitulo, ValidDescricao, "1999-01-01", "1999-01-01", "", ValidTipoEvento, ValidUsuario, ValidImagemUrl)]
        [InlineData(ValidTitulo, ValidDescricao, "1999-01-01", "1999-01-01", " ", ValidTipoEvento, ValidUsuario, ValidImagemUrl)]
        public void Evento_ShouldFailIfLocalIsNullOrEmptyOrWhiteSpace(string titulo, string descricao, DateTime dataHoraInicio, DateTime dataHoraFim, string local, int tipoEventoID, int usuarioID, string imagemUrl)
        {
            Assert.True(true); 
            Assert.Throws<DomainValidationException>(() =>
            {
                var acount = new EventoEntity(titulo, descricao ,dataHoraInicio, dataHoraFim, local, tipoEventoID, usuarioID, imagemUrl);
            });
        }
    #endregion

    #region </TipoEvento>
        [Theory]
        [InlineData(ValidTitulo, ValidDescricao, "1999-01-01", "1999-01-01", ValidLocal, InvalidNumber, ValidUsuario, ValidImagemUrl)]
        [InlineData(ValidTitulo, ValidDescricao, "1999-01-01", "1999-01-01", ValidLocal, InvalidNumberZero, ValidUsuario, ValidImagemUrl)]
        public void Evento_ShouldFailIfTipoEventoIsNegativeOrZero(string titulo, string descricao, DateTime dataHoraInicio, DateTime dataHoraFim, string local, int tipoEventoID, int usuarioID, string imagemUrl)
        {
            Assert.True(true); 
            Assert.Throws<DomainValidationException>(() =>
            {
                var acount = new EventoEntity(titulo, descricao ,dataHoraInicio, dataHoraFim, local, tipoEventoID, usuarioID, imagemUrl);
            });
        }
    #endregion

    #region </Usuario>
        [Theory]
        [InlineData(ValidTitulo, ValidDescricao, "1999-01-01", "1999-01-01", ValidLocal, ValidTipoEvento, InvalidNumber, ValidImagemUrl)]
        [InlineData(ValidTitulo, ValidDescricao, "1999-01-01", "1999-01-01", ValidLocal, ValidTipoEvento, InvalidNumberZero, ValidImagemUrl)]
        public void Evento_ShouldFailIfUsuariosNegativeOrZero(string titulo, string descricao, DateTime dataHoraInicio, DateTime dataHoraFim, string local, int tipoEventoID, int usuarioID, string imagemUrl)
        {
            Assert.True(true); 
            Assert.Throws<DomainValidationException>(() =>
            {
                var acount = new EventoEntity(titulo, descricao ,dataHoraInicio, dataHoraFim, local, tipoEventoID, usuarioID, imagemUrl);
            });
        }
    #endregion

    #region </Imagem>
        [Theory]
        [InlineData(ValidTitulo, ValidDescricao, "1999-01-01", "1999-01-01", ValidLocal, ValidTipoEvento, ValidUsuario, null)]
        [InlineData(ValidTitulo, ValidDescricao, "1999-01-01", "1999-01-01", ValidLocal, ValidTipoEvento, ValidUsuario, "")]
        [InlineData(ValidTitulo, ValidDescricao, "1999-01-01", "1999-01-01", ValidLocal, ValidTipoEvento, ValidUsuario, " ")]
        public void Evento_ShouldFailIfImagemIsNullOrEmptyOrWhiteSpace(string titulo, string descricao, DateTime dataHoraInicio, DateTime dataHoraFim, string local, int tipoEventoID, int usuarioID, string imagemUrl)
        {
            Assert.True(true); 
            Assert.Throws<DomainValidationException>(() =>
            {
                var acount = new EventoEntity(titulo, descricao ,dataHoraInicio, dataHoraFim, local, tipoEventoID, usuarioID, imagemUrl);
            });
        }
    #endregion

    #region <Lenght>
        [Fact]
        public void Evento_ShouldFailIfFieldsHaveInvalidLength()
        {
            var titulo = new string('A', 100);
            var local = new string('A', 10);
            var descricao = new string('A', 10);
            var imagemUrl = new string('A', 10);

            var evento = new EventoEntity(titulo, descricao, DateTime.Now, DateTime.Now, local, 1, 1, imagemUrl);

            Assert.Equal(100, evento.Titulo.Length);
            Assert.Equal(10, evento.Local.Length);
            Assert.Equal(10, evento.Descricao.Length);
            Assert.Equal(10, evento.ImagemUrl.Length);
        }
    #endregion

        #region </Criar>
        [Theory]
        [InlineData(ValidTitulo, ValidDescricao, "1999-01-01", "1999-01-01", ValidLocal, ValidTipoEvento, ValidUsuario, ValidImagemUrl)]
        public void Evento_ShouldCreate(string titulo, string descricao, DateTime dataHoraInicio, DateTime dataHoraFim, string local, int tipoEventoID, int usuarioID,  string imagemUrl)
        {
            var acount = new EventoEntity(titulo, descricao ,dataHoraInicio, dataHoraFim, local, tipoEventoID, usuarioID, imagemUrl);
            Assert.NotNull(acount);
        }
    #endregion

}
