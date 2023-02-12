using Microsoft.EntityFrameworkCore;
using Registro_de_Fornecedores.Models;

namespace Registro_de_Fornecedores.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }
        public DbSet<FornecedorModel> Fornecedores { get; set;}
    }
}

