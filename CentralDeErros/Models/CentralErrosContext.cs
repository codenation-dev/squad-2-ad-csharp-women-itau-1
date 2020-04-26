using System;
using CentralDeErros.Models.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CentralDeErros.Models
{
    public class CentralErrosContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Event> Event { get; set; }

        public CentralErrosContext(DbContextOptions<CentralErrosContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //confirmação de configuraão para utilizar com In Memory Database
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=WIN-M8X17VUIO5\\TESTE;Database=CentralDeErros; User Id =sa; Password=04011995;Trusted_Connection=False"); //Configurações Bruna
                //optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=TesteDB; User Id = sa; Password=Jullia@3005;Trusted_Connection=False");
            }
                

            //optionsBuilder.UseSqlite("Data Source=user.db");
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new EventConfiguration());
        }
    }
}
