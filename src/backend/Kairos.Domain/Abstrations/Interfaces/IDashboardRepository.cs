namespace Kairos.Domain.Abstrations.Interfaces;
public interface IDashboardRepository
{
    Task<DashboardEntity> GetQtdItems(CancellationToken token);
}
