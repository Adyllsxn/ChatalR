#region </System>
    global using System.Globalization;
    global using System.Text;
    global using System.Text.Json.Serialization;
    global using System.Security.Claims;
    global using System.ComponentModel.DataAnnotations;
#endregion

#region </Microsoft>
    global using Microsoft.OpenApi.Models;
    global using Microsoft.AspNetCore.Authentication.JwtBearer;
    global using Microsoft.IdentityModel.Tokens;
    global using Microsoft.AspNetCore.Mvc;
    global using Microsoft.AspNetCore.Authorization;
#endregion

#region </Presentation>
    global using Kairos.Presentation.Core.Extensions;
    global using Kairos.Presentation.Core.Extensions.Architecture;
    global using Kairos.Presentation.Core.Configurations;
    global using Kairos.Presentation.Features.Usuario.Model;
#endregion

#region </Infrastructure>
    global using Kairos.Infrastructure.Abstractions.DI;
#endregion

#region </Application>
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
#endregion

#region </Domain>
    global using Kairos.Domain.Abstrations.Authentication;
#endregion