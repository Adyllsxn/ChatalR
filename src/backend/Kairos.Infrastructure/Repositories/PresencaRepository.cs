namespace Kairos.Infrastructure.Repositories;
public class PresencaRepository(AppDbContext context) : IPresencaRepository
{
    #region GetAll
        public async Task<PagedList<List<PresencaEntity>?>> GetAllAsync(PagedRequest request, CancellationToken token)
        {
            try
            {
                var query = context.Presencas.AsNoTracking().AsQueryable();

                var result = await query
                            .Skip((request.PageNumber - 1) * request.PageSize)
                            .Take(request.PageSize)
                            .ToListAsync();
                
                var count = await query.CountAsync();

                return new PagedList<List<PresencaEntity>?>(
                    result,
                    count,
                    request.PageNumber,
                    request.PageSize
                );
            }
            catch (Exception ex)
            {
                return new PagedList<List<PresencaEntity>?>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (GET ALL). Erro {ex.Message}."
                    );
            }
        }
    #endregion

    #region GetById
        public async Task<QueryResult<PresencaEntity?>> GetByIdAsync(int entityId, CancellationToken token)
        {
            try
            {
                if(entityId <= 0)
                {
                    return new QueryResult<PresencaEntity?>(
                        null, 
                        400, 
                        "ID deve ser maior que zero."
                        );
                }
                var response = await context.Presencas.FirstOrDefaultAsync(x => x.Id == entityId, token);
                if(response == null)
                {
                    return new QueryResult<PresencaEntity?>(
                        null, 
                        404, 
                        "ID não encontrado."
                        );
                }
                return new QueryResult<PresencaEntity?>(
                    response, 
                    200, 
                    "Dados encontrado."
                    );
            }
            catch (Exception ex)
            {
                return new QueryResult<PresencaEntity?>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (GET BY ID). Erro {ex.Message}."
                    );
            }
        }
    #endregion
    
    #region Create
        public async Task<CommandResult<bool>> CreateAsync(PresencaEntity entity, CancellationToken token)
        {
            try
            {
                if(entity == null)
                {
                    return CommandResult<bool>.Failure(
                        value: false,
                        message: "Parâmetros não podem estar vazio.",
                        code: StatusCode.BadRequest
                        );
                }

                await context.Presencas.AddAsync(entity, token);
                return CommandResult<bool>.Success(
                    value: true,
                    message: "Operação executada com sucesso.",
                    code: StatusCode.Created
                    );
            }
            catch (Exception ex)
            {
                return CommandResult<bool>.Failure(
                    value: false,
                    message: $"Erro ao executar a operação (CRIAR). Erro {ex.Message}.",
                    code: StatusCode.InternalServerError
                    );
            }
        }
    #endregion

    #region Delete
        public async Task<CommandResult<bool>> DeleteAsync(int entityId, CancellationToken token)
        {
            try
            {
                if (entityId <= 0)
                {
                    return CommandResult<bool>.Failure(
                        value: false,
                        message: $"ID {entityId} deve ser maior que zero.",
                        code: StatusCode.BadRequest
                        );
                }
                var response = await context.Presencas.FirstOrDefaultAsync(x => x.Id == entityId, token);
                if (response == null)
                {
                    return CommandResult<bool>.Failure(
                        value: false,
                        message: $"ID {entityId} não encontrado.",
                        code: StatusCode.NotFound
                        );
                }

                context.Presencas.Remove(response);
                return CommandResult<bool>.Success(
                    value: true,
                    message: "Operação executada com sucesso.",
                    code: StatusCode.NoContent
                    );
            }
            catch (Exception ex)
            {
                return CommandResult<bool>.Failure(
                    value: false,
                    message: $"Erro ao executar a operação (EXCLUIR). Erro {ex.Message}.",
                    code: StatusCode.InternalServerError
                    );
            }
        }
    #endregion

}
