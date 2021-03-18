using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkCore.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace DesafioTechnos
{
    public class StartupConfiguration
    {
        public StartupConfiguration(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews();
            services.AddMvcCore().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddMvcCore().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.DefaultBufferSize = 2048;
                x.JsonSerializerOptions.MaxDepth = 2048;
            });

            services.AddAuthentication(x =>
            {
                x.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = configuration["Jwt:ApiUrl"],
                    ValidIssuer = configuration["Jwt:ApiUrl"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SigningKey"])),
                };

                options.Validate(JwtBearerDefaults.AuthenticationScheme);
            });

            services.AddCors(config =>
            {
                config.DefaultPolicyName = configuration["Cors:PolicyName"];
                config.AddDefaultPolicy(cors =>
                {
                    cors.AllowAnyHeader();
                    cors.AllowAnyMethod();
                    cors.AllowAnyOrigin();
                    cors.Build();
                });
            });

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version = $"{Assembly.GetExecutingAssembly().GetName().Version.ToString()}",
                    Title = "Api da Case da technos",
                    Description = "Api de cadastro de participação do processo seletivo da technos",
                    Contact = new OpenApiContact()
                    {
                        Name = "Carlos Rodrigues Batista",
                        Email = "carlosrbatista1980@gmail.com",
                    },
                    License = new OpenApiLicense()
                    {
                        Name = "Technos",
                        Url = new Uri("https://www.grupotechnos.com.br"),
                    }
                });

                var xmlDocumentationFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), xmlDocumentationFile);
                x.IncludeXmlComments(fullPath);
            });

            services.AddDbContext<TechnosContext>();
        }
    }
}
