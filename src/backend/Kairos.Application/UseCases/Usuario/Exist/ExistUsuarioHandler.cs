namespace Kairos.Application.UseCases.Usuario.Exist;
public class ExistUsuarioHandler(IUsuarioRepository repository)
{
    public async Task<bool> GetIfExistHandle()
    {
        try
        {
            return await repository.GetIfExistAsync();
            
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}