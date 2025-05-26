#region </System>
    global using System.Linq.Expressions;
    global using System.Text;
    global using System.IdentityModel.Tokens.Jwt;
    global using System.Security.Cryptography;
    global using System.Security.Claims;
#endregion

#region </Microsoft>
    global using Microsoft.EntityFrameworkCore;
    global using Microsoft.Extensions.Configuration;
    global using Microsoft.Extensions.DependencyInjection;
    global using Microsoft.EntityFrameworkCore.Metadata.Builders;
    global using Microsoft.IdentityModel.Tokens;
#endregion

#region </Domain>
    global using Kairos.Domain.Entities;
    global using Kairos.Domain.Abstrations.Interfaces;
    global using Kairos.Domain.Abstrations.Authentication;
    global using Kairos.Domain.Abstrations.Pagination;
    global using Kairos.Domain.Abstrations.Shared;
    global using Kairos.Domain.Abstrations.Enums;
#endregion

#region </Infrastructure>
    global using Kairos.Infrastructure.Abstractions.DI;
    global using Kairos.Infrastructure.Abstractions.Identity;
    global using Kairos.Infrastructure.Context;
    global using Kairos.Infrastructure.Context.Connections;
    global using Kairos.Infrastructure.Repositories;
#endregion


