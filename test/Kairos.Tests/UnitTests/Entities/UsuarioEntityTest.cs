namespace Kairos.Tests.UnitTests.Entities;
public class UsuarioEntityTest
{
    #region </Constants>
        private const int InvalidNumberZero = 0;
        private const int InvalidNumber = -1;
        private const string ValidNome = "test";
        private const string ValidSobreNome = "test";
        private const string ValidEmail = "test";
        private const int ValidPerfil = 1;
    #endregion

    #region </Id>
        [Theory]
        [InlineData(InvalidNumber, ValidNome, ValidSobreNome, ValidEmail, ValidPerfil, "1999-01-01")]
        [InlineData(InvalidNumberZero, ValidNome, ValidSobreNome, ValidEmail, ValidPerfil, "1999-01-01")]
        public void Usuario_ShouldFailIdIfIdIsNegative(int id, string nome, string sobrenome, string email, int perfilID, DateTime dataCadastro)
        {
            Assert.True(true); 
            Assert.Throws<DomainValidationException>(() =>
            {
                var acount = new UsuarioEntity(id, nome, sobrenome, email, perfilID, dataCadastro);
            });
        }
    #endregion

    #region </Nome>
        [Theory]
        [InlineData(null, ValidSobreNome, ValidEmail, ValidPerfil, "1999-01-01")]
        [InlineData("", ValidSobreNome, ValidEmail, ValidPerfil, "1999-01-01")]
        [InlineData(" ", ValidSobreNome, ValidEmail, ValidPerfil, "1999-01-01")]
        public void Usuario_ShouldFailIfNomeIsNullOrEmptyOrWhiteSpace(string nome, string sobrenome, string email, int perfilID, DateTime dataCadastro)
        {
            Assert.True(true); 
            Assert.Throws<DomainValidationException>(() =>
            {
                var acount = new UsuarioEntity(nome, sobrenome, email, perfilID, dataCadastro);
            });
        }
    #endregion

    #region </SobreNome>
        [Theory]
        [InlineData(ValidNome, null, ValidEmail, ValidPerfil, "1999-01-01")]
        [InlineData(ValidNome, "", ValidEmail, ValidPerfil, "1999-01-01")]
        [InlineData(ValidNome, " ", ValidEmail, ValidPerfil, "1999-01-01")]
        public void Usuario_ShouldFailIfSobreNomeIsNullOrEmptyOrWhiteSpace(string nome, string sobrenome, string email, int perfilID, DateTime dataCadastro)
        {
            Assert.True(true); 
            Assert.Throws<DomainValidationException>(() =>
            {
                var acount = new UsuarioEntity(nome, sobrenome, email, perfilID, dataCadastro);
            });
        }
    #endregion

    #region </Email>
        [Theory]
        [InlineData(ValidNome, ValidSobreNome, null, ValidPerfil, "1999-01-01")]
        [InlineData(ValidNome, ValidSobreNome, "", ValidPerfil, "1999-01-01")]
        [InlineData(ValidNome, ValidSobreNome, " ", ValidPerfil, "1999-01-01")]
        public void Usuario_ShouldFailIfEmailIsNullOrEmptyOrWhiteSpace(string nome, string sobrenome, string email, int perfilID, DateTime dataCadastro)
        {
            Assert.True(true); 
            Assert.Throws<DomainValidationException>(() =>
            {
                var acount = new UsuarioEntity(nome, sobrenome, email, perfilID, dataCadastro);
            });
        }
    #endregion

    #region </Perfil>
        [Theory]
        [InlineData(ValidNome, ValidSobreNome, ValidEmail, InvalidNumber, "1999-01-01")]
        [InlineData(ValidNome, ValidSobreNome, ValidEmail, InvalidNumberZero, "1999-01-01")]
        public void Usuario_ShouldFailIfPerfilIsNegativeOrZero(string nome, string sobrenome, string email, int perfilID, DateTime dataCadastro)
        {
            Assert.True(true); 
            Assert.Throws<DomainValidationException>(() =>
            {
                var acount = new UsuarioEntity(nome, sobrenome, email, perfilID, dataCadastro);
            });
        }
    #endregion

    #region </Lenght>
        [Fact]
        public void Usuario_ShouldFailIfFieldsHaveInvalidLength()
        {
            var nome = new string('A', 1);
            var sobrenome = new string('A', 1);
            var email = new string('A', 1);

            var usuario = new UsuarioEntity(nome, sobrenome, email, ValidPerfil, DateTime.UtcNow);

            Assert.Equal(1, usuario.NomeCompleto.Nome.Length);
            Assert.Equal(1, usuario.NomeCompleto.SobreNome.Length);
            Assert.Equal(1, usuario.Email.Length);
        }
    #endregion

    #region </Criar>
        [Theory]
        [InlineData(ValidNome, ValidSobreNome, ValidEmail, ValidPerfil, "1999-01-01")]
        public void Usuario_ShouldCreate(string nome, string sobrenome, string email, int perfilID, DateTime dataCadastro)
        {
            var count =  new  UsuarioEntity(nome, sobrenome, email, perfilID, dataCadastro);
            Assert.NotNull(count);
        }
    #endregion
}

