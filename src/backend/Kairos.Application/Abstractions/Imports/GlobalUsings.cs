#region </System>
    global using System.ComponentModel.DataAnnotations;
    global using System.ComponentModel.DataAnnotations.Schema;
    global using System.Text.Json.Serialization;
    global using System.Security.Cryptography;
    global using System.Text;
#endregion

#region </Microsoft>
    global using Microsoft.Extensions.DependencyInjection;
#endregion

#region </Domain>
    global using Kairos.Domain.Abstrations.Pagination;
    global using Kairos.Domain.Abstrations.Interfaces;
    global using Kairos.Domain.Abstrations.Shared;
    global using Kairos.Domain.Abstrations.Enums;
    global using Kairos.Domain.Abstrations.Exceptions;
    global using Kairos.Domain.Entities;
#endregion

#region </Application>
    global using Kairos.Application.Abstractions.DI.Architecture;
    global using Kairos.Application.Abstractions.Response;
    global using Kairos.Application.Abstractions.Interfaces;
    global using Kairos.Application.Abstractions.ExtensionsMethods.TipoEvento;
    global using Kairos.Application.Abstractions.ExtensionsMethods.Dashboard;
    global using Kairos.Application.Abstractions.ExtensionsMethods.Perfil;
    global using Kairos.Application.Abstractions.ExtensionsMethods.Usuario;
    global using Kairos.Application.Abstractions.ExtensionsMethods.Evento;
    global using Kairos.Application.Abstractions.ExtensionsMethods.Presenca;
    global using Kairos.Application.Abstractions.ExtensionsMethods.Sugestao;
    global using Kairos.Application.Services;
    
    global using Kairos.Application.UseCases.Dashboard;

    global using Kairos.Application.UseCases.TipoEvento.Create;
    global using Kairos.Application.UseCases.TipoEvento.Delete;
    global using Kairos.Application.UseCases.TipoEvento.GetAll;
    global using Kairos.Application.UseCases.TipoEvento.GetById;
    global using Kairos.Application.UseCases.TipoEvento.Search;
    global using Kairos.Application.UseCases.TipoEvento.Update;

    global using Kairos.Application.UseCases.Perfil.GetAll;
    global using Kairos.Application.UseCases.Perfil.GetById;
    global using Kairos.Application.UseCases.Perfil.Search;

    global using Kairos.Application.UseCases.Usuario.Create;
    global using Kairos.Application.UseCases.Usuario.GetById;
    global using Kairos.Application.UseCases.Usuario.GetAll;
    global using Kairos.Application.UseCases.Usuario.Search;
    global using Kairos.Application.UseCases.Usuario.Delete;
    global using Kairos.Application.UseCases.Usuario.Exist;
    global using Kairos.Application.UseCases.Usuario.Status;
    global using Kairos.Application.UseCases.Usuario.Update;

    global using Kairos.Application.UseCases.Evento.Create;
    global using Kairos.Application.UseCases.Evento.GetFile;
    global using Kairos.Application.UseCases.Evento.GetAll;
    global using Kairos.Application.UseCases.Evento.Delete;
    global using Kairos.Application.UseCases.Evento.GetById;
    global using Kairos.Application.UseCases.Evento.Search;
    global using Kairos.Application.UseCases.Evento.Update;
    global using Kairos.Application.UseCases.Evento.Status;
    global using Kairos.Application.UseCases.Evento.GetAprovado;
    global using Kairos.Application.UseCases.Evento.GetPendente;
    global using Kairos.Application.UseCases.Evento.GetReijetado;

    global using Kairos.Application.UseCases.Presenca.Create;
    global using Kairos.Application.UseCases.Presenca.Delete;
    global using Kairos.Application.UseCases.Presenca.GetAll;
    global using Kairos.Application.UseCases.Presenca.GetById;

    global using Kairos.Application.UseCases.Sugestao.Create;
    global using Kairos.Application.UseCases.Sugestao.Delete;
    global using Kairos.Application.UseCases.Sugestao.GetAll;
    global using Kairos.Application.UseCases.Sugestao.GetById;
    global using Kairos.Application.UseCases.Sugestao.Update;
    global using Kairos.Application.UseCases.Sugestao.GetRead;
    global using Kairos.Application.UseCases.Sugestao.GetUnRead;
    global using Kairos.Application.UseCases.Sugestao.MarkAsRead;
#endregion
