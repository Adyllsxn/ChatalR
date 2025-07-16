#region System
    global using System.Globalization;
    global using System.Text;
    global using System.Text.Json;
    global using System.Text.Json.Serialization;
    global using System.Security.Claims;
    global using System.ComponentModel.DataAnnotations;
#endregion

#region Microsoft
    global using Microsoft.OpenApi.Models;
    global using Microsoft.AspNetCore.Authentication.JwtBearer;
    global using Microsoft.IdentityModel.Tokens;
    global using Microsoft.AspNetCore.Mvc;
    global using Microsoft.AspNetCore.Authorization;
    global using Microsoft.Extensions.FileProviders;
#endregion

#region Domain
    global using Kairos.Domain.Abstrations.Auth;
#endregion

#region Infrastructure
    global using Kairos.Infrastructure.Abstractions.DI;
#endregion

#region Application
    global using Kairos.Application.UseCases.Usuario.GetFoto;
    global using Kairos.Application.UseCases.Usuario.Status;
    global using Kairos.Application.UseCases.Usuario.Update;
    global using Kairos.Application.UseCases.Usuario.UpdateFoto;

    global using Kairos.Application.UseCases.Blog.Archive;
    global using Kairos.Application.UseCases.Blog.Create;
    global using Kairos.Application.UseCases.Blog.Delete;
    global using Kairos.Application.UseCases.Blog.GetAll;
    global using Kairos.Application.UseCases.Blog.GetById;
    global using Kairos.Application.UseCases.Blog.GetFile;
    global using Kairos.Application.UseCases.Blog.GetPublish;
    global using Kairos.Application.UseCases.Blog.Publish;
    global using Kairos.Application.UseCases.Blog.Search;
    global using Kairos.Application.UseCases.Blog.Update;

    global using Kairos.Application.Abstractions.DI;
    global using Kairos.Application.Abstractions.Interfaces;

    global using Kairos.Application.UseCases.TipoEvento.GetAll;
    global using Kairos.Application.UseCases.TipoEvento.Create;
    global using Kairos.Application.UseCases.TipoEvento.Delete;
    global using Kairos.Application.UseCases.TipoEvento.GetById;
    global using Kairos.Application.UseCases.TipoEvento.Search;
    global using Kairos.Application.UseCases.TipoEvento.Update;

    global using Kairos.Application.UseCases.Perfil.GetById;
    global using Kairos.Application.UseCases.Perfil.Search;
    
    global using Kairos.Application.UseCases.Usuario.Create;
    global using Kairos.Application.UseCases.Usuario.GetById;
    global using Kairos.Application.UseCases.Usuario.Delete;
    global using Kairos.Application.UseCases.Usuario.GetAll;
    global using Kairos.Application.UseCases.Usuario.Search;

    global using Kairos.Application.UseCases.Evento.Create;
    global using Kairos.Application.UseCases.Evento.GetFile;
    global using Kairos.Application.UseCases.Evento.GetAll;
    global using Kairos.Application.UseCases.Evento.GetById;
    global using Kairos.Application.UseCases.Evento.Search;
    global using Kairos.Application.UseCases.Evento.Update;
    global using Kairos.Application.UseCases.Evento.Status;
    global using Kairos.Application.UseCases.Evento.Delete;

    global using Kairos.Application.UseCases.Presenca.Create;
    global using Kairos.Application.UseCases.Presenca.Delete;
    global using Kairos.Application.UseCases.Presenca.GetAll;
    global using Kairos.Application.UseCases.Presenca.GetById;
    global using Kairos.Application.UseCases.Presenca.Search;
    
#endregion

#region Presentation
    global using Kairos.Presentation.Source.Core.Constants;
    global using Kairos.Presentation.Source.Setup.Extensions;
    global using Kairos.Presentation.Source.Setup.Pipeline; 
    global using Kairos.Presentation.Source.Setup.Configurations;
    global using Kairos.Presentation.Source.Core.FileLogger;
#endregion