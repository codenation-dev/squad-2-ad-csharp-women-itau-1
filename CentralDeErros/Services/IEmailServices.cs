using CentralDeErros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Services
{
    public interface IEmailServices
    {
        Task<EmailResponse> SendEmailBySendGridAsync(string email, string assunto, string mensagem);
    }
}
