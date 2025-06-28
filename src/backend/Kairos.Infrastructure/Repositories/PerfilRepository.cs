namespace Kairos.Infrastructure.Repositories;
public class PerfilRepository(AppDbContext context) : IPerfilRepository
{
    #region GetAll
        public async Task<QueryResult<List<PerfilEntity>?>> GetAllAsync(CancellationToken token)
        {
            try
                {
                    var response = await context.Perfils.AsNoTracking().ToListAsync(token);
                    if (response == null || response.Count == 0)
                    {
                        return new QueryResult<List<PerfilEntity>?>(
                            null, 
                            404, 
                            "Nenhum dado encontrado."
                            );
                    }

                    return new QueryResult<List<PerfilEntity>?>(
                        response, 
                        200, 
                        "Dados.");
                }
                catch (Exception ex)
                {
                    return new QueryResult<List<PerfilEntity>?>(
                        null, 
                        500, 
                        $"Erro ao executar a operação (GET ALL). Erro {ex.Message}."
                        );
                }

        }
    #endregion

    #region GetById
        public async Task<QueryResult<PerfilEntity?>> GetByIdAsync(int entityId, CancellationToken token)
        {
            try
            {
                if(entityId <= 0)
                {
                    return new QueryResult<PerfilEntity?>(
                        null, 
                        400, 
                        "ID deve ser maior que zero."
                        );
                }
                var response = await context.Perfils.FirstOrDefaultAsync(x => x.Id == entityId, token);
                if(response == null)
                {
                    return new QueryResult<PerfilEntity?>(
                        null, 
                        404, 
                        "ID não encontrado."
                        );
                }
                return new QueryResult<PerfilEntity?>(
                    response, 
                    200, 
                    "Dados encontrado."
                    );
            }
            catch (Exception ex)
            {
                return new QueryResult<PerfilEntity?>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (GET BY ID). Erro {ex.Message}."
                    );
            }
        }
    #endregion
    
    #region Search
        public async Task<QueryResult<List<PerfilEntity>?>> SearchAsync(Expression<Func<PerfilEntity, bool>> expression, string entity, CancellationToken token)
        {
            try
            {
                if(expression == null)
                {
                    return new QueryResult<List<PerfilEntity>?>(
                        null, 
                        400, 
                        "Expressão de busca inválida."
                        );
                }
                var response = await context.Perfils.Where(expression).ToListAsync(token);
                if(response == null || response.Count == 0)
                {
                    return new QueryResult<List<PerfilEntity>?>(
                        null, 
                        404, 
                        "Nenhum dado encontrado."
                        );
                }

                return new QueryResult<List<PerfilEntity>?>(
                    response, 
                    200, 
                    "Dados encontrado."
                    );
            }
            catch (Exception ex)
            {
                return new QueryResult<List<PerfilEntity>?>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (SEARCH). Erro {ex.Message}."
                    );
            }
        }
    #endregion
    
}
