using HelpI.API.Application.Application.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using HelpI.API.Application.Domain.Persistence.Repository;
using HelpI.API.Application.Domain.Services;
using HelpI.API.Application.Infrastructure.Persistence;
using HelpI.API.Games.Application.Services;
using HelpI.API.Games.Domain.Persistence;
using HelpI.API.Games.Domain.Persistence.Repository;
using HelpI.API.Games.Domain.Services;
using HelpI.API.Games.Infrastructure.Persistence.Repository;
using HelpI.API.Security.Application.Services;
using HelpI.API.Security.Domain.Persistence.Repositories;
using HelpI.API.Security.Domain.Services;
using HelpI.API.Security.Infrastructure.Repositories;
using HelpI.API.SeedWork;
using HelpI.API.SeedWork.Contexts;
using HelpI.API.SeedWork.Repositories;
using HelpI.API.Session.Application.Services;
using HelpI.API.Session.Domain.Repositories;
using HelpI.API.Session.Domain.Services;
using HelpI.API.Session.Infrastructure.Persistence.Repositories;
using HelpI.API.Training.Application.Services;
using HelpI.API.Training.Domain.Persistence.Repositories;
using HelpI.API.Training.Domain.Services;
using HelpI.API.Training.Infrastructure.Persistence.Repositories;

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
                options.UseMySQL(Configuration.GetConnectionString("AzureMySqlConnection"));
            });

            // Dependency Injection Configuration
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IExpertRepository, ExpertRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IGamesApiFacade, GamesApiFacade>();
            services.AddScoped<ITrainingMaterialRepository, TrainingMaterialRepository>();
            services.AddScoped<IPlayerTrainingMaterialRepository, PlayerTrainingMaterialRepository>();
            services.AddScoped<IExpertApplicationRepository, ExpertApplicationRepository>();
            services.AddScoped<IIndividualSessionRepository, IndividualSessionRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<IExpertService, ExpertService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<ITrainingMaterialService, TrainingMaterialService>();
            services.AddScoped<IPlayerTrainingMaterialService, PlayerTrainingMaterialService>();
            services.AddScoped<IExpertApplicationService, ExpertApplicationService>();
            services.AddScoped<IIndividualSessionService, IndividualSessionService>();

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
            if (env.IsDevelopment() || env.IsProduction())
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
