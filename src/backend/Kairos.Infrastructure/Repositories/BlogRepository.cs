namespace Kairos.Infrastructure.Repositories;
public class BlogRepository(AppDbContext context) : IBlogRepository
{
    #region GetAll
        public async Task<PagedList<List<BlogEntity>?>> GetAllAsync(PagedRequest request, CancellationToken token)
        {
            try
            {
                var query = context.Blogs.AsNoTracking().Include(x => x.Usuario).AsQueryable();

                var result = await query
                            .Skip((request.PageNumber - 1) * request.PageSize)
                            .Take(request.PageSize)
                            .ToListAsync();
                
                var count = await query.CountAsync();

                return new PagedList<List<BlogEntity>?>(
                    result,
                    count,
                    request.PageNumber,
                    request.PageSize
                );
            }
            catch (Exception ex)
            {
                return new PagedList<List<BlogEntity>?>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (GET ALL). Erro {ex.Message}."
                    );
            }
        }
    #endregion

    #region GetById
        public async Task<QueryResult<BlogEntity?>> GetByIdAsync(int entityId, CancellationToken token)
        {
            try
            {
                if(entityId <= 0)
                {
                    return new QueryResult<BlogEntity?>(
                        null, 
                        400, 
                        "ID deve ser maior que zero."
                        );
                }
                var response = await context.Blogs.Include(x => x.Usuario).FirstOrDefaultAsync(x => x.Id == entityId, token);
                if(response == null)
                {
                    return new QueryResult<BlogEntity?>(
                        null, 
                        404, 
                        "ID não encontrado."
                        );
                }
                return new QueryResult<BlogEntity?>(
                    response, 
                    200, 
                    "Dados encontrado."
                    );
            }
            catch (Exception ex)
            {
                return new QueryResult<BlogEntity?>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (GET BY ID). Erro {ex.Message}."
                    );
            }
        }
    #endregion

    #region GetFile
        public async Task<QueryResult<BlogEntity?>> GetFileAsync(int entityId, CancellationToken token)
        {
            try
            {
                if(entityId <= 0)
                {
                    return new QueryResult<BlogEntity?>(
                        null, 
                        400, 
                        "ID deve ser maior que zero."
                        );
                }
                var response = await context.Blogs.Include(x => x.Usuario).FirstOrDefaultAsync(x => x.Id == entityId, token);
                if(response == null)
                {
                    return new QueryResult<BlogEntity?>(
                        null, 
                        404, 
                        "ID não encontrado."
                        );
                }
                return new QueryResult<BlogEntity?>(
                    response, 
                    200, 
                    "Dados encontrado."
                    );
            }
            catch (Exception ex)
            {
                return new QueryResult<BlogEntity?>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (GET BY ID). Erro {ex.Message}."
                    );
            }
        }
    #endregion

    #region GetPublish
        public async Task<PagedList<List<BlogEntity>?>> GetAllPublishAsync(PagedRequest request, CancellationToken token)
        {
            try
            {
                var query = context.Blogs
                                    .AsNoTracking()
                                    .Where(x => x.Status == EBlog.Publicado)
                                    .Include(x => x.Usuario)
                                    .AsQueryable();

                var result = await query
                            .Skip((request.PageNumber - 1) * request.PageSize)
                            .Take(request.PageSize)
                            .ToListAsync();
                
                var count = await query.CountAsync();

                return new PagedList<List<BlogEntity>?>(
                    result,
                    count,
                    request.PageNumber,
                    request.PageSize
                );
            }
            catch (Exception ex)
            {
                return new PagedList<List<BlogEntity>?>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (GET ALL). Erro {ex.Message}."
                    );
            }
        }
    #endregion

    #region Search
        public async Task<QueryResult<List<BlogEntity>?>> SearchAsync(Expression<Func<BlogEntity, bool>> expression, string entity, CancellationToken token)
        {
            try
            {
                if(entity == null)
                {
                    return new QueryResult<List<BlogEntity>?>(
                        null, 
                        400, 
                        "Parâmetros não podem estar vazio."
                        );
                }
                var response = await context.Blogs.Include(x => x.Usuario).Where(expression).ToListAsync(token);
                if(response == null || response.Count == 0)
                {
                    return new QueryResult<List<BlogEntity>?>(
                        null, 
                        404, 
                        "Nenhum dado encontrado."
                        );
                }

                return new QueryResult<List<BlogEntity>?>(
                    response, 
                    200, 
                    "Dados encontrado."
                    );
            }
            catch (Exception ex)
            {
                return new QueryResult<List<BlogEntity>?>(
                    null, 
                    500, 
                    $"Erro ao executar a operação (SEARCH). Erro {ex.Message}."
                    );
            }
        }
    #endregion

    #region Create
        public async Task<CommandResult<bool>> CreateAsync(BlogEntity entity, CancellationToken token)
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
                await context.Blogs.AddAsync(entity, token);
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
        public async Task<CommandResult<bool>> UpdateAsync(BlogEntity entity, CancellationToken token)
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

                var response = await context.Blogs.FindAsync(entity.Id);
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
                    code: StatusCode.NotFound
                    );
            }
            catch (Exception ex)
            {
                return CommandResult<bool>.Failure(
                    value: false,
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
                var response = await context.Blogs.FirstOrDefaultAsync(x => x.Id == entityId, token);
                if (response == null)
                {
                    return CommandResult<bool>.Failure(
                        value: false,
                        message: $"ID {entityId} não encontrado.",
                        code: StatusCode.NoContent
                        );
                }

                context.Blogs.Remove(response);
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
