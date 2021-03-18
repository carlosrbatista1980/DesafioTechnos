using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace DesafioTechnos
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
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
                options.SaveToken = true;
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = Configuration["Jwt:ApiUrl"],
                    ValidIssuer = Configuration["Jwt:ApiUrl"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SigningKey"])),
                };

                options.Validate(JwtBearerDefaults.AuthenticationScheme);
            });

            services.AddCors(config =>
            {
                config.DefaultPolicyName = Configuration["Cors:PolicyName"];
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

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseRouting();
            app.UseCors(Configuration["Cors:PolicyName"]);
            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            
            app.UseSwaggerUI(swagger =>
            {
                //swagger.ConfigObject.DocExpansion = DocExpansion.List;
                swagger.DocumentTitle = "Case de teste da Techno";
                swagger.SwaggerEndpoint("../swagger/v1/swagger.json", "v1");
                //swagger.RoutePrefix = string.Empty;
            });
        }
    }
}
