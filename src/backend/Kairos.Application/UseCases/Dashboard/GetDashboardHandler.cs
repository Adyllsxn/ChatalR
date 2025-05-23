namespace Kairos.Application.UseCases.Dashboard;
public class GetDashboardHandler(IDashboardRepository repository)
{
    public async Task<GetDashboardResponse> GetHandler(CancellationToken token)
    {
        var response = await repository.GetQtdItems(token);
        var result = response.MapToGetDashboard();
        return result;
    }
}