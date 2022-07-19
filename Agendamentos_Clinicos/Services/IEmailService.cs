using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamentos_Clinicos.Services
{
    public interface IEmailService
    {
        void EnviarEmail(string email);
    }
}
