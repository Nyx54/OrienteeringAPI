using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OrienteeringAPI.Data;
using OrienteeringAPI.Data.Base;
using OrienteeringAPI.Repositories;
using OrienteeringAPI.Repositories.Base;
using OrienteeringAPI.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrienteeringAPI
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
            services.AddSingleton<OrienteeringAPIContextFactory>();
            services.AddSingleton<ITokenProvider, TokenProvider>();

            services.AddSingleton<ILogRepository, LogRepository>();

            #region Repositories

            services.AddScoped<LeagueRepository>();
            services.AddScoped<TeamRepository>();
            services.AddScoped<UserRepository>();

            #endregion

            #region Services

            services.AddScoped<LeagueService>();
            services.AddScoped<TeamService>();
            services.AddScoped<UserService>();

            #endregion

            services.AddControllers();

            #region token

            var appSettingsSection = Configuration.GetSection("AppSettings");
            var keyByteArray = Encoding.ASCII.GetBytes(appSettingsSection.GetValue<string>("Secret"));
            var signinKey = new SymmetricSecurityKey(keyByteArray);
            var myIssuer = appSettingsSection.GetValue<string>("Issuer");
            var myAudience = appSettingsSection.GetValue<string>("Audience");

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                var tokenParameters = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.FromMinutes(5),
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidIssuer = myIssuer,
                    ValidAudience = myAudience,
                    IssuerSigningKey = signinKey,
                    SaveSigninToken = true
                };
                options.TokenValidationParameters = tokenParameters;
            });

            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            #region Swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger Orienteering API", Version = "v1" });
#if !DEBUG
                c.DocumentFilter<SwaggerDocumentFilter>();
#endif
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description =
                            "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });

            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger mCentre API v1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
