namespace Kairos.Infrastructure.Repositories;
public class EventoRepository(AppDbContext context) : IEventoRepository
{
    #region GetAll
        public async Task<PagedList<List<EventoEntity>?>> GetAllAsync(PagedRequest request, CancellationToken token)
        {
            try
            {
                var query = context.Eventos.AsNoTracking().Include(x => x.Usuario).Include(x => x.TipoEvento).AsQueryable();

                var result = await query
                            .Skip((request.PageNumber - 1) * request.PageSize)
                            .Take(request.PageSize)
                            .ToListAsync();
                
                var count = await query.CountAsync();

                return new PagedList<List<EventoEntity>?>(
                    result,
                    count,
                    request.PageNumber,
                    request.PageSize
                );
            }
            catch (Exception ex)
            {
                return new PagedList<List<EventoEntity>?>(
                    data: null,  
                    message: $"Erro ao executar a operação (GET ALL). Erro {ex.Message}.",
                    code: StatusCode.InternalServerError
                    );
            }
        }
    #endregion

    #region GetById
        public async Task<QueryResult<EventoEntity?>> GetByIdAsync(int entityId, CancellationToken token)
        {
            try
            {
                if(entityId <= 0)
                {
                    return new QueryResult<EventoEntity?>(
                        data: null, 
                        message: "ID deve ser maior que zero.",
                        code: StatusCode.BadRequest
                        );
                }
                var response = await context.Eventos.Include(x => x.Usuario).Include(x => x.TipoEvento).FirstOrDefaultAsync(x => x.Id == entityId, token);
                if(response == null)
                {
                    return new QueryResult<EventoEntity?>(
                        data: null,  
                        message: "ID não encontrado.",
                        code: StatusCode.NotFound
                        );
                }
                return new QueryResult<EventoEntity?>(
                    data: response, 
                    message: "Dados encontrado.",
                    code: StatusCode.OK
                    );
            }
            catch (Exception ex)
            {
                return new QueryResult<EventoEntity?>(
                    data: null,  
                    message: $"Erro ao executar a operação (GET BY ID). Erro {ex.Message}.",
                    code: StatusCode.InternalServerError
                    );
            }
        }
    #endregion

    #region GetFile
        public async Task<QueryResult<EventoEntity?>> GetFileAsync(int entityId, CancellationToken token)
        {
            try
            {
                if(entityId <= 0)
                {
                    return new QueryResult<EventoEntity?>(
                        data: null, 
                        message: "ID deve ser maior que zero.",
                        code: StatusCode.BadRequest
                        );
                }

                var response = await context.Eventos.Include(x => x.Usuario).Include(x => x.TipoEvento).FirstOrDefaultAsync(x => x.Id == entityId, token);
                if(response == null)
                {
                    return new QueryResult<EventoEntity?>(
                        data: null,  
                        message: "ID não encontrado.",
                        code: StatusCode.NotFound
                        );
                }
                return new QueryResult<EventoEntity?>(
                    data: response, 
                    message: "Dados encontrado.",
                    code: StatusCode.OK
                    );
            }
            catch (Exception ex)
            {
                return new QueryResult<EventoEntity?>(
                    data: null, 
                    message: $"Erro ao executar a operação (GET BY ID). Erro {ex.Message}.",
                    code: StatusCode.InternalServerError
                    );
            }
        }
    #endregion

    #region GetAprovados
        public async Task<PagedList<List<EventoEntity>?>> GetEventosAprovadosAsync(PagedRequest request, CancellationToken token)
        {
            try
            {
                var query = context.Eventos
                    .AsNoTracking()
                    .Include(x => x.Usuario)
                    .Include(x => x.TipoEvento)
                    .Where(e => e.StatusAprovacao == EAprovacao.Aprovado);

                var result = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync(token);

                var count = await query.CountAsync(token);

                return new PagedList<List<EventoEntity>?>(result, count, request.PageNumber, request.PageSize);
            }
            catch (Exception ex)
            {
                return new PagedList<List<EventoEntity>?>(
                    data: null, 
                    message: $"Erro ao buscar eventos aprovados. Erro {ex.Message}.",
                    code: StatusCode.InternalServerError
                    );
            }
        }
    #endregion

