namespace Kairos.Infrastructure.Repositories;
public class SugestaoRepository(AppDbContext context) : ISugestaoRepository
{
    #region </Create>
        public async Task<Result<SugestaoEntity>> CreateAsync(SugestaoEntity entity, CancellationToken token)
        {
            try
            {
                if(entity == null)
                {
                    return new Result<SugestaoEntity>(
                        null, 
                        400, 
                        "Parâmetros não podem estar vazio."
                        );
                }
                await context.Sugestoes.AddAsync(entity, token);
                return new Result<SugestaoEntity>(
                    entity, 
                    201, 
                    "Operação executada com sucesso."
                    );
            }
            catch (Exception ex)
            {
                return new Result<SugestaoEntity>(
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
                var response = await context.Sugestoes.FirstOrDefaultAsync(x => x.Id == entityId, token);
                if (response == null)
                {
                    return new Result<bool>(
                        false, 
                        404, 
                        "ID não encontrado."
                        );
                }
                context.Sugestoes.Remove(response);
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

    #region </GetAllUnread>
        public async Task<PagedList<List<SugestaoEntity>?>> GetAllUnreadAsync(PagedRequest request, CancellationToken token)
        {
            try
            {
                var query = context.Sugestoes.Where(x => x.StatusSugestao == EStatusSugestao.Nova).AsNoTracking().AsQueryable();

                var result = await query
                            .Skip((request.PageNumber - 1) * request.PageSize)
                            .Take(request.PageSize)
                            .ToListAsync();
                
                var count = await query.CountAsync();

                return new PagedList<List<SugestaoEntity>?>(
                    result,
                    count,
                    request.PageNumber,
                    request.PageSize
                );
            }
            catch (Exception ex)
            {
                return new PagedList<List<SugestaoEntity>?>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (GET ALL). Erro {ex.Message}."
                    );
            }
        }
    #endregion

    #region </GetAllRead>
        public async Task<PagedList<List<SugestaoEntity>?>> GetAllReadAsync(PagedRequest request, CancellationToken token)
        {
            try
            {
                var query = context.Sugestoes.Where(x => x.StatusSugestao == EStatusSugestao.Lida ).AsNoTracking().AsQueryable();

                var result = await query
                            .Skip((request.PageNumber - 1) * request.PageSize)
                            .Take(request.PageSize)
                            .ToListAsync();
                
                var count = await query.CountAsync();

                return new PagedList<List<SugestaoEntity>?>(
                    result,
                    count,
                    request.PageNumber,
                    request.PageSize
                );
            }
            catch (Exception ex)
            {
                return new PagedList<List<SugestaoEntity>?>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (GET ALL). Erro {ex.Message}."
                    );
            }
        }
    #endregion
    
    #region </GellAll>
        public async Task<PagedList<List<SugestaoEntity>?>> GetAllAsync(PagedRequest request, CancellationToken token)
        {
            try
            {
                var query = context.Sugestoes.AsNoTracking().AsQueryable();

                var result = await query
                            .Skip((request.PageNumber - 1) * request.PageSize)
                            .Take(request.PageSize)
                            .ToListAsync();
                
                var count = await query.CountAsync();

                return new PagedList<List<SugestaoEntity>?>(
                    result,
                    count,
                    request.PageNumber,
                    request.PageSize
                );
            }
            catch (Exception ex)
            {
                return new PagedList<List<SugestaoEntity>?>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (GET ALL). Erro {ex.Message}."
                    );
            }
        }
    #endregion

    #region </GetById>
        public async Task<Result<SugestaoEntity?>> GetByIdAsync(int entityId, CancellationToken token)
        {
            try
            {
                if(entityId <= 0)
                {
                    return new Result<SugestaoEntity?>(
                        null, 
                        400, 
                        "ID deve ser maior que zero."
                        );
                }
                var response = await context.Sugestoes.FirstOrDefaultAsync(x => x.Id == entityId, token);
                if(response == null)
                {
                    return new Result<SugestaoEntity?>(
                        null, 
                        404, 
                        "ID não encontrado."
                        );
                }
                return new Result<SugestaoEntity?>(
                    response, 
                    200, 
                    "Dados encontrado."
                    );
            }
            catch (Exception ex)
            {
                return new Result<SugestaoEntity?>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (GET BY ID). Erro {ex.Message}."
                    );
            }
        }
    #endregion

    #region </Update>
    public async Task<Result<SugestaoEntity>> UpdateAsync(SugestaoEntity entity, CancellationToken token)
        {
            try
            {
                if(entity == null)
                {
                    return new Result<SugestaoEntity>(
                        null, 
                        400, 
                        "Parâmetros não podem estar vazio."
                        );
                }
                var response = await context.Sugestoes.FindAsync(entity.Id);
                if(response == null)
                {
                    return new Result<SugestaoEntity>(
                        null, 
                        404, 
                        "ID não encontrado."
                        );
                }
                context.Entry(response).CurrentValues.SetValues(entity);
                return new Result<SugestaoEntity>(
                    response, 
                    200, 
                    "Operação executada com sucesso."
                    );
            }
            catch (Exception ex)
            {
                return new Result<SugestaoEntity>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (UPDATE). Erro {ex.Message}."
                    );
            }
        }
    #endregion

    #region </MarkAsRead>
        public async Task<Result<bool>> MarkAsReadAsync(int id, CancellationToken token)
        {
            var sugestao = await context.Sugestoes.FirstOrDefaultAsync(s => s.Id == id, token);
            if (sugestao is null)
                return Result<bool>.Failure("Sugestão não encontrada.");

            try
            {
                sugestao.MarcarComoLida();
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure(ex.Message);
            }
        }
    #endregion
}
