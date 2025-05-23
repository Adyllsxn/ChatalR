namespace Kairos.Application.Services;
public class DashboardService(GetDashboardHandler get) : IDashboardService
{
    public async Task<GetDashboardResponse> GetHandler(CancellationToken token)
    {
        return await get.GetHandler(token);
    }
}
