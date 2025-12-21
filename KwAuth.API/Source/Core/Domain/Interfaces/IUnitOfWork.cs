namespace KwAuth.API.Source.Core.Domain.Interfaces;
public interface IUnitOfWork
{
    Task CommitAsync(CancellationToken cancellationToken);
}
