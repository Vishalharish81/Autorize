using Autontication_learn.DependencyInjection;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;


namespace AppConfiguration
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            IConfiguration configuration = builder.Configuration;
            ConfigureServices(builder.Services, configuration);

            var app = builder.Build();

            UseMiddleware(app);

            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration )
        {
            string connString = configuration.GetConnectionString("DefaultConnection");

            services.AddScoped<IDbConnection>(sp => new SqlConnection(configuration.GetConnectionString("DefaultConnection")));

            services.depeatableProvide();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            //services.AddSwaggerGen();
            AddSwaggerSupport(configuration, services);
            JwtSupport(configuration, services);
            Hangfire(configuration, services);


        }
        
        private static void Hangfire(IConfiguration configuration, IServiceCollection services)
        {
            services.AddHangfire(configuratio =>
            {
                configuratio.UseMemoryStorage();
               
            });
        }
        private static void AddSwaggerSupport(IConfiguration  config , IServiceCollection serviceDescriptors )
        {
            serviceDescriptors.AddSwaggerGen(c =>
            {
                c.SwaggerDoc
                (
                    "v1", new OpenApiInfo
                    {
                        Title = "Harish Vishal",
                        Version = "v1",
                        Description = "API documentation for Harish Vishal project."
                    }
                );
                AddSwaggerXml(c);
                c.AddSecurityDefinition("Beared", new OpenApiSecurityScheme
                {
                    BearerFormat ="JWT",
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                     Scheme = JwtBearerDefaults.AuthenticationScheme
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = JwtBearerDefaults.AuthenticationScheme
                    }
                    },
                    new string[] { }
                                }
                            });
                c.CustomSchemaIds(type => type.ToString());
            });


       
        }
        private static void AddSwaggerXml(SwaggerGenOptions c)
        {
            var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml");
            foreach (var xmlFile in xmlFiles)
            {
                c.IncludeXmlComments(xmlFile);
            }
        }
        private static void JwtSupport(IConfiguration config, IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddAuthentication(services =>
            {
                services.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                services.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                services.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
            {
                option.RequireHttpsMetadata = false;
                option.SaveToken = true;
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = config["JwtSettings:Issuer"],
                    ValidAudience = config["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:SecretKey"]!)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });
        }
        private static void UseMiddleware(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
           
            app.UseEndpoints(end =>
            {
                end.MapControllers();
            });
            app.UseHangfireDashboard();

        }
    }
}
