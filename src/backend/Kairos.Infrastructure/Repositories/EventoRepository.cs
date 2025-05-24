namespace Kairos.Infrastructure.Repositories;
public class EventoRepository(AppDbContext context) : IEventoRepository
{
    #region </Create>
        public async Task<Result<EventoEntity>> CreateAsync(EventoEntity entity, CancellationToken token)
        {
            try
            {
                if(entity == null)
                {
                    return new Result<EventoEntity>(
                        null, 
                        400, 
                        "Parâmetros não podem estar vazio."
                        );
                }
                await context.Eventos.AddAsync(entity, token);
                return new Result<EventoEntity>(
                    entity, 
                    201, 
                    "Operação executada com sucesso."
                    );
            }
            catch (Exception ex)
            {
                return new Result<EventoEntity>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (CRIAR). Erro {ex.Message}."
                    );
            }
        }
    #endregion

    #region </Delete>
        public async Task<Result<bool>> DeleteAsync(int entityId, CancellationToken token)
        {
            try
            {
                if (entityId <= 0)
                {
                    return new Result<bool>(
                        false, 
                        400, 
                        "ID deve ser maior que zero."
                        );
                }
                var response = await context.Eventos.FirstOrDefaultAsync(x => x.Id == entityId, token);
                if (response == null)
                {
                    return new Result<bool>(
                        false, 
                        404, 
                        "ID não encontrado."
                        );
                }
                context.Eventos.Remove(response);
                return new Result<bool>(
                    true, 
                    200, 
                    "Operação executada com sucesso."
                    );
            }
            catch (Exception ex)
            {
                return new Result<bool>(
                    false, 
                    500, 
                    $"Erro ao executar a operação (DELETAR). Erro {ex.Message}."
                    );
            }
        }
    #endregion

    #region </GetAll>
        public async Task<PagedList<List<EventoEntity>?>> GetAllAsync(PagedRequest request, CancellationToken token)
        {
            try
            {
                var query = context.Eventos.AsNoTracking().AsQueryable();

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
                    null, 
                    500, 
                    $"Erro ao executar a operação (GET ALL). Erro {ex.Message}."
                    );
            }
        }
    #endregion

    #region </GetById>
        public async Task<Result<EventoEntity?>> GetByIdAsync(int entityId, CancellationToken token)
        {
            try
            {
                if(entityId <= 0)
                {
                    return new Result<EventoEntity?>(
                        null, 
                        400, 
                        "ID deve ser maior que zero."
                        );
                }
                var response = await context.Eventos.FirstOrDefaultAsync(x => x.Id == entityId, token);
                if(response == null)
                {
                    return new Result<EventoEntity?>(
                        null, 
                        404, 
                        "ID não encontrado."
                        );
                }
                return new Result<EventoEntity?>(
                    response, 
                    200, 
                    "Dados encontrado."
                    );
            }
            catch (Exception ex)
            {
                return new Result<EventoEntity?>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (GET BY ID). Erro {ex.Message}."
                    );
            }
        }
    #endregion

    #region </GetFile>
        public async Task<Result<EventoEntity?>> GetFileAsync(int entityId, CancellationToken token)
        {
            try
            {
                if(entityId <= 0)
                {
                    return new Result<EventoEntity?>(
                        null, 
                        400, 
                        "ID deve ser maior que zero."
                        );
                }
                var response = await context.Eventos.FirstOrDefaultAsync(x => x.Id == entityId, token);
                if(response == null)
                {
                    return new Result<EventoEntity?>(
                        null, 
                        404, 
                        "ID não encontrado."
                        );
                }
                return new Result<EventoEntity?>(
                    response, 
                    200, 
                    "Dados encontrado."
                    );
            }
            catch (Exception ex)
            {
                return new Result<EventoEntity?>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (GET BY ID). Erro {ex.Message}."
                    );
            }
        }
    #endregion

    #region </Search>
        public async Task<Result<List<EventoEntity>?>> SearchAsync(Expression<Func<EventoEntity, bool>> expression, string entity, CancellationToken token)
        {
            try
            {
                if(entity == null)
                {
                    return new Result<List<EventoEntity>?>(
                        null, 
                        400, 
                        "Parâmetros não podem estar vazio."
                        );
                }
                var response = await context.Eventos.Where(expression).ToListAsync(token);
                if(response == null || response.Count == 0)
                {
                    return new Result<List<EventoEntity>?>(
                        null, 
                        404, 
                        "Nenhum dado encontrado."
                        );
                }

                return new Result<List<EventoEntity>?>(
                    response, 
                    200, 
                    "Dados encontrado."
                    );
            }
            catch (Exception ex)
            {
                return new Result<List<EventoEntity>?>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (SEARCH). Erro {ex.Message}."
                    );
            }
        }
    #endregion

    #region </Update>
        public async Task<Result<EventoEntity>> UpdateAsync(EventoEntity entity, CancellationToken token)
        {
            try
            {
                if(entity == null)
                {
                    return new Result<EventoEntity>(
                        null, 
                        400, 
                        "Parâmetros não podem estar vazio."
                        );
                }
                var response = await context.Eventos.FindAsync(entity.Id);
                if(response == null)
                {
                    return new Result<EventoEntity>(
                        null, 
                        404, 
                        "ID não encontrado."
                        );
                }
                context.Entry(response).CurrentValues.SetValues(entity);
                return new Result<EventoEntity>(
                    response, 
                    200, 
                    "Operação executada com sucesso."
                    );
            }
            catch (Exception ex)
            {
                return new Result<EventoEntity>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (UPDATE). Erro {ex.Message}."
                    );
            }
        }
    #endregion
}
