#region </System>
    global using System.ComponentModel.DataAnnotations;
#endregion

#region </Microsoft>
    global using Microsoft.Extensions.DependencyInjection;
#endregion

#region </Domain>
    global using Kairos.Domain.Abstrations.Pagination;
    global using Kairos.Domain.Abstrations.Interfaces;
    global using Kairos.Domain.Abstrations.Shared;
    global using Kairos.Domain.Entities;
#endregion

#region </Application>
    global using Kairos.Application.Abstractions.DI.Architecture;
    global using Kairos.Application.Abstractions.Response;
    global using Kairos.Application.Abstractions.Interfaces;
    global using Kairos.Application.Abstractions.ExtensionsMethods.TipoEvento;
    global using Kairos.Application.Abstractions.ExtensionsMethods.Dashboard;
    global using Kairos.Application.Services;
    
    global using Kairos.Application.UseCases.Dashboard;

    global using Kairos.Application.UseCases.TipoEvento.Create;
    global using Kairos.Application.UseCases.TipoEvento.GetAll;
    global using Kairos.Application.UseCases.TipoEvento.GetById;
    global using Kairos.Application.UseCases.TipoEvento.Search;
    global using Kairos.Application.UseCases.TipoEvento.Update;
#endregion
