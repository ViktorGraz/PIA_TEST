using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PIA.DotNet.Interview.Backend.Service;
using PIA.DotNet.Interview.Core.Database;
using PIA.DotNet.Interview.Core.Repositories;

namespace PIA.DotNet.Interview.Backend
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // core
            services.AddSingleton<IDbContext, DbContext>();
            services.AddSingleton<ITaskRepository, TaskRepository>();

            // service
            services.AddSingleton<ITaskLogicService, TaskLogicService>();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
