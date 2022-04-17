using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoLogistica.Models;
using GestaoLogistica.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.Swagger;

namespace GestaoLogistica
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<AppDbContext>(options =>
      {
        options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
      });
      services.AddScoped<IMercadoriaRepository, MercadoriaRepository>();
      services.AddScoped<IUsuarioRepository, UsuarioRepository>();
      services.AddScoped<IDepositoRepository, DepositoRepository>();
      services.AddScoped<IEntregaRepository, EntregaRepository>();
      services.AddScoped<IPerfilRepository, PerfilRepository>();
      services.AddControllers();
      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
      {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidAudience = Configuration["Jwt:Audience"],
          ValidIssuer = Configuration["Jwt:Issuer"],
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
        };
      });
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo() { Title = "GslAPI", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseStatusCodePages();
        app.UseDeveloperExceptionPage();
      }

      app.UseCors(builder => builder.WithOrigins("http://localhost:8100", "https://gsl-puc.herokuapp.com").AllowAnyHeader());

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthentication();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });

      //Ativa o Swagger
      app.UseSwagger();

      // Ativa o Swagger UI
      app.UseSwaggerUI(opt =>
      {
        opt.SwaggerEndpoint("/swagger/v1/swagger.json", "GslAPI V1");
      });            
    }
  }
}
