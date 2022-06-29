using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Auth;
using Blog.Database;
using Blog.Database.Repository;
using Blog.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
using Server.Models.Mappers;

namespace Blog
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                                .AddJwtBearer(options =>
                                {
                                    options.RequireHttpsMetadata = false;
                                    options.TokenValidationParameters = new TokenValidationParameters
                                    {
                                        ValidateIssuer = true,
                                        ValidIssuer = AuthOptions.ISSUER,
                                        ValidateAudience = true,
                                        ValidAudience = AuthOptions.AUDIENCE,
                                        ValidateLifetime = true,
                                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                                        ValidateIssuerSigningKey = true,
                                    };
                                });
            services.AddControllers();
            services.AddSwaggerGen(c =>
                    {
                        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Blog", Version = "v1" });
                    });

            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();
            });

            services.AddDbContext<BlogContext>();
            services.AddAutoMapper(typeof(Startup));

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRepository<Post>, PostRepository>();
            services.AddTransient<IRepository<User>, UserRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blog v1"));
            }

            app.UseCors(options => options.WithOrigins("http://localhost:8000", "https://localhost:8001")
                                          .AllowAnyHeader()
                                          .AllowAnyMethod()
                                          .AllowCredentials());
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
