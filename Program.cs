using Microsoft.EntityFrameworkCore;
using Registro_de_Fornecedores.Data;
using Registro_de_Fornecedores.Repositorio;

namespace Registro_de_Fornecedores
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<BancoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));


            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<Repositorio.IFornecedorRepositorio, FornecedorRepositorio>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}