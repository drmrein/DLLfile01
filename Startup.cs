// Decompiled with JetBrains decompiler
// Type: MARKETPLACE_API.Startup
// Assembly: MKT_MARKETPLACE_API, Version=1.0.2021.1123, Culture=neutral, PublicKeyToken=null
// MVID: 93D50DA4-6CA8-48FC-BB2E-094D58575827
// Assembly location: C:\Users\Darma\Downloads\Object Deployment\Object Deployment\PCR\API\Maindealer-Api\MKT_MARKETPLACE_API.dll

using MARKETPLACE_API.Interfaces;
using MARKETPLACE_API.Models;
using MARKETPLACE_API.Providers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using MKT_MARKETPLACE_API.Interfaces;
using MKT_MARKETPLACE_API.Providers;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace MARKETPLACE_API
{
  public class Startup
  {
    public Startup(IConfiguration configuration) => this.Configuration = configuration;

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      MvcServiceCollectionExtensions.AddControllers(services);
      ServiceCollectionServiceExtensions.AddTransient<IDbConnection>(services, (Func<IServiceProvider, IDbConnection>) (sp => (IDbConnection) new SqlConnection(ConfigurationExtensions.GetConnectionString(this.Configuration, "DefaultConnection"))));
      AuthenticationServiceCollectionExtensions.AddAuthentication(services, "Bearer").AddJwtBearer((Action<JwtBearerOptions>) (options => options.TokenValidationParameters = new TokenValidationParameters()
      {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = (SecurityKey) new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Configuration["Jwt:Key"]))
      }));
      ServiceCollectionServiceExtensions.AddScoped<IMarketplaceCustAcquisitionProvider, MarketplaceCustAcquisitionProvider>(services);
      ServiceCollectionServiceExtensions.AddScoped<ISftpServiceProvider, SftpServiceProvider>(services);
      ServiceCollectionServiceExtensions.AddScoped<IGetResponseMessageProvider, GetResponseMessageProvider>(services);
      ServiceCollectionServiceExtensions.AddScoped<IValidateExpiresProvider, ValidateExpiresProvider>(services);
      ServiceCollectionServiceExtensions.AddScoped<IMarketplaceStatusCheckProvider, MarketplaceStatusCheckProvider>(services);
      ServiceCollectionServiceExtensions.AddScoped<IAuthenticationProsesProvider, AuthenticationProsesProvider>(services);
      ServiceCollectionServiceExtensions.AddScoped<IAddUserLoginProvider, AddUserLoginProvider>(services);
      ServiceCollectionServiceExtensions.AddScoped<IMaindealerStatusCheckProvider, MaindealerStatusCheckProvider>(services);
      ServiceCollectionServiceExtensions.AddScoped<IInsertLogApiProvider, InsertLogApiProvider>(services);
      ServiceCollectionServiceExtensions.AddScoped<IMaindealerCustAcquisitionProvider, MaindealerCustAcquisitionProvider>(services);
      ServiceCollectionServiceExtensions.AddScoped<IUpdateDataProvider, UpdateDataProvider>(services);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (HostEnvironmentEnvExtensions.IsDevelopment((IHostEnvironment) env))
        DeveloperExceptionPageExtensions.UseDeveloperExceptionPage(app);
      HttpsPolicyBuilderExtensions.UseHttpsRedirection(app);
      EndpointRoutingApplicationBuilderExtensions.UseRouting(app);
      AuthAppBuilderExtensions.UseAuthentication(app);
      AuthorizationAppBuilderExtensions.UseAuthorization(app);
      EndpointRoutingApplicationBuilderExtensions.UseEndpoints(app, (Action<IEndpointRouteBuilder>) (endpoints => ControllerEndpointRouteBuilderExtensions.MapControllers(endpoints)));
    }
  }
}
