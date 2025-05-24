namespace Kairos.Infrastructure.Repositories;
public class PerfilRepository(AppDbContext context) : IPerfilRepository
{
    #region </Create>
        public async Task<Result<PerfilEntity>> CreateAsync(PerfilEntity entity, CancellationToken token)
        {
            try
            {
                if(entity == null)
                {
                    return new Result<PerfilEntity>(
                        null, 
                        400, 
                        "Parâmetros não podem estar vazio."
                        );
                }
                await context.Perfils.AddAsync(entity, token);
                return new Result<PerfilEntity>(
                    entity, 
                    201, 
                    "Operação executada com sucesso."
                    );
            }
            catch (Exception ex)
            {
                return new Result<PerfilEntity>(
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
                var response = await context.Perfils.FirstOrDefaultAsync(x => x.Id == entityId, token);
                if (response == null)
                {
                    return new Result<bool>(
                        false, 
                        404, 
                        "ID não encontrado."
                        );
                }
                context.Perfils.Remove(response);
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
        public async Task<Result<List<PerfilEntity>?>> GetAllAsync(CancellationToken token)
        {
            try
                {
                    var response = await context.Perfils.AsNoTracking().ToListAsync(token);
                    if (response == null || response.Count == 0)
                    {
                        return new Result<List<PerfilEntity>?>(
                            null, 
                            404, 
                            "Nenhum dado encontrado."
                            );
                    }

                    return new Result<List<PerfilEntity>?>(
                        response, 
                        200, 
                        "Dados.");
                }
                catch (Exception ex)
                {
                    return new Result<List<PerfilEntity>?>(
                        null, 
                        500, 
                        $"Erro ao executar a operação (GET ALL). Erro {ex.Message}."
                        );
                }

        }
    #endregion

    #region </GetById>
        public async Task<Result<PerfilEntity?>> GetByIdAsync(int entityId, CancellationToken token)
        {
            try
            {
                if(entityId <= 0)
                {
                    return new Result<PerfilEntity?>(
                        null, 
                        400, 
                        "ID deve ser maior que zero."
                        );
                }
                var response = await context.Perfils.FirstOrDefaultAsync(x => x.Id == entityId, token);
                if(response == null)
                {
                    return new Result<PerfilEntity?>(
                        null, 
                        404, 
                        "ID não encontrado."
                        );
                }
                return new Result<PerfilEntity?>(
                    response, 
                    200, 
                    "Dados encontrado."
                    );
            }
            catch (Exception ex)
            {
                return new Result<PerfilEntity?>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (GET BY ID). Erro {ex.Message}."
                    );
            }
        }
    #endregion
    
    #region </Search>
        public async Task<Result<List<PerfilEntity>?>> SearchAsync(Expression<Func<PerfilEntity, bool>> expression, string entity, CancellationToken token)
        {
            try
            {
                if(expression == null)
                {
                    return new Result<List<PerfilEntity>?>(
                        null, 
                        400, 
                        "Expressão de busca inválida."
                        );
                }
                var response = await context.Perfils.Where(expression).ToListAsync(token);
                if(response == null || response.Count == 0)
                {
                    return new Result<List<PerfilEntity>?>(
                        null, 
                        404, 
                        "Nenhum dado encontrado."
                        );
                }

                return new Result<List<PerfilEntity>?>(
                    response, 
                    200, 
                    "Dados encontrado."
                    );
            }
            catch (Exception ex)
            {
                return new Result<List<PerfilEntity>?>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (SEARCH). Erro {ex.Message}."
                    );
            }
        }
    #endregion

    #region </Update>
        public async Task<Result<PerfilEntity>> UpdateAsync(PerfilEntity entity, CancellationToken token)
        {
            try
            {
                if(entity == null)
                {
                    return new Result<PerfilEntity>(
                        null, 
                        400, 
                        "Parâmetros não podem estar vazio."
                        );
                }
                var response = await context.Perfils.FindAsync(entity.Id);
                if(response == null)
                {
                    return new Result<PerfilEntity>(
                        null, 
                        404, 
                        "ID não encontrado."
                        );
                }
                context.Entry(response).CurrentValues.SetValues(entity);
                return new Result<PerfilEntity>(
                    response, 
                    200, 
                    "Operação executada com sucesso."
                    );
            }
            catch (Exception ex)
            {
                return new Result<PerfilEntity>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (UPDATE). Erro {ex.Message}."
                    );
            }
        }
    #endregion
}
