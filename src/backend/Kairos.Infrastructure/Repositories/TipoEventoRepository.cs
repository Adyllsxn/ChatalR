namespace Kairos.Infrastructure.Repositories;
public class TipoEventoRepository(AppDbContext context) : ITipoEventoRepository
{

    #region GetAll
        public async Task<PagedList<List<TipoEventoEntity>?>> GetAllAsync(PagedRequest request, CancellationToken token)
        {
            try
            {
                var query = context.TipoEventos.AsNoTracking().AsQueryable();

                var result = await query
                            .Skip((request.PageNumber - 1) * request.PageSize)
                            .Take(request.PageSize)
                            .ToListAsync();
                
                var count = await query.CountAsync();

                return new PagedList<List<TipoEventoEntity>?>(
                    result,
                    count,
                    request.PageNumber,
                    request.PageSize
                );
            }
            catch (Exception ex)
            {
                return new PagedList<List<TipoEventoEntity>?>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (GET ALL). Erro {ex.Message}."
                    );
            }
        }
    #endregion

    #region GetById
        public async Task<QueryResult<TipoEventoEntity?>> GetByIdAsync(int entityId, CancellationToken token)
        {
            try
            {
                if(entityId <= 0)
                {
                    return new QueryResult<TipoEventoEntity?>(
                        null, 
                        400, 
                        "ID deve ser maior que zero."
                        );
                }
                var response = await context.TipoEventos.FirstOrDefaultAsync(x => x.Id == entityId, token);
                if(response == null)
                {
                    return new QueryResult<TipoEventoEntity?>(
                        null, 
                        404, 
                        "ID não encontrado."
                        );
                }
                return new QueryResult<TipoEventoEntity?>(
                    response, 
                    200, 
                    "Dados encontrado."
                    );
            }
            catch (Exception ex)
            {
                return new QueryResult<TipoEventoEntity?>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (GET BY ID). Erro {ex.Message}."
                    );
            }
        }
    #endregion

    #region Search
        public async Task<QueryResult<List<TipoEventoEntity>?>> SearchAsync(Expression<Func<TipoEventoEntity, bool>> expression, string entity, CancellationToken token)
        {
            try
            {
                if(entity == null)
                {
                    return new QueryResult<List<TipoEventoEntity>?>(
                        null, 
                        400, 
                        "Parâmetros não podem estar vazio."
                        );
                }
                var response = await context.TipoEventos.Where(expression).ToListAsync(token);
                if(response == null || response.Count == 0)
                {
                    return new QueryResult<List<TipoEventoEntity>?>(
                        null, 
                        404, 
                        "Nenhum dado encontrado."
                        );
                }

                return new QueryResult<List<TipoEventoEntity>?>(
                    response, 
                    200, 
                    "Dados encontrado."
                    );
            }
            catch (Exception ex)
            {
                return new QueryResult<List<TipoEventoEntity>?>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (SEARCH). Erro {ex.Message}."
                    );
            }
        }
    #endregion

    #region Create
        public async Task<CommandResult<bool>> CreateAsync(TipoEventoEntity entity, CancellationToken token)
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
                
                await context.TipoEventos.AddAsync(entity, token);

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

    #region Update
        public async Task<QueryResult<TipoEventoEntity>> UpdateAsync(TipoEventoEntity entity, CancellationToken token)
        {
            try
            {
                if(entity == null)
                {
                    return new QueryResult<TipoEventoEntity>(
                        null, 
                        400, 
                        "Parâmetros não podem estar vazio."
                        );
                }
                var response = await context.TipoEventos.FindAsync(entity.Id);
                if(response == null)
                {
                    return new QueryResult<TipoEventoEntity>(
                        null, 
                        404, 
                        "ID não encontrado."
                        );
                }
                context.Entry(response).CurrentValues.SetValues(entity);
                return new QueryResult<TipoEventoEntity>(
                    response, 
                    200, 
                    "Operação executada com sucesso."
                    );
            }
            catch (Exception ex)
            {
                return new QueryResult<TipoEventoEntity>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (UPDATE). Erro {ex.Message}."
                    );
            }
        }
    #endregion

    #region Delete
        public async Task<QueryResult<bool>> DeleteAsync(int entityId, CancellationToken token)
        {
            try
            {
                if (entityId <= 0)
                {
                    return new QueryResult<bool>(
                        false, 
                        400, 
                        "ID deve ser maior que zero."
                        );
                }
                var response = await context.TipoEventos.FirstOrDefaultAsync(x => x.Id == entityId, token);
                if (response == null)
                {
                    return new QueryResult<bool>(
                        false, 
                        404, 
                        "ID não encontrado."
                        );
                }
                context.TipoEventos.Remove(response);
                return new QueryResult<bool>(
                    true, 
                    200, 
                    "Operação executada com sucesso."
                    );
            }
            catch (Exception ex)
            {
                return new QueryResult<bool>(
                    false, 
                    500, 
                    $"Erro ao executar a operação (DELETAR). Erro {ex.Message}."
                    );
            }
        }
    #endregion

}
