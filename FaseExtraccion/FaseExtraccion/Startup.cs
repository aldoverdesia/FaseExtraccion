using FaseExtraccion.BLL.Service;
using FaseExtraccion.Extension;
using FaseExtracion.Infraestructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;

namespace FaseExtraccion
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            foreach (var v in Configuration.AsEnumerable())
            {
                System.Configuration.ConfigurationManager.AppSettings.Set(v.Key, v.Value);
            }
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the containerdot
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDatabase(Configuration)
                    .AddRepositories()
                    .AddServices(Configuration);

            services.AddOptions();
            services.AddSingleton(Configuration);



            //services.AddTransient<IUnitOfWork, UnitOfWork>();
            //services.AddTransient<IEnterpriseService, EnterpriseService>();
           // services.AddTransient<IFaseService, FaseService>();

            //services.AddControllers();
            //services.AddAuthorization();
            //services.AddLogging();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();



        }
    }
}
