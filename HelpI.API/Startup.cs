using HelpI.API.Domain.Persistence.Contexts;
using HelpI.API.Domain.Persistence.Repositories;
using HelpI.API.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpI.API.Application.Services.Training;
using HelpI.API.Domain.Persistence.Repositories.Security;
using HelpI.API.Infrastructure.Persistence.Repositories.Security;
using HelpI.API.Domain.Persistence.Repositories.Training;
using HelpI.API.Infrastructure.Persistence.Repositories.Training;
using HelpI.API.Infrastructure.Persistence.Repositories;
using HelpI.API.Application.Services.Security;
using HelpI.API.Domain.Persistence.Repositories.Application;
using HelpI.API.Infrastructure.Persistence.Repositories.Application;
using HelpI.API.Domain.Persistence.Repositories.Session;
using HelpI.API.Infrastructure.Persistence.Repositories.Session;
using HelpI.API.Domain.Services.Application;
using HelpI.API.Application.Services.Application;
using HelpI.API.Domain.Services.Session;
using HelpI.API.Application.Services.Session;
using HelpI.API.Games.Application;
using HelpI.API.Games.Domain.Services;

namespace HelpI.API
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

            services.AddControllers();

            // DbContext Configuration
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });

            // Dependency Injection Configuration
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IExpertRepository, ExpertRepository>();
            services.AddScoped<ITrainingMaterialRepository, TrainingMaterialRepository>();
            services.AddScoped<IPlayerTrainingMaterialRepository, PlayerTrainingMaterialRepository>();
            services.AddScoped<IExpertApplicationRepository, ExpertApplicationRepository>();
            services.AddScoped<IIndividualSessionRepository, IndividualSessionRepository>();
            services.AddScoped<IScheduledSessionRepository, ScheduledSessionRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<IExpertService, ExpertService>();
            services.AddScoped<IGameService, GamesApiFacade>();
            services.AddScoped<ITrainingMaterialService, TrainingMaterialService>();
            services.AddScoped<IPlayerTrainingMaterialService, PlayerTrainingMaterialService>();
            services.AddScoped<IExpertApplicationService, ExpertApplicationService>();
            services.AddScoped<IIndividualSessionService, IndividualSessionService>();
            services.AddScoped<IScheduledSessionService, ScheduledSessionService>();

            // Endpoints Case Conventions Configuration

            services.AddRouting(options => options.LowercaseUrls = true);

            // AutoMapper initialization
            services.AddAutoMapper(typeof(Startup));

            // Documentation Setup
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Help-I.API", Version = "v1" });
                c.EnableAnnotations();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HelpI.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
