namespace Kairos.Application.UseCases.Sugestao.GetById;
public class GetSugestaoByIdHandler(ISugestaoRepository repository)
{
    public async Task<Result<GetSugestaoByIdResponse>> GetByIdHandler(GetSugestaoByIdCommand command, CancellationToken token)
    {
        try
        {
            if(command.Id <= 0)
            {
                return new Result<GetSugestaoByIdResponse>(
                    null,
                    400,
                    "ID deve ser maior que zero."
                );
            }
            var response = await repository.GetByIdAsync(command.Id, token);
            if (response.Data == null)
            {
                return new Result<GetSugestaoByIdResponse>(
                    null, 
                    404, 
                    "Nenhum dado encontrado"
                    );
            }
            var result = response.Data.MapToGetSugestaoById();
            
            return new Result<GetSugestaoByIdResponse>(
                result, 
                200, 
                "Dados encontrados"
                );
        }
        catch(Exception ex)
        {
            return new Result<GetSugestaoByIdResponse>(
                null, 
                500, 
                $"Erro ao manipular a operação (GET BY ID). Erro: {ex.Message}"
                );
        }
    }
}
