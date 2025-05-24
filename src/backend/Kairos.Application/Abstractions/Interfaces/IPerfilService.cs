namespace Kairos.Application.Abstractions.Interfaces;
public interface IPerfilService
{
    Task<Result<List<GetPerfilsResponse>>> GetHandler(CancellationToken token);
    Task<Result<GetPerfilByIdResponse>> GetByIdHandler(GetPerfilByIdCommand command, CancellationToken token);
    Task<Result<List<SearchPerfilResponse>>> SearchHendler(SearchPerfilCommand command, CancellationToken token);
}
