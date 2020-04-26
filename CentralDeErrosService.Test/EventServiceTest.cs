using CentralDeErros.Models;
using CentralDeErros.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CentralDeErrosService.Test
{
    public class EventServiceTest
    {
        private CentralErrosContext _context;

        public EventServiceTest()
        {
            var options = new DbContextOptionsBuilder<CentralErrosContext>();
            options.UseSqlServer("Server=WIN-M8X17VUIO5\\TESTE;Database=CentralDeErros; User Id =sa; Password=04011995;Trusted_Connection=False");

            _context = new CentralErrosContext(options.Options);
        }
        [Fact]
        public void Save_Test()
        {
            DateTime date = DateTime.Now;

            var fakeEvent = new Event()
            {
                Id = 0,
                Level = "error",
                Description = "descricao",
                Origin = "123.123.25",
                Data = new DateTime(date.Year, date.Month, date.Day, 0, 0, 5),
                Log = "log",
                Environment = "produção",
                Archived = 0,
                LogId = "100",
                Title = "title",
                CollectedBy = "Bruna"
            };

            var service = new EventService(_context);
            var atual = service.Salvar(fakeEvent);

            Assert.Equal(fakeEvent.Id, atual.Id);
        }
    }
}
