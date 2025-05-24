namespace Kairos.Application.UseCases.Usuario.GetById;
public class GetUsuarioByIdHandler(IUsuarioRepository repository)
{
    public async Task<Result<GetUsuarioByIdResponse>> GetByIdHandler(GetUsuarioByIdCommand command, CancellationToken token)
    {
        try
        {
            if(command.Id <= 0)
            {
                return new Result<GetUsuarioByIdResponse>(
                    null,
                    400,
                    "ID deve ser maior que zero."
                );
            }
            var response = await repository.GetByIdAsync(command.Id, token);
            if (response.Data == null)
            {
                return new Result<GetUsuarioByIdResponse>(
                    null, 
                    404, 
                    "Nenhum dado encontrado"
                    );
            }
            var result = response.Data.MapToGetUsuarioById();
            
            return new Result<GetUsuarioByIdResponse>(
                result, 
                200, 
                "Dados encontrados"
                );
        }
        catch(Exception ex)
        {
            return new Result<GetUsuarioByIdResponse>(
                null, 
                500, 
                $"Erro ao manipular a operação (GET BY ID). Erro: {ex.Message}"
                );
        }
    }
}