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
                    data: null, 
                    message: $"Erro ao executar a operação (GET ALL). Erro {ex.Message}.",
                    code: StatusCode.InternalServerError
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
                        data: null,  
                        message: "ID deve ser maior que zero.",
                        code: StatusCode.BadRequest
                        );
                }
                var response = await context.TipoEventos.FirstOrDefaultAsync(x => x.Id == entityId, token);
                if(response == null)
                {
                    return new QueryResult<TipoEventoEntity?>(
                        data: null,
                        message: "ID não encontrado.",
                        code: StatusCode.NotFound
                        );
                }
                return new QueryResult<TipoEventoEntity?>(
                    data: response,
                    message: "Dados encontrado.",
                    code: StatusCode.OK
                    );
            }
            catch (Exception ex)
            {
                return new QueryResult<TipoEventoEntity?>(
                    data: null, 
                    message: $"Erro ao executar a operação (GET BY ID). Erro {ex.Message}.",
                    code: StatusCode.InternalServerError
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
                        data: null,  
                        message: "Parâmetros não podem estar vazio.",
                        code: StatusCode.BadRequest
                        );
                }
                var response = await context.TipoEventos.Where(expression).ToListAsync(token);
                if(response == null || response.Count == 0)
                {
                    return new QueryResult<List<TipoEventoEntity>?>(
                        data: null, 
                        message: "Nenhum dado encontrado.",
                        code: StatusCode.NotFound
                        );
                }

                return new QueryResult<List<TipoEventoEntity>?>(
                    data: response, 
                    message:"Dados encontrado.",
                    code: StatusCode.OK
                    );
            }
            catch (Exception ex)
            {
                return new QueryResult<List<TipoEventoEntity>?>(
                    data: null, 
                    message: $"Erro ao executar a operação (SEARCH). Erro {ex.Message}.",
                    code: StatusCode.InternalServerError
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
        public async Task<CommandResult<bool>> UpdateAsync(TipoEventoEntity entity, CancellationToken token)
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

                var response = await context.TipoEventos.FindAsync(entity.Id);
                if(response == null)
                {
                    return CommandResult<bool>.Failure(
                        value: false,
                        message: $"ID {entity.Id} não encontrado",
                        code: StatusCode.NotFound
                        );
                }

                context.Entry(response).CurrentValues.SetValues(entity);
                return CommandResult<bool>.Success(
                        value: true,
                        message: "Operação executada com sucesso.",
                        code: StatusCode.NoContent
                        );
            }
            catch (Exception ex)
            {
                return CommandResult<bool>.Failure(
                    value: true,
                    message: $"Erro ao executar a operação (UPDATE). Erro {ex.Message}.",
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

                var response = await context.TipoEventos.FirstOrDefaultAsync(x => x.Id == entityId, token);
                if (response == null)
                {
                    return CommandResult<bool>.Failure(
                        value: false,
                        message: $"ID {entityId} não encontrado",
                        code: StatusCode.NotFound
                        );
                }
                
                context.TipoEventos.Remove(response);
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
                    message: $"Erro ao executar a operação (DELETAR). Erro {ex.Message}.",
                    code: StatusCode.InternalServerError
                    ); 
            }
        }
    #endregion

}
