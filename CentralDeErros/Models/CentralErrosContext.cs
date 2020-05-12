using System;
using CentralDeErros.Models.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CentralDeErros.Models
{
    public class CentralErrosContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Event> Events { get; set; }

        public CentralErrosContext(DbContextOptions<CentralErrosContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //confirmação de configuraão para utilizar com In Memory Database
            if (!optionsBuilder.IsConfigured)
            {
              //optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=TesteDB; User Id = sa; Password=Jullia@3005;Trusted_Connection=False");

                //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CentralDeErros;Integrated Security=True;");

                //optionsBuilder.UseSqlServer("Server=WIN-M8X17VUIO5\\TESTE;Database=CentralErros2; User Id =sa; Password=04011995;Trusted_Connection=False"); //Configurações Bruna

                //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CentralDeErros;Integrated Security=True;"); //Configurações juliana

                optionsBuilder.UseSqlServer(@"Server=tcp:dev-quad2.database.windows.net,1433;Initial Catalog=CentralDeErros;Persist Security Info=False;User ID=bruna.ssouza2;Password=nDDD1844;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new EventConfiguration());
        }
    }
}
