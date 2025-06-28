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
                            data: null, 
                            message: "Nenhum perfil encontrado.",
                            code: StatusCode.NotFound
                            );
                    }

                    return new QueryResult<List<PerfilEntity>?>(
                        data: response, 
                        message: "Perfis recuperados com sucesso.",
                        code: StatusCode.OK
                        );
                }
                catch (Exception ex)
                {
                    return new QueryResult<List<PerfilEntity>?>(
                        data: null,
                        message: $"Erro ao executar a operação (GET ALL). Erro {ex.Message}.",
                        code: StatusCode.InternalServerError
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
                        data: null, 
                        message: $"ID {entityId} deve ser maior que zero.",
                        code: StatusCode.BadRequest
                        );
                }

                var response = await context.Perfils.FirstOrDefaultAsync(x => x.Id == entityId, token);
                if(response == null)
                {
                    return new QueryResult<PerfilEntity?>(
                        data: null, 
                        message: "Perfil não encontrado.",
                        code: StatusCode.NotFound
                        );
                }
                
                return new QueryResult<PerfilEntity?>(
                    data: response, 
                    message: "Perfil encontrado com sucesso.",
                    code: StatusCode.OK
                    );
            }
            catch (Exception ex)
            {
                return new QueryResult<PerfilEntity?>(
                    data:null,  
                    message: $"Erro ao executar a operação (GET BY ID). Erro {ex.Message}.",
                    code: StatusCode.InternalServerError
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
                        data: null, 
                        message:"Expressão de busca inválida.",
                        code: StatusCode.BadRequest
                        );
                }

                var response = await context.Perfils.Where(expression).ToListAsync(token);
                if(response == null || response.Count == 0)
                {
                    return new QueryResult<List<PerfilEntity>?>(
                        data: null, 
                        message: $"Nenhum {entity.ToLower()} encontrado.",
                        StatusCode.NotFound
                        );
                }

                return new QueryResult<List<PerfilEntity>?>(
                    data: response, 
                    message: $"{entity} encontrado(s) com sucesso.",
                    code: StatusCode.OK
                    );
            }
            catch (Exception ex)
            {
                return new QueryResult<List<PerfilEntity>?>(
                    data: null, 
                    message: $"Erro ao executar a operação (SEARCH). Erro {ex.Message}."
                    );
            }
        }
    #endregion
    
}
