namespace Kairos.Application.UseCases.TipoEvento.GetById;
public class GetTipoEventoByIdHandler(ITipoEventoRepository repository)
{
    public async Task<Result<GetTipoEventoByIdResponse>> GetByIdHandler(GetTipoEventoByIdCommand command, CancellationToken token)
    {
        try
        {
            if(command.Id <= 0)
            {
                return new Result<GetTipoEventoByIdResponse>(
                    null,
                    400,
                    "ID deve ser maior que zero."
                );
            }
            var response = await repository.GetByIdAsync(command.Id, token);
            if (response.Data == null)
            {
                return new Result<GetTipoEventoByIdResponse>(
                    null, 
                    404, 
                    "Nenhum dado encontrado"
                    );
            }
            var result = response.Data.MapToTipoEventoById();
            
            return new Result<GetTipoEventoByIdResponse>(
                result, 
                200, 
                "Dados encontrados"
                );
        }
        catch(Exception ex)
        {
            return new Result<GetTipoEventoByIdResponse>(
                null, 
                500, 
                $"Erro ao manipular a operação (GET BY ID). Erro: {ex.Message}"
                );
        }
    }
}