    #region GetPendentes
        public async Task<PagedList<List<EventoEntity>?>> GetEventosPendentesAsync(PagedRequest request, CancellationToken token)
        {
            try
            {
                var query = context.Eventos
                    .AsNoTracking()
                    .Include(x => x.Usuario)
                    .Include(x => x.TipoEvento)
                    .Where(e => e.StatusAprovacao == EAprovacao.Pendente);

                var result = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync(token);

                var count = await query.CountAsync(token);

                return new PagedList<List<EventoEntity>?>(result, count, request.PageNumber, request.PageSize);
            }
            catch (Exception ex)
            {
                return new PagedList<List<EventoEntity>?>(
                    data: null, 
                    message: $"Erro ao buscar eventos Pendentes. Erro {ex.Message}.",
                    code: StatusCode.InternalServerError
                    );
            }
        }
    #endregion

    #region GetRejeitados
        public async Task<PagedList<List<EventoEntity>?>> GetEventosRejeitadosAsync(PagedRequest request, CancellationToken token)
        {
            try
            {
                var query = context.Eventos
                    .AsNoTracking()
                    .Include(x => x.Usuario)
                    .Include(x => x.TipoEvento)
                    .Where(e => e.StatusAprovacao == EAprovacao.Rejeitado);

                var result = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync(token);

                var count = await query.CountAsync(token);

                return new PagedList<List<EventoEntity>?>(result, count, request.PageNumber, request.PageSize);
            }
            catch (Exception ex)
            {
                return new PagedList<List<EventoEntity>?>(
                    data: null, 
                    message: $"Erro ao buscar eventos reijetado. Erro {ex.Message}.",
                    code: StatusCode.InternalServerError
                    );
            }
        }
    #endregion

    #region Search
        public async Task<QueryResult<List<EventoEntity>?>> SearchAsync(Expression<Func<EventoEntity, bool>> expression, string entity, CancellationToken token)
        {
            try
            {
                if(entity == null)
                {
                    return new QueryResult<List<EventoEntity>?>(
                        data: null, 
                        message: "Parâmetros não podem estar vazio.",
                        code: StatusCode.BadRequest
                        );
                }

                var response = await context.Eventos.Include(x => x.Usuario).Include(x => x.TipoEvento).Where(expression).ToListAsync(token);
                if(response == null || response.Count == 0)
                {
                    return new QueryResult<List<EventoEntity>?>(
                        data: null,  
                        message: "Nenhum dado encontrado.",
                        code: StatusCode.NotFound
                        );
                }

                return new QueryResult<List<EventoEntity>?>(
                    data: response,  
                    message: "Dados encontrado.",
                    code: StatusCode.OK
                    );
            }
            catch (Exception ex)
            {
                return new QueryResult<List<EventoEntity>?>(
                    data: null, 
                    message: $"Erro ao executar a operação (SEARCH). Erro {ex.Message}.",
                    code: StatusCode.InternalServerError
                    );
            }
        }
    #endregion

    #region Create
        public async Task<CommandResult<bool>> CreateAsync(EventoEntity entity, CancellationToken token)
        {
            try
            {
                if(entity == null)
                {
                    return CommandResult<bool>.Success(
                        value: true,
                        message: "Parâmetros não podem estar vazio.",
                        code: StatusCode.BadRequest
                        );
                }

                await context.Eventos.AddAsync(entity, token);
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
                    message: $"Erro ao executar a operação (CRIAR). Erro {ex.Message}.",
                    code: StatusCode.InternalServerError
                    );
            }
        }
    #endregion

    #region Update
        public async Task<CommandResult<bool>> UpdateAsync(EventoEntity entity, CancellationToken token)
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
                var response = await context.Eventos.FindAsync(entity.Id);
                if(response == null)
                {

                    return CommandResult<bool>.Failure(
                        value: false,
                        message: $"ID {entity.Id} não encontrado.",
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
                    value: false,
                    message: $"Erro ao executar a operação (EDITAR). Erro {ex.Message}.",
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
                    return CommandResult<bool>.Success(
                        value: true,
                        message: $"ID {entityId} deve ser maior que zero.",
                        code: StatusCode.NotFound
                        );
                }

                var response = await context.Eventos.FirstOrDefaultAsync(x => x.Id == entityId, token);
                if (response == null)
                {
                    return CommandResult<bool>.Success(
                        value: true,
                        message: $"ID {entityId} não encontrado.",
                        code: StatusCode.NotFound
                        );
                }
                
                context.Eventos.Remove(response);
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
