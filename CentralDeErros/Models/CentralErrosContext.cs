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
                //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CentralDeErros;Integrated Security=True;");

                //optionsBuilder.UseSqlServer("Server=WIN-M8X17VUIO5\\TESTE;Database=CentralDeErros; User Id =sa; Password=04011995;Trusted_Connection=False"); //Configurações Bruna

                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CentralDeErros;Integrated Security=True;"); //Configurações juliana
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new EventConfiguration());
        }
    }
}
