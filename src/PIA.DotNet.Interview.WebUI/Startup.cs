using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PIA.DotNet.Interview.Core.Database;
using PIA.DotNet.Interview.Core.Repositories;
using PIA.DotNet.Interview.WebUI.UI_BL;


namespace PIA.DotNet.Interview.WebUI
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
   
            // core
            services.AddSingleton<IDbContext, DbContext>();
            services.AddSingleton<ITaskRepository, TaskRepository>();
        
            // services
            services.AddTransient<TaskService>();
            services.AddTransient<MarkdownService>();

            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
