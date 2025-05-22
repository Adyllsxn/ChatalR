namespace Kairos.Tests.UnitTests.ValueObjets;
public class NomeCompletoTest
{
    #region </Constants>
        private const string ValidNome = "test";
        private const string ValidSobreNome = "test";
    #endregion

    #region </Criar>
        [Theory]
        [InlineData(ValidNome, ValidSobreNome)]
        public void NomeCompleto_ShouldCreate(string nome, string sobreNome)
        {
            var count = new NomeCompleto(nome, sobreNome);
            Assert.NotNull(count);
        }
    #endregion
}
