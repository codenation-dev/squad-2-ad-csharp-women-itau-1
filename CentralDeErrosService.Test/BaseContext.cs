using CentralDeErros.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CentralDeErrosService.Test
{
    public class BaseContext
    {
        public DbContextOptions<CentralErrosContext> Options { get; }

        private Dictionary<Type, string> FileDataNames { get; } = new Dictionary<Type, string>();

        public BaseContext()
        {
            Options = new DbContextOptionsBuilder<CentralErrosContext>()
                .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CentralDeErros;Integrated Security=True;")
                .Options;

            FileDataNames.Add(typeof(User), $"TestData{Path.DirectorySeparatorChar}users.json");
            FileDataNames.Add(typeof(Event), $"TestData{Path.DirectorySeparatorChar}events.json");

        }

        private string FileName<T>()
        {
            return FileDataNames[typeof(T)];
        }

        public List<T> GetTestData<T>()
        {
            string content = File.ReadAllText(FileName<T>());

            return JsonConvert.DeserializeObject<List<T>>(content);
        }
    }
}
