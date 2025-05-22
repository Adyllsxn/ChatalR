namespace Kairos.Infrastructure.Repositories;
public class DashBoardRepository(AppDbContext context) : IDashboardRepository
{
    public async Task<DashboardEntity> GetQtdItems(CancellationToken token)
    {
        DashboardEntity entity =  new  DashboardEntity();
        entity.QtdPerfil = await context.Perfils.CountAsync(token);
        entity.QtdEvento = await context.Eventos.CountAsync(token);
        entity.QtdPresenca = await context.Presencas.CountAsync(token);
        entity.QtdSugestao = await context.Sugestoes.CountAsync(token);
        entity.QtdTipoEvento = await context.TipoEventos.CountAsync(token);
        entity.QtdUsuario = await context.Usuarios.CountAsync(token);
        return entity;
    }
}
