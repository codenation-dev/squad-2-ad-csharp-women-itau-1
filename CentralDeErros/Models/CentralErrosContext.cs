using System;
using CentralDeErros.Models.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CentralDeErros.Models
{
    public class CentralErrosContext : DbContext
    {
        public DbSet<User> User { get; set; }

        public CentralErrosContext(DbContextOptions<CentralErrosContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //confirmação de configuraão para utilizar com In Memory Database
            if (!optionsBuilder.IsConfigured)
<<<<<<< HEAD
                optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=TesteDB; User Id = sa; Password=Jullia@3005;Trusted_Connection=False");
=======
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Codenation;Integrated Security=True;");
>>>>>>> 9f0ee4871e9c6215e1102181e3dd8a910cd9dffc

            //optionsBuilder.UseSqlite("Data Source=user.db");
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
           ;
        }
    }
}
