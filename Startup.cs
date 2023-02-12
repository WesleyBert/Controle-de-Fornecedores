using Microsoft.EntityFrameworkCore;
using Registro_de_Fornecedores.Data;
using Registro_de_Fornecedores.Repositorio;

namespace Registro_de_Fornecedores
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureService(IServiceCollection services)
        {
           
            services.AddControllersWithViews();
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<BancoContext>(o => o
                .UseSqlServer(Configuration.GetConnectionString("DataBase")));
             services.AddScoped<IFornecedorRepositorio, FornecedorRepositorio>();
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
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id}");
            });
        }
    }
}

