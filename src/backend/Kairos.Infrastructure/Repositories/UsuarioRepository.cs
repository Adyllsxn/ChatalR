namespace Kairos.Infrastructure.Repositories;
public class UsuarioRepository(AppDbContext context) : IUsuarioRepository
{
    #region GetAll
        public async Task<PagedList<List<UsuarioEntity>?>> GetAllAsync(PagedRequest request, CancellationToken token)
        {
            try
            {
                var query = context.Usuarios.Where( x => x.IsActive == true).Include(x => x.Perfil).AsNoTracking().AsQueryable();

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

    #region GetFoto
        public async Task<QueryResult<UsuarioEntity?>> GetFotoAsync(int entityId, CancellationToken token)
        {
            try
            {
                if(entityId <= 0)
                {
                    return new QueryResult<UsuarioEntity?>(
                        null, 
                        400, 
                        "ID deve ser maior que zero."
                        );
                }
                var response = await context.Usuarios.AsNoTracking().FirstOrDefaultAsync(x => x.Id == entityId, token);
                if(response == null)
                {
                    return new QueryResult<UsuarioEntity?>(
                        null, 
                        404, 
                        "ID não encontrado."
                        );
                }
                return new QueryResult<UsuarioEntity?>(
                    response, 
                    200, 
                    "Dados encontrado."
                    );
            }
            catch (Exception ex)
            {
                return new QueryResult<UsuarioEntity?>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (GET BY ID). Erro {ex.Message}."
                    );
            }
        }
    #endregion

    #region GetById
        public async Task<QueryResult<UsuarioEntity?>> GetByIdAsync(int entityId, CancellationToken token)
        {
            try
            {
                if(entityId <= 0)
                {
                    return new QueryResult<UsuarioEntity?>(
                        null, 
                        400, 
                        "ID deve ser maior que zero."
                        );
                }
                var response = await context.Usuarios.Where( x => x.IsActive == true).Include(x => x.Perfil).FirstOrDefaultAsync( x => x.Id == entityId, token);
                if(response == null)
                {
                    return new QueryResult<UsuarioEntity?>(
                        null, 
                        404, 
                        "ID não encontrado."
                        );
                }
                return new QueryResult<UsuarioEntity?>(
                    response, 
                    200, 
                    "Dados encontrado."
                    );
            }
            catch (Exception ex)
            {
                return new QueryResult<UsuarioEntity?>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (GET BY ID). Erro {ex.Message}."
                    );
            }
        }
    #endregion

    #region GetExist
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
    
    #region Exist
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
    
    #region Search
        public async Task<QueryResult<List<UsuarioEntity>?>> SearchAsync(Expression<Func<UsuarioEntity, bool>> expression, string entity, CancellationToken token)
        {
            try
            {
                if(entity == null)
                {
                    return new QueryResult<List<UsuarioEntity>?>(
                        null, 
                        400, 
                        "Parâmetros não podem estar vazio."
                        );
                }
                var response = await context.Usuarios.Where( x => x.IsActive == true).Include(x => x.Perfil).Where(expression).ToListAsync(token);
                if(response == null || response.Count == 0)
                {
                    return new QueryResult<List<UsuarioEntity>?>(
                        null, 
                        404, 
                        "Nenhum dado encontrado."
                        );
                }

                return new QueryResult<List<UsuarioEntity>?>(
                    response, 
                    200, 
                    "Dados encontrado."
                    );
            }
            catch (Exception ex)
            {
                return new QueryResult<List<UsuarioEntity>?>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (SEARCH). Erro {ex.Message}."
                    );
            }
        }
    #endregion

    #region Create
        public async Task<CommandResult<bool>> CreateAsync(UsuarioEntity entity, CancellationToken token)
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
                
                await context.Usuarios.AddAsync(entity, token);
                return CommandResult<bool>.Failure(
                    value: false,
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
        public async Task<CommandResult<bool>> UpdateAsync(UsuarioEntity entity, CancellationToken token)
        {
            try
            {
                if(entity == null)
                {
                    return CommandResult<bool>.Failure(
                        value: false,
                        message: "Parâmetros não podem estar vazio.",
                        code: StatusCode.NoContent
                        );
                }
                var response = await context.Usuarios.FindAsync(entity.Id);
                if(response == null)
                {
                    return CommandResult<bool>.Failure(
                        value: false,
                        message: $"ID {entity.Id} não encontrado.",
                        code: StatusCode.NoContent
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

    #region UpdatePassword
        public async Task<CommandResult<bool>> UpdatePasswordAsync(int usuarioId, byte[] newHash, byte[] newSalt, CancellationToken token)
        {
            try
            {
                var usuario = await context.Usuarios.FindAsync(usuarioId);
                if (usuario == null)
                {
                    return CommandResult<bool>.Failure(
                        value: false,
                        message: $"Usuário {usuarioId} não encontrado.",
                        code: StatusCode.NoContent
                        );
                }

                usuario.UpdatePassword(newHash, newSalt);
                context.Usuarios.Update(usuario);

                await context.SaveChangesAsync(token);
                return CommandResult<bool>.Success(
                    value: true,
                    message: "Senha atualizada com sucesso.",
                    code: StatusCode.NoContent
                    );
                
            }
            catch (Exception ex)
            {
                return CommandResult<bool>.Failure(
                    value: false,
                    message: $"Erro ao executar a operação (SENHA). Erro {ex.Message}.",
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
                var response = await context.Usuarios.FirstOrDefaultAsync( x => x.Id == entityId, token);
                if (response == null)
                {
                    return CommandResult<bool>.Failure(
                        value: false,
                        message: $"ID {entityId} não encontrado.",
                        code: StatusCode.NotFound
                        );
                }

                response.Deactivate();
                context.Usuarios.Update(response);
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
