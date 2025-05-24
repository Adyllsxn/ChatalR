namespace Kairos.Infrastructure.Repositories;
public class UsuarioRepository(AppDbContext context) : IUsuarioRepository
{
    #region </Create>
        public async Task<Result<UsuarioEntity>> CreateAsync(UsuarioEntity entity, CancellationToken token)
        {
            try
            {
                if(entity == null)
                {
                    return new Result<UsuarioEntity>(
                        null, 
                        400, 
                        "Parâmetros não podem estar vazio."
                        );
                }
                await context.Usuarios.AddAsync(entity, token);
                return new Result<UsuarioEntity>(
                    entity, 
                    201, 
                    "Operação executada com sucesso."
                    );
            }
            catch (Exception ex)
            {
                return new Result<UsuarioEntity>(
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
                var response = await context.Usuarios.FirstOrDefaultAsync( x => x.Id == entityId, token);
                if (response == null)
                {
                    return new Result<bool>(
                        false, 
                        404, 
                        "ID não encontrado."
                        );
                }
                response.Deactivate();
                context.Usuarios.Update(response);
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

    #region </Exist>
        public async Task<bool> GetIfExistAsync()
        {
            try
            {
                return  await context.Usuarios.AnyAsync();
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    #endregion
    
    #region </GetAll>
        public async Task<PagedList<List<UsuarioEntity>?>> GetAllAsync(PagedRequest request, CancellationToken token)
        {
            try
            {
                var query = context.Usuarios.Where( x => x.IsActive == true).AsNoTracking().AsQueryable();

                var result = await query
                            .Skip((request.PageNumber - 1) * request.PageSize)
                            .Take(request.PageSize)
                            .ToListAsync();
                
                var count = await query.CountAsync();

                return new PagedList<List<UsuarioEntity>?>(
                    result,
                    count,
                    request.PageNumber,
                    request.PageSize
                );
            }
            catch (Exception ex)
            {
                return new PagedList<List<UsuarioEntity>?>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (GET ALL). Erro {ex.Message}."
                    );
            }
        }
    #endregion

    #region </GetById>
        public async Task<Result<UsuarioEntity?>> GetByIdAsync(int entityId, CancellationToken token)
        {
            try
            {
                if(entityId <= 0)
                {
                    return new Result<UsuarioEntity?>(
                        null, 
                        400, 
                        "ID deve ser maior que zero."
                        );
                }
                var response = await context.Usuarios.Where( x => x.IsActive == true).FirstOrDefaultAsync( x => x.Id == entityId, token);
                if(response == null)
                {
                    return new Result<UsuarioEntity?>(
                        null, 
                        404, 
                        "ID não encontrado."
                        );
                }
                return new Result<UsuarioEntity?>(
                    response, 
                    200, 
                    "Dados encontrado."
                    );
            }
            catch (Exception ex)
            {
                return new Result<UsuarioEntity?>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (GET BY ID). Erro {ex.Message}."
                    );
            }
        }
    #endregion

    #region </GetExist>
        public async Task<bool> GetIfUserExistAsync()
        {
            try
            {
                return await context.Usuarios.AnyAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    #endregion

    #region </Search>
        public async Task<Result<List<UsuarioEntity>?>> SearchAsync(Expression<Func<UsuarioEntity, bool>> expression, string entity, CancellationToken token)
        {
            try
            {
                if(entity == null)
                {
                    return new Result<List<UsuarioEntity>?>(
                        null, 
                        400, 
                        "Parâmetros não podem estar vazio."
                        );
                }
                var response = await context.Usuarios.Where( x => x.IsActive == true).Where(expression).ToListAsync(token);
                if(response == null || response.Count == 0)
                {
                    return new Result<List<UsuarioEntity>?>(
                        null, 
                        404, 
                        "Nenhum dado encontrado."
                        );
                }

                return new Result<List<UsuarioEntity>?>(
                    response, 
                    200, 
                    "Dados encontrado."
                    );
            }
            catch (Exception ex)
            {
                return new Result<List<UsuarioEntity>?>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (SEARCH). Erro {ex.Message}."
                    );
            }
        }
    #endregion

    #region </Update>
        public async Task<Result<UsuarioEntity>> UpdateAsync(UsuarioEntity entity, CancellationToken token)
        {
            try
            {
                if(entity == null)
                {
                    return new Result<UsuarioEntity>(
                        null, 
                        400, 
                        "Parâmetros não podem estar vazio."
                        );
                }
                var response = await context.Usuarios.FindAsync(entity.Id);
                if(response == null)
                {
                    return new Result<UsuarioEntity>(
                        null, 
                        404, 
                        "ID não encontrado."
                        );
                }
                context.Entry(response).CurrentValues.SetValues(entity);
                return new Result<UsuarioEntity>(
                    response, 
                    200, 
                    "Operação executada com sucesso."
                    );
            }
            catch (Exception ex)
            {
                return new Result<UsuarioEntity>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (UPDATE). Erro {ex.Message}."
                    );
            }
        }
    #endregion
}
